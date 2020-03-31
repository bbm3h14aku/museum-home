using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSphereTexture : MonoBehaviour
{
    public GameObject sphere;
    private loadTextureToImagePreview lTTIP;
    public string scene;

    // Start is called before the first frame update
    void Start()
    {   
        sphere = GameObject.Find("ButtonEvents");
        lTTIP = sphere.GetComponent<loadTextureToImagePreview>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        //Debug.Log("hover over image");
         if (Input.GetMouseButtonDown(1))
         {
            if(lTTIP!= null)
            {

                lTTIP.loadTexture(scene);

            }
            else
            {
                Debug.Log("lTTIP is null");
            }
         }
    }
}
