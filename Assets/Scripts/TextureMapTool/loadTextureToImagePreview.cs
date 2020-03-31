using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class loadTextureToImagePreview : MonoBehaviour
{

    public Button button;
    public InputField textureName;
    public GameObject sphere;
    private SphereButtonEvent sphereButtonEvent;
    public GameObject saveManagerObj;
    private SaveManager saveManager = null;

    // Start is called before the first frame update
    void Start()
    {

        saveManager = saveManagerObj.GetComponent<SaveManager>();
        sphereButtonEvent = sphere.GetComponent<SphereButtonEvent>();
        textureName = GameObject.Find("Texturename").GetComponent<InputField>();
        sphere = GameObject.Find("SpherePreview");

        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(loadTextureButton);

        Debug.Log("add actionListener to: " + btn.name);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadTextureButton()
    {
        loadTexture(textureName.text);
    }
    public void loadTexture(string texName)
    {
        

        string path = "360View/Wald/" + texName;

        Texture2D texture  = (Texture2D) Resources.Load(path);
        if (texture != null)
        {
            Debug.Log("load Texture: " + path);
            sphere.GetComponent<Renderer>().material.mainTexture = texture;
            sphereButtonEvent.textureName = texName;
            sphereButtonEvent.clearAllButtons();
            sphereButtonEvent.loadButtons(saveManager.loadButtons(texName));
            
        }
        else 
        { 
            Debug.Log("Error loading Texture: " + path);
        }
    }
}
