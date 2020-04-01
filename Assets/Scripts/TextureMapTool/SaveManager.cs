using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public class SaveManager : MonoBehaviour
{
   
    [SerializeField]
    private Hashtable buttons = new Hashtable();

    //private IExporter exporter = new BinaryExporter();
    private IExporter<Hashtable> exporter = new XMLExporter<Hashtable,List<ButtonData>>();

    public string savefile = "Assets/Resources/Save/DataFile.xml";

    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addButton(string room, ButtonData data)
    {
        if(buttons[room] == null)
        {
            List<ButtonData> buttonList = new List<ButtonData>();
            buttonList.Add(data);
            buttons.Add(room, buttonList);
        }
        else
        {
            ((List<ButtonData>)buttons[room]).Add(data);
        }
    }

    public List<ButtonData> loadButtons(string textureName)
    {
        return (List<ButtonData>) buttons[textureName];
    }

    public List<ButtonData> getButtons(string scene)
    {
        return (List<ButtonData>) buttons[scene];
    }

    public void export()
    {
        exporter.export(buttons, savefile);
    }


    public void import()
    {
        Hashtable t = exporter.import(savefile);
        
        foreach (DictionaryEntry de in t) 
        {
            List<ButtonData> list = (List<ButtonData>)de.Value;
            foreach (ButtonData b in list) 
            {
                Debug.Log(de.Key + " : " + b.destination + b.position.ToString());
            }
        }

        buttons = t;
    }

}