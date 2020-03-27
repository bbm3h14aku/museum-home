using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightController : MonoBehaviour
{
    public Light lightComp;
    public GameObject lightObject;

    // Start is called before the first frame update
    void Start()
    {
        // get gameobject
        foreach ( Light child in gameObject.transform )
        {
            if ( child.tag == "lightObject")
            {
                lightComp = child;
            }
        }

        // Add the light component
        //Light lightComp = lightObject.AddComponent<Light>();
        //Light lightComp = gameObject.GetComponent<Light>();

        // Set color and position
        lightComp.color = Color.blue;

        // change type to spot
        lightComp.type = LightType.Spot;

        // Set the position (or any transform property)
        lightObject.transform.position = gameObject.transform.position;
        lightObject.transform.rotation = Quaternion.Euler(20, -85, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //spotlight.color -= (Color.white / 2.0f) * Time.deltaTime;
    }
}
