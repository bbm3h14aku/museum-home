using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePreviewController : MonoBehaviour
{
    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = material;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
