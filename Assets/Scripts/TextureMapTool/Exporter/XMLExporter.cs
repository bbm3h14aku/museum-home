
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Linq;


/*
    T is the type of the Container
    U is the type of the container in container T.
    example if we have this: 
        Hashtable ht = new Hashtable();
        List<int> list = new List<int>;
        ht.Add("Test", list);
    we need the Typeparameter XMLExporter<Hashtable, List<int>>

    Export example:
        //-----------------Example-------------------//
        //export XML hashtable
        Hashtable buttons = new Hashtable();
        IExporter<Hashtable> exp = new XMLExporter<Hashtable,List<ButtonData>>();
        exp.export(buttons, "testHashTable.xml");

        //export Dictionary
        Dictionary<string, Vector3> d = new Dictionary<string, Vector3> ();
        d.Add("Peter", new Vector3(1, 2, 3));
        d.Add("Hans", new Vector3(4, 2, 4));
        IExporter<Dictionary<string, Vector3>> ex = new XMLExporter<Dictionary<string, Vector3>, Vector3>();
        ex.export(d, "testDictionary.xml"); 
        
        //export Array
        ButtonData[] g = new ButtonData[2];
        g[0] = new ButtonData();
        g[0].destination = "Peter";
        g[1] = new ButtonData();
        g[1].destination = "Hanna";
        IExporter<ButtonData[]> exa = new XMLExporter<ButtonData[], object>();
        exa.export(g, "testArray.xml");


    Import example:
        //-----------------Example-------------------//
        //import Hashtable
        IExporter<Hashtable> exp = new XMLExporter<Hashtable,List<ButtonData>>();
        Hashtable h = exp.import("testHashTable.xml");

        //import Dictionary
        Dictionary<string, Vector3> d = new Dictionary<string, Vector3> ();
        d.Add("Peter", new Vector3(1, 2, 3));
        d.Add("Hans", new Vector3(4, 2, 4));
        IExporter<Dictionary<string, Vector3>> ex = new XMLExporter<Dictionary<string, Vector3>, Vector3>();
        Dictionary<string, Vector3> du = ex.import("testDictionary.xml"); 

        foreach (KeyValuePair<string, Vector3> de in du) 
        {
            
            Debug.Log(de.Key + " : " + de.Value.ToString());
        }

        //import Array
        ButtonData[] g = new ButtonData[2];
        g[0] = new ButtonData();
        g[0].destination = "Peter";
        g[1] = new ButtonData();
        g[1].destination = "Hanna";
        IExporter<ButtonData[]> exa = new XMLExporter<ButtonData[], object>();
        ButtonData[] gu = exa.import("testArray.xml");

        foreach(ButtonData bd in gu)
        {
            Debug.Log(bd.destination + " : " + bd.position.ToString());
        }


*/
public class XMLExporter<T, U> : IExporter<T>
{
    //create a serializer
    private DataContractSerializer serializer = new DataContractSerializer(typeof(T), new[] { typeof(U) });

    public void export(T table, string path){

        //serialize objet table
        StringBuilder sb = new StringBuilder();
        using (StringWriter writer = new StringWriter(sb))
        using (var xmlWriter = XmlWriter.Create(writer))
        {
            serializer.WriteObject(xmlWriter, table);
        }

        //parse the xml text in sb to add returns. So it's better readable
        XDocument xml = XDocument.Parse(sb.ToString());
        //export xml file
        File.WriteAllText(path, xml.ToString());

    }

    public T import(string path){

        T result;
        //read xml file        
        string xml = File.ReadAllText(path);

        //deserialize the xml data
        using (StringReader reader = new StringReader(xml))
        using (var xmlReader = XmlReader.Create(reader))
        {
            //cast it to T
            result = (T)serializer.ReadObject(xmlReader);
        }


        return result;
    }
}



