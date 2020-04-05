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

    public GameObject newElement;

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
        float x_pos = 0;
        float y_pos = 0;
        float z_pos = 0;

        if ( Stringutils.isNumeric(this.xPos.text) && Stringutils.isNumeric(this.yPos.text) && Stringutils.isNumeric(this.zPos.text) )
        {
            x_pos = float.Parse(this.xPos.text);
            y_pos = float.Parse(this.yPos.text);
            z_pos = float.Parse(this.zPos.text);
        }

        float x_rot = float.Parse(this.xRot.text);
        float y_rot = float.Parse(this.yRot.text);
        float z_rot = float.Parse(this.zRot.text);

        Vector3 position = new Vector3(x_pos, y_pos, z_pos);
        Quaternion rotation = Quaternion.Euler(x_rot, y_rot, z_rot);

        GameObject obj = Instantiate(this.newElement, position, rotation);
        DataObjectController dataObj = DataObjectController.GetInstance();
        dataObj.worldElements[dataObj.lastIdx] = obj;
        dataObj.lastIdx++; 
    }

    public void Close()
    {
        Debug.Log("try to close/hide window");
        this.enabled = false;
    }
   
}
