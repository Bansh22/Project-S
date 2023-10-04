using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class ConfigReader 
{
    private static string configFilePath = "Assets/Script/config/Config.ini";
    private static Dictionary<string, Dictionary<string, string>> configData;
    private static Dictionary<string, Dictionary<string, string>> sapData;

    public static void Initialize(string filePath)
    {
        configData = IniFileReader.ReadIniFile(filePath);
        sapData = configData;
    }

    public string GetfilePath()
    {
        return configFilePath;
    }

    public Dictionary<string, string> GetDiction(string sapName)
    {
        Dictionary<string, string> resultDict = new Dictionary<string, string>();

        if (sapData.ContainsKey(sapName))
        {
            resultDict.Add("valname", sapName);

            foreach (var kvp in sapData[sapName])
            {
                resultDict.Add(kvp.Key, kvp.Value);
            }
        }

        return resultDict;
    }
}






// 이후 ini 파일 읽어오기 
public class IniFileReader
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
public class IniFileWriter
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