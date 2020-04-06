using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddElementPanelController : MonoBehaviour
{
    public InputField xPos;
    public InputField zPos;

    public InputField ifRot;

    public Text label;

    public int index;
    public GameObject newElement;

    public int mode;

    public const int MODE_NEW_ELEMENT = 0;
    public const int MODE_EDIT_ELEMENT = 1;

    private DataObjectController dataObject;
    private GameObject contentList;

    bool xChanged;
    bool zChanged;
    bool rChanged;

    void Awake()
    {
        this.dataObject = DataObjectController.GetInstance();
        this.contentList = GameObject.FindGameObjectsWithTag("WorldObjectList")[0];
    }

    public void xPosChanged()
    {
        this.xChanged = true;
    }

    public void zPosChanged()
    {
        this.zChanged = true;
    }

    public void rotChanged()
    {
        this.rChanged = true;
    }

    void Update()
    {
        if ( this.index >= 0 && this.dataObject.worldElements[this.index] != null && this.mode == AddElementPanelController.MODE_EDIT_ELEMENT )
        {
            if ( !this.xChanged )
                this.xPos.text = this.dataObject.worldElements[this.index].transform.position.x.ToString();
            if ( !this.zChanged ) 
                this.zPos.text = this.dataObject.worldElements[this.index].transform.position.z.ToString();
        }
    }

    public void ExponatOnChange(int idx)
    {
        Debug.Log("changing exponat position: " + idx);
        GameObject exponatOverlay = Instantiate(this.dataObject.uiExponatPanel);

        exponatOverlay.GetComponent<AddExponatController>().parentId = this.index;
        exponatOverlay.GetComponent<AddExponatController>().id = idx;
    }

    public void Save()
    {
        float x_pos = 0f;
        float z_pos = 0f;

        float angle = 0f;

        if ( this.textPrecheck(this.xPos.text) )
            x_pos = float.Parse(this.xPos.text);
        if ( this.textPrecheck(this.zPos.text) )
            z_pos = float.Parse(this.zPos.text);

        if ( this.textPrecheck(this.ifRot.text) )
            angle = float.Parse(this.ifRot.text);

        Vector3 position = new Vector3(x_pos, 0f, z_pos);
        Quaternion rotation = Quaternion.Euler(0f, angle, 0f);
        
        switch ( mode )
        {
            case MODE_EDIT_ELEMENT: this.TransformElement(position, rotation); break;
            case MODE_NEW_ELEMENT:
            default: this.AddElement(position, rotation); break;
        }
    }

    public void TransformElement(Vector3 position, Quaternion rotation)
    {
        DataObjectController dataObj = DataObjectController.GetInstance();
        dataObj.worldElements[this.index].transform.position = position;
        dataObj.worldElements[this.index].transform.rotation = rotation;

        this.Close();
    }

    public void AddElement(Vector3 position, Quaternion rotation)
    {
        GameObject obj = Instantiate(this.newElement, position, rotation);

        DataObjectController dataObj = DataObjectController.GetInstance();
        dataObj.worldElements[dataObj.lastIdx] = obj;
        this.index = dataObj.lastIdx;
        this.createElementSelector();
        dataObj.lastIdx++;

        this.Close();
    }

    private void createElementSelector()
    {
        GameObject btn = (GameObject) Instantiate(this.dataObject.uiElementSelector, this.contentList.transform.position, this.contentList.transform.rotation);
        btn.transform.SetParent(this.contentList.transform);
        btn.GetComponent<ElementSelectorController>().index = this.index;
        btn.transform.GetChild(0).GetComponent<Text>().text = "Object " + this.index;
        btn.gameObject.SetActive(true);
        btn.GetComponent<ElementSelectorController>().enabled = true;
    }


    public void SetEditMode()
    {
        this.mode = 1;
        this.label.text = "Element " + this.index.ToString() + " bearbeiten";
    }

    private bool textPrecheck(string str)
    {
        return ( str != null && Stringutils.isNumeric(str) ) ? true : false;
    }

    public void Close()
    {
        Debug.Log("try to close/hide window");
        Destroy(gameObject);
    }
}
