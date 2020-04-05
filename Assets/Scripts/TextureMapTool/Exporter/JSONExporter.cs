using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text; 

public class JSONExporter<T, U> : IExporter<T>
{
 
    private DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T), new[] { typeof(U) });
    public void export(T table, string path)
    {
        //string json = JsonSerializer.Serialize(table);
        MemoryStream stream1 = new MemoryStream();
        ser.WriteObject(stream1, table);

        stream1.Position = 0;
        var sr = new StreamReader(stream1);

        File.WriteAllText(path, sr.ReadToEnd());
    }

    //not working
    public T import(string path)
    {
        string json = File.ReadAllText(path);

        MemoryStream stream1 = new MemoryStream(Encoding.UTF8.GetBytes(json));
        stream1.Position = 0;
        var p2 = (T)ser.ReadObject(stream1);
        return p2;
    }
}
