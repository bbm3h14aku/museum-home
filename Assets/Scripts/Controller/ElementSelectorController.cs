using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSelectorController : MonoBehaviour
{
    public int index;
    public Transform overlay;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(overlay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Debug.Log("Clicked on: " + index);
        overlay.gameObject.SetActive(true);
    }
}
