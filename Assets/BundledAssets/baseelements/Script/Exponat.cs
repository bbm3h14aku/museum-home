using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exponat : MonoBehaviour
{
    public GameObject hiddenChild;
    public GameObject trigger;

    public TextMesh labelTxt;
    public MeshRenderer renderer;
    public Material material; 

    public string label;
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        renderer.materials[0] = material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
