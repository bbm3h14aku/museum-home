using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTable : MonoBehaviour
{
    public string text;
    public TextMesh mech;
    
    private Rect windowRect = new Rect (20, 20, 300, 300);
    private bool showInfo = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        
        mech.text = "Klick Mich!";
    }

    

     void OnMouseDown()
    {
        showInfo = true;
    }

    void OnGUI()
    {
        

        if(showInfo)
            windowRect = GUI.Window(0, windowRect, DoMyWindow, "Infos");
    }

    // Make the contents of the window
    void DoMyWindow(int windowID)
    {
        GUI.Label(new Rect(10, 10, 250, 250), text);

        if (GUI.Button(new Rect(10, 250, 100, 20), "Close"))
        {
            showInfo = false;
        }
    }
}
