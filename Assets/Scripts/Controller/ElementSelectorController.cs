using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSelectorController : MonoBehaviour
{
    public int index;
    public GameObject target;
    public GameObject overlay;
    public bool active;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Debug.Log("click triggerd: " + index);
        if (index >= 0)
        {
            GameObject overlay = Instantiate(this.overlay);
            overlay.GetComponent<AddElementPanelController>().index = index;
            overlay.GetComponent<AddElementPanelController>().SetEditMode();
            overlay.GetComponent<AddElementPanelController>().newElement = DataObjectController.GetInstance().worldElements[this.index];
        }
    }
}
