using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Diarybookwpf
{
    public class JsonClass<T>
    {
        //public void Serialize(string fileName, T data)
        //{
        //    var json = JsonConvert.SerializeObject(data);
        //    File.WriteAllText(fileName, json);
        //}

        //public T Deserialize(string fileName)
        //{
        //    var json = File.ReadAllText(fileName);
        //    return JsonConvert.DeserializeObject<T>(json);
        //}
        //public static void Serialize<T>(string filePath, T obj)
        //{
        //    JsonSerializerSettings settings = new JsonSerializerSettings
        //    {
        //        TypeNameHandling = TypeNameHandling.All
        //    };
        //    string json = JsonConvert.SerializeObject(obj, settings);
        //    File.WriteAllText(filePath, json);
        //}

        //public static T Deserialize<T>(string filePath)
        //{
        //    JsonSerializerSettings settings = new JsonSerializerSettings
        //    {
        //        TypeNameHandling = TypeNameHandling.All
        //    };
        //    string json = File.ReadAllText(filePath);
        //    return JsonConvert.DeserializeObject<T>(json, settings);
        //}
        //public static string Serialize<T>(T obj)
        //{
        //    return JsonConvert.SerializeObject(obj);
        //}

        //public static T Deserialize<T>(string json)
        //{
        //    return JsonConvert.DeserializeObject<T>(json);
        //}
    }
}
