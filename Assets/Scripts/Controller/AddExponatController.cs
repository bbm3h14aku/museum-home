using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddExponatController : MonoBehaviour
{
    public Button btnSave;
    public Button btnCancle;

    public Text txtDescription;
    public Text txtLabel;
    public Text txtUrl;

    public DataObjectController dataObject;
    public GameObject _parent;

    public int parentId;
    public int id;

    public void Save()
    {
        dataObject = DataObjectController.GetInstance();
        if (parentId >= 0)
        {
            GameObject _object = Instantiate(dataObject.exponatLoader);
            _object.GetComponent<ExponatLoader>().description = txtDescription.text;
            _object.GetComponent<ExponatLoader>().label = txtLabel.text;
            _object.GetComponent<ExponatLoader>().imageurl = txtUrl.text;
        }
        
        this.Close();
    }

    public void Cancle()
    {
        this.Close();
    }

    public void Close()
    {
        _parent.SetActive(true);
        Destroy(gameObject);
    }
}
