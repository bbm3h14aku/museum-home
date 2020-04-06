using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddElementPanelController : MonoBehaviour
{
    public InputField xPos;
    public InputField yPos;
    public InputField zPos;

    public InputField xRot;
    public InputField yRot;
    public InputField zRot;

    public Text label;

    public int index;
    public GameObject newElement;

    public int mode;

    public const int MODE_NEW_ELEMENT = 0;
    public const int MODE_EDIT_ELEMENT = 1;

    public void Save()
    {
        float x_pos = 0f;
        float y_pos = 0f;
        float z_pos = 0f;

        float x_rot = 0f;
        float y_rot = 0f;
        float z_rot = 0f;

        if ( this.textPrecheck(this.xPos.text) )
            x_pos = float.Parse(this.xPos.text);
        if ( this.textPrecheck(this.yPos.text) )
            y_pos = float.Parse(this.yPos.text);
        if ( this.textPrecheck(this.zPos.text) )
            z_pos = float.Parse(this.zPos.text);

        if ( this.textPrecheck(this.xRot.text) )
            z_rot = float.Parse(this.zRot.text);
        if ( this.textPrecheck(this.xRot.text) )
            x_rot = float.Parse(this.xRot.text);
        if ( this.textPrecheck(this.yRot.text) )
            y_rot = float.Parse(this.yRot.text);


        Vector3 position = new Vector3(x_pos, y_pos, z_pos);
        Quaternion rotation = Quaternion.Euler(x_rot, y_rot, z_rot);
        
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
        dataObj.lastIdx++;

        this.Close();
    }

    public void SetEditMode()
    {
        this.mode = 1;
        this.label.text = this.index.ToString() + " Element bearbeiten";
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
