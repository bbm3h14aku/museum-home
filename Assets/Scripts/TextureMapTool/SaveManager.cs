using System;
using System.Collections;
using System.Collections.Generic;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.JSONSerializeModule;



[Serializable]
public class SaveManager : MonoBehaviour
{
    public Button exportButton;
    public Button importButton;

    public GameObject sphere;
    private SphereButtonEvent sphereButtonEvent = null;
    
    [SerializeField]
    private Hashtable buttons = new Hashtable();

    // Start is called before the first frame update
    void Start()
    { 
        sphereButtonEvent = sphere.GetComponent<SphereButtonEvent>();
        //Button btn = exportButton.GetComponent<Button>();
        exportButton.onClick.AddListener(exportJSON);
        importButton.onClick.AddListener(importJSON);
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



    public void exportJSON()
    {

        ButtonData b1 = new ButtonData();
        b1.destination = "Hallo";

        ButtonData b2 = new ButtonData();
        b2.destination = "Hi";

        
        List<ButtonData> l1 = new List<ButtonData>();
        l1.Add(b1);
        l1.Add(b2);
        List<ButtonData> l2 = new List<ButtonData>();
        l2.Add(b1);
        l2.Add(b1);
        
         Hashtable buts = new Hashtable();
         //buts.Add(1, "eins");
         //buts.Add(2, "zwei");
         buts.Add("test", b1);
         buts.Add("testiiii", b2);

        
        /*string json = JsonUtility.ToJson(buts);

        Debug.Log(json);*/

        //serialize
        FileStream fs = new FileStream("DataFile.dat", FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        try 
        {
            formatter.Serialize(fs, buttons);
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


    public void importJSON()
    {
        //deserialize

        Hashtable t = null;

        FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
        try 
        {
            BinaryFormatter formatter = new BinaryFormatter();

            // Deserialize the hashtable from the file and 
            // assign the reference to the local variable.
            t = (Hashtable) formatter.Deserialize(fs);
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

        /*foreach (DictionaryEntry de in t) 
        {
            Debug.Log(de.Key + " : " + de.Value);
        }*/


        foreach (DictionaryEntry de in t) 
        {
            List<ButtonData> list = (List<ButtonData>)de.Value;
            foreach (ButtonData b in list) 
            {
                Debug.Log(de.Key + " : " + b.destination + b.position.ToString());
            }
        }

        buttons = t;
        sphereButtonEvent.clearAllButtons();
        Debug.Log("reload Texture: " + sphereButtonEvent.textureName);
        sphereButtonEvent.loadButtons((List<ButtonData>)buttons[sphereButtonEvent.textureName]);
        
    }

}


[Serializable]
public class ButtonData
{
    public string destination = "";
    public SerializableVector3 position = new SerializableVector3(0, 0, 0);

    /*public ButtonData(string _destination, Vector3 _position)
    {
        destination = _destination;
        position = _position;
    }*/
}