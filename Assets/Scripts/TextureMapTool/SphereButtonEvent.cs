using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SphereButtonEvent : MonoBehaviour
{

    public GameObject buttonPrefab;
    public GameObject saveManagerObject;


    public string textureName = "";

    private SaveManager saveManager = null;
        
    public List<GameObject> activeButtons = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        saveManager = saveManagerObject.GetComponent<SaveManager>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addButton(ButtonData data)
    {
        GameObject newButton = (GameObject) Instantiate(buttonPrefab, data.position, Quaternion.identity);
        changeSphereTexture teleport = newButton.GetComponent<changeSphereTexture>();
        teleport.scene = data.destination;
        Debug.Log("Add Button to Scene" + textureName);
        activeButtons.Add(newButton);
    }

    public void clearAllButtons()
    {
        foreach(var i in activeButtons)
        {
            Destroy(i);
        }

        activeButtons.Clear();
    }

    public void loadButtons(List<ButtonData> data)
    {
        if(activeButtons.Count != 0)
            clearAllButtons();
        foreach(var i in data)
        {
                    GameObject tempButton = (GameObject) Instantiate(buttonPrefab, i.position, Quaternion.identity);
                    changeSphereTexture teleport = tempButton.GetComponent<changeSphereTexture>();
                    teleport.scene = i.destination;

                    activeButtons.Add(tempButton);
        }
    }

    public void loadTexture(string texName)
    {
        string path = "360View/Wald/" + texName;

        Texture2D texture  = (Texture2D) Resources.Load(path);
        if (texture != null)
        {
            Debug.Log("load Texture: " + path);
            GetComponent<Renderer>().material.mainTexture = texture;
            textureName = texName;
            loadButtons(saveManager.loadButtons(texName));
        }
        else 
        { 
            Debug.Log("Error loading Texture: " + path);
        }
    }

}
