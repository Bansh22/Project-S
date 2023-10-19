using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.ComponentModel;
using System.Linq;


/*
**********************************************************************************************
   // 사용법!(중요!) 아래 세 줄을 클래스 아래에 입력해서 생성자를 만든다! //
**********************************************************************************************
    
    방법1
    ConfigReader configreaders = new ConfigReader();
    configreaders.Initialize(configreaders.GetfilePath());
    configreaders.MakeDiction(""); <--여기 참조 할 값을 넣어라! config.ini 에  [ ] 안에 들어갈 값이다! //대소문자 구별필!
    
    방법2(추천)
    ConfigReader configreaders = new ConfigReader(title) <-- 위의 과정을 하나로 압축했으며 위의 방식도 가능, config.ini에서 [title] 형태의 값

**********************************************************************************************
   // 사용법!(중요!) 값을 업데이트 하는 법! //
**********************************************************************************************
    

    configreaders.UpdateData(String Key ,String Value); 을 사용한다!



**********************************************************************************************

    
    1.값을 얻는법 
    object rowdata = configreaders.GetDictionaryValue(""); <--- 여기 가지고 싶은 값을 넣어라! [ ] 하위 항목에 있는 값 이름이다! 값이 아니다! 오브젝트로 반환된다!

    2.값이름 목록 받는 법(개발 끝나기 전에 삭제...할 필요 있음!디버그 창에 목록생성됨! 필요하다면 그 부분을 삭제해서 써야한다!)
`   List<string> keylist =  configreaders.GetKeysAsList(); <-- 키 목록 리스트가 들어가고 디버그에 출력된다 
    
    3.무엇으로 형 변환 되는지 확인하는 법(개발 전용, 개발끝나기 전에 삭제 필요!)
    configreaders.GetConvertibleTypes(rowdata); <-rowdata 가 무엇으로 변환될 수 있는지(int,float,string,bool) 알려준다 디버그 창을 봐라!
   
    4.문자형으로 변환하기
    String stringdata = configreaders.ConvertToString(rowdata); <-- String 으로 변환한다 

    5.문자형 외로 변환하기 
    T typedata = configreaders.ConvertToNumeric<T>(rowdata); <원하는 타입으로 변환시킨다, T에 원하는 형식을 넣어라!

    ex) int intdata = configreaders.ConvertToNumeric<int>(rowdata);

    6.원하는 문자형으로 받기
    T data= configreaders.Search<T>(key);  < 원하는 ket(이름)으로 받을 수 있지만 틀린 형태 or 없는 key(이름)일 경우 디버그 창에 나오니 확인.
    ex)float damage= configreaders.Search<float>("damage");

   */
public class ConfigReader 
{
    private static readonly string configFilePath = Application.streamingAssetsPath+"/Config.ini";
    private static Dictionary<string, Dictionary<string, string>> sapData; //첫 string 이 헤더 
    private static Dictionary<string, string> resultDict;
    private static String resultDictHeader=null;
    //configfilepath의 Config 전부 들고오기 

    //생성자
    public ConfigReader() { }
    public ConfigReader(string sapName)
    {
        this.Initialize(this.GetfilePath());
        this.MakeDiction(sapName);
    }

    //초기화
    public void Initialize(string filePath)
    {
        sapData= IniFileReader.ReadIniFile(filePath);
        resultDict = new Dictionary<string, string>();
    }

    //경로 참조 
    public string GetfilePath()
    {
        return configFilePath;
    }


    //딕셔너리 생성 
    public void MakeDiction(string sapName)
    {
     

        if (sapData.ContainsKey(sapName))
        {
            resultDictHeader = sapName;
            resultDict.Add("valname", sapName);

            foreach (var kvp in sapData[sapName])
            {
                resultDict.Add(kvp.Key, kvp.Value);
            }
        }

       
    }

    //배열로 키이름들을 반환함 
    public List<string> GetKeysAsList()
    {
        List<string> keysList = new List<string>(resultDict.Keys);

        // 키 목록만을 출력
        Debug.Log("Keys in resultDict: " + string.Join(", ", keysList));

        return keysList;
    }

    // 값을 object 로 반환 
    public object GetDictionaryValue(string key)
    {
        if (resultDict.ContainsKey(key))
        {
            return resultDict[key];
        }
        else
        {
            Debug.LogError("참조코드 에러");
            return null;
        }
    }

    //타입 확인 
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

    // String 변환 
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
                Debug.LogError("형식 변환 오류");
                return null;
            }
        }
        else
        {
            Debug.LogError("Value is null.");
            return null;
        }
    }

    //숫자, bool등으로 변환 
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
                Debug.LogError("형식 변환 오류");
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
            Debug.Log("WrongKey:"+ key);
            return default(T);
        }
    }
    public void UpdateData(String Key ,String Value)
    {
        if (resultDictHeader != null)
        {
            if (resultDict.ContainsKey(Key))
            {
                // 값 업데이트
                resultDict[Key] = Value;
                sapData[resultDictHeader][Key] = Value;

                // 수정된 데이터를 파일에 저장
                IniFileWriter.WriteIniFile(sapData, GetfilePath());
            }
            else
            {
                Debug.LogError("Key not found.");
            }
        }
    }



}






// 이후 ini 파일 읽어오기 
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