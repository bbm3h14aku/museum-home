using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSphereTexture : MonoBehaviour
{
    public GameObject sphere;
    private SphereButtonEvent sphereButtonEvent;
    public string scene;

    // Start is called before the first frame update
    void Start()
    {   
        sphere = GameObject.Find("SpherePreview");
        sphereButtonEvent = sphere.GetComponent<SphereButtonEvent>();
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
            if(sphereButtonEvent!= null)
            {
                sphereButtonEvent.loadTexture(scene);
            }
            else
            {
                Debug.Log("sphereButtonEvent is null");
            }
         }
    }
}
