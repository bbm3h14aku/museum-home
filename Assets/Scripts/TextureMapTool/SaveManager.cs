using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SaveManager : MonoBehaviour
{

    Hashtable buttons = new Hashtable();

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
}


public class ButtonData
{
    public string destination = "";
    public Vector3 position = new Vector3(0, 0, 0);

    public ButtonData(string _destination, Vector3 _position)
    {
        destination = _destination;
        position = _position;
    }
}