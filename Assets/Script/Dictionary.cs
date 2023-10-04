using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Dictionary
{
    private Dictionary<string, Dictionary<string, string>> configData;
    ConfigReader configreader;
    Dictionary<string, string> data;
    public Dictionary(string search)
    {
        configreader = new ConfigReader();
        ConfigReader.Initialize(configreader.GetfilePath());
        data = configreader.GetDiction(search);
    }

    public T Init<T>(string key)
    {
        if (data.ContainsKey(key))
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter != null)
            {
                // Cast ConvertFromString(string text) : object to (T)
                T result;
                try
                {
                    result=(T)converter.ConvertFromString(data[key]);
                    return result;
                }
                catch
                {
                    Debug.Log("WrongType");
                    return default(T);
                }

            }else
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
