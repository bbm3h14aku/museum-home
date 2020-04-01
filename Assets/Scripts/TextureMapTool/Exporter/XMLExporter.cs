
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Linq;



public class XMLExporter<T, U> : IExporter<T>
{
    private DataContractSerializer serializer = new DataContractSerializer(typeof(T), new[] { typeof(U) });



    public void export(T table, string path){

        //FileStream fs = new FileStream(path, FileMode.Create);


        StringBuilder sb = new StringBuilder();
        using (StringWriter writer = new StringWriter(sb))
        using (var xmlWriter = XmlWriter.Create(writer))
        {
            serializer.WriteObject(xmlWriter, table);
        }
       
        XDocument xml = XDocument.Parse(sb.ToString());
        File.WriteAllText(path, xml.ToString());

    }

    public T import(string path){
        T result;
        
        string xml = File.ReadAllText(path);

        using (StringReader reader = new StringReader(xml))
        using (var xmlReader = XmlReader.Create(reader))
        {
            result = (T)serializer.ReadObject(xmlReader);
        }


        return result;
    }
}
