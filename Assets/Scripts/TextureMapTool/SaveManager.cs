using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public class SaveManager : MonoBehaviour
{
   
    [SerializeField]
    //private Dictionary<string, List<ButtonData>> buttons = new Dictionary<string, List<ButtonData>>();
    private Hashtable buttons = new Hashtable();

    //private IExporter<Hashtable> exporter = new BinaryExporter<Hashtable>();
    private IExporter<Hashtable> exporter = new XMLExporter<Hashtable,List<ButtonData>>();
    //private IExporter<Dictionary<string, List<ButtonData>>> exporter = new JSONExporter<Dictionary<string, List<ButtonData>>, List<ButtonData>>();
    //private IExporter<Dictionary<string, List<ButtonData>>> exporter = new XMLExporter<Dictionary<string, List<ButtonData>>,List<ButtonData>>();

    public string savefile = "Assets/Resources/Save/DataFile.xml";

    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Add button to room and in the savestate
    public void addButton(string room, ButtonData data)
    {
        if(buttons[room] == null)
        {
            Debug.Log("Add new Room");
            List<ButtonData> buttonList = new List<ButtonData>();
            buttonList.Add(data);
            buttons.Add(room, buttonList);
        }
        else
        {
            Debug.Log("Add Button to room");
            ((List<ButtonData>)buttons[room]).Add(data);
        }
    }

    //loadButtons from savestate
    public List<ButtonData> loadButtons(string textureName)
    {
        Debug.Log("Load Button");
        return (List<ButtonData>) buttons[textureName];
    }

    //export savestate to file
    public void export()
    {
        exporter.export(buttons, savefile);
        
    }

    //import savestate from file
    public void import()
    {
        Hashtable t = exporter.import(savefile);
        //Dictionary<string, List<ButtonData>> t = new Dictionary<string, List<ButtonData>>();
        
        foreach (DictionaryEntry de in t)//KeyValuePair<string, List<ButtonData>> de in t) 
        {
            List<ButtonData> list = (List<ButtonData>)de.Value;
            foreach (ButtonData b in list) 
            {
                Debug.Log(de.Key + " : " + b.destination + b.position.ToString());
            }
            //Debug.Log(de.ToString());
        }

        buttons = t;
    }

}