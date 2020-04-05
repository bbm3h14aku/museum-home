using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddElementController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddElement()
    {
        this.Close();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
