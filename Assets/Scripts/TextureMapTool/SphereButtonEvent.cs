using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SphereButtonEvent : MonoBehaviour
{

    public GameObject buttonPrefab;
    public string searchPath = "360View/Wald/";


    public string textureName = "";

    public SaveManager saveManager = null;
        
    public List<GameObject> activeButtons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //saveManager = saveManagerObject.GetComponent<SaveManager>();
        if(saveManager == null)
        {
            Debug.Log("saveManager is null");
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //create the button by using buttondata
    public void addButton(ButtonData data)
    {
        //create the new button
        GameObject newButton = (GameObject) Instantiate(buttonPrefab, data.position, Quaternion.identity);
        newButton.transform.localScale = transform.localScale /20;

        //fill the teleport script
        changeSphereTexture teleport = newButton.GetComponent<changeSphereTexture>();
        teleport.scene = data.destination;
        Debug.Log("Add Button to Scene" + textureName);
        //add button to active buttons
        activeButtons.Add(newButton);
    }

    //clear all buttons in this sphere
    public void clearAllButtons()
    {
        foreach(var i in activeButtons)
        {
            Destroy(i);
        }

        activeButtons.Clear();
    }

    //load buttons from buttondata
    public void loadButtons(List<ButtonData> data)
    {
        //clear all
        if(activeButtons.Count != 0)
            clearAllButtons();
        //add All Buttons
        foreach(var i in data)
        {
                    addButton(i);
        }
    }

    //load new texture to sphere
    public void loadTexture(string texName)
    {
        //add path to tex name
        string path = searchPath + texName;

        //load texture from path
        Texture2D texture  = (Texture2D) Resources.Load(path);
        //if not null
        if (texture != null)
        {
            Debug.Log("load Texture: " + path);
            //give the sphere material the new texture
            GetComponent<Renderer>().material.mainTexture = texture;
            //refresh the texturename in this sphere
            textureName = texName;
            //reload all buttons
            
            if(saveManager != null)
                loadButtons(saveManager.loadButtons(textureName));
            else
                Debug.Log("can't load Buttons");
        }
        else 
        { 
            Debug.Log("Error loading Texture: " + path);
        }
    }

}
