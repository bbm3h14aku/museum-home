using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class loadTextureToImagePreview : MonoBehaviour
{

    public Button button;
    public InputField textureName;
    public GameObject sphere;

    // Start is called before the first frame update
    void Start()
    {
        textureName = GameObject.Find("Texturename").GetComponent<InputField>();
        sphere = GameObject.Find("SpherePreview");

        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(loadTexture);

        Debug.Log("add actionListener to: " + btn.name);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadTexture()
    {
        

        string path = "360View/Wald/" + textureName.text;

        Texture2D texture  = (Texture2D) Resources.Load(path);
        if (texture != null)
        {
            Debug.Log("load Texture: " + path);
            sphere.GetComponent<Renderer>().material.mainTexture = texture;
        }
        else 
        { 
            Debug.Log("Error loading Texture: " + path);
        }
    }
}
