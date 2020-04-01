using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class BinaryExporter<T> : IExporter<T>
{
    public void export(T table, string path)
    {
        //serialize
        FileStream fs = new FileStream(path, FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        try 
        {
            formatter.Serialize(fs, table);
        }
        catch (SerializationException e) 
        {
            Debug.Log("Failed to serialize. Reason: " + e.Message);
            throw;
        }
        finally 
        {
            fs.Close();
        }

    }


    public T import(string path)
    {
        //deserialize
        T t;

        FileStream fs = new FileStream(path, FileMode.Open);
        try 
        {
            BinaryFormatter formatter = new BinaryFormatter();

            // Deserialize the hashtable from the file and 
            // assign the reference to the local variable.
            t = (T) formatter.Deserialize(fs);
        }
        catch (SerializationException e) 
        {
            Debug.Log("Failed to deserialize. Reason: " + e.Message);
            throw;
        }
        finally 
        {
            fs.Close();
        }
        return t;
    }
}
