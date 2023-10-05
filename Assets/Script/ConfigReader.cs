using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEditor.U2D.Aseprite;
using System.ComponentModel;


/*
**********************************************************************************************
   // ����!(�߿�!) �Ʒ� �� ���� Ŭ���� �Ʒ��� �Է��ؼ� �����ڸ� �����! //
**********************************************************************************************
    
    
    ConfigReader configreaders = new ConfigReader();
    configreaders.Initialize(configreaders.GetfilePath());
    configreaders.MakeDiction(""); <--���� ���� �� ���� �־��! config.ini ��  [ ] �ȿ� �� ���̴�! //��ҹ��� ������!
    
    >>>�߰���
    ConfigReader configreaders = new ConfigReader(title) <-- ���� ������ �ϳ��� ���������� ���� ��ĵ� ����, config.ini���� [title] ������ ��

**********************************************************************************************

    
    1.���� ��¹� 
    object rowdata = configreaders.GetDictionaryValue(""); <--- ���� ������ ���� ���� �־��! [ ] ���� �׸� �ִ� �� �̸��̴�! ���� �ƴϴ�! ������Ʈ�� ��ȯ�ȴ�!

    2.���̸� ��� �޴� ��(���� ������ ���� ����...�� �ʿ� ����!����� â�� ��ϻ�����! �ʿ��ϴٸ� �� �κ��� �����ؼ� ����Ѵ�!)
`   List<string> keylist =  configreaders.GetKeysAsList(); <-- Ű ��� ����Ʈ�� ���� ����׿� ��µȴ� 
    
    3.�������� �� ��ȯ �Ǵ��� Ȯ���ϴ� ��(���� ����, ���߳����� ���� ���� �ʿ�!)
    configreaders.GetConvertibleTypes(rowdata); <-rowdata �� �������� ��ȯ�� �� �ִ���(int,float,string,bool) �˷��ش� ����� â�� ����!
   
    4.���������� ��ȯ�ϱ�
    String stringdata = configreaders.ConvertToString(rowdata); <-- String ���� ��ȯ�Ѵ� 

    5.������ �ܷ� ��ȯ�ϱ� 
    T typedata = configreaders.ConvertToNumeric<T>(rowdata); <���ϴ� Ÿ������ ��ȯ��Ų��, T�� ���ϴ� ������ �־��!

    ex) int intdata = configreaders.ConvertToNumeric<int>(rowdata);

    6.���ϴ� ���������� �ޱ�
    T data= configreaders.Search<T>(key);  < ���ϴ� ket(�̸�)���� ���� �� ������ Ʋ�� ���� or ���� key(�̸�)�� ��� ����� â�� ������ Ȯ��.
    ex)float damage= configreaders.Search<float>("damage");

   */
public class ConfigReader 
{
   
    private static readonly string configFilePath = "./Assets/Script/config/Config.ini";
    private static Dictionary<string, Dictionary<string, string>> sapData;
    private static Dictionary<string, string> resultDict;
    //configfilepath�� Config ���� ������ 

    //������
    public ConfigReader() { }
    public ConfigReader(string sapName)
    {
        this.Initialize(this.GetfilePath());
        this.MakeDiction(sapName);
    }

    public void Initialize(string filePath)
    {
        sapData= IniFileReader.ReadIniFile(filePath);
        resultDict = new Dictionary<string, string>();
    }

    //��� ���� 
    public string GetfilePath()
    {
        return configFilePath;
    }


    //��ųʸ� ���� 
    public void MakeDiction(string sapName)
    {
     

        if (sapData.ContainsKey(sapName))
        {
            resultDict.Add("valname", sapName);

            foreach (var kvp in sapData[sapName])
            {
                resultDict.Add(kvp.Key, kvp.Value);
            }
        }

       
    }

    //�迭�� Ű�̸����� ��ȯ�� 
    public List<string> GetKeysAsList()
    {
        List<string> keysList = new List<string>(resultDict.Keys);

        // Ű ��ϸ��� ���
        Debug.Log("Keys in resultDict: " + string.Join(", ", keysList));

        return keysList;
    }

    // ���� object �� ��ȯ 
    public object GetDictionaryValue(string key)
    {
        if (resultDict.ContainsKey(key))
        {
            return resultDict[key];
        }
        else
        {
            Debug.LogError("�����ڵ� ����");
            return null;
        }
    }

    //Ÿ�� Ȯ�� 
    public void GetConvertibleTypes(object value)
    {
        if (value != null)
        {
            string convertibleTypes = "Convertible to: ";

            if (value is string)
            {
                convertibleTypes += "string";
            }

            if (value is int)
            {
                if (convertibleTypes.Length > 16)
                {
                    convertibleTypes += ", ";
                }
                convertibleTypes += "int";
            }

            if (value is float)
            {
                if (convertibleTypes.Length > 16)
                {
                    convertibleTypes += ", ";
                }
                convertibleTypes += "float";
            }

            if (value is bool)
            {
                if (convertibleTypes.Length > 16)
                {
                    convertibleTypes += ", ";
                }
                convertibleTypes += "bool";
            }

            Debug.Log(convertibleTypes);
        }
        else
        {
            Debug.Log("Value is null.");
        }
    }

    // String ��ȯ 
    public string ConvertToString(object value)
    {
        if (value != null)
        {
            try
            {
                return Convert.ToString(value);
            }
            catch
            {
                Debug.LogError("���� ��ȯ ����");
                return null;
            }
        }
        else
        {
            Debug.LogError("Value is null.");
            return null;
        }
    }

    //����, bool������ ��ȯ 
    public T ConvertToNumeric<T>(object value)
    {
        if (value != null)
        {
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                Debug.LogError("���� ��ȯ ����");
                return default(T);
            }
        }
        else
        {
            Debug.LogError("Value is null.");
            return default(T);
        }
    }

    public T Search<T>(string key)
    {
        Dictionary<string, string> data=resultDict;
        if (data.ContainsKey(key))
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter != null)
            {
                // Cast ConvertFromString(string text) : object to (T)
                T result;
                try
                {
                    result = (T)converter.ConvertFromString(data[key]);
                    return result;
                }
                catch
                {
                    Debug.Log("WrongType");
                    return default(T);
                }

            }
            else
            {
                Debug.Log("NoneExist");
                return default(T);
            }
        }
        else
        {
            Debug.Log("WrongKey");
            return default(T);
        }
    }


}






// ���� ini ���� �о���� 
internal class IniFileReader
{
    public static Dictionary<string, Dictionary<string, string>> ReadIniFile(string filePath)
    {
        Dictionary<string, Dictionary<string, string>> iniData = new Dictionary<string, Dictionary<string, string>>();
        string currentSection = "";

        foreach (string line in File.ReadAllLines(filePath))
        {
            string trimmedLine = line.Trim();

            if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
            {
                currentSection = trimmedLine.Substring(1, trimmedLine.Length - 2);
                iniData[currentSection] = new Dictionary<string, string>();
            }
            else if (!string.IsNullOrEmpty(currentSection) && trimmedLine.Contains("="))
            {
                string[] keyValue = trimmedLine.Split('=');
                string key = keyValue[0].Trim();
                string value = keyValue[1].Trim();
                iniData[currentSection][key] = value;
            }
        }

        return iniData;
    }
}
internal class IniFileWriter
{
    public static void WriteIniFile(Dictionary<string, Dictionary<string, string>> iniData, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var section in iniData)
            {
                writer.WriteLine($"[{section.Key}]");

                foreach (var kvp in section.Value)
                {
                    writer.WriteLine($"{kvp.Key}={kvp.Value}");
                }

                writer.WriteLine();
            }
        }
    }
}