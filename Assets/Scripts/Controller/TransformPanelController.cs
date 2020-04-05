using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformPanelController : MonoBehaviour
{
    public Text xPosF;
    public Text yPosF;
    public Text zPosF;

    public GameObject targetElement = null;

    void Start()
    {
        if ( targetElement != null)
        {
            Vector3 pos = targetElement.transform.position;
            this.xPosF.text = pos.x.ToString();
            this.yPosF.text = pos.y.ToString();
            this.zPosF.text = pos.z.ToString();
        }
    }

    // Start is called before the first frame update
    public void Cancle()
    {
        gameObject.SetActive(false);
        Destroy(this);
    }

    // Update is called once per frame
    public void Save()
    {
        float x = float.Parse(xPosF.text);
        float y = float.Parse(yPosF.text);
        float z = float.Parse(zPosF.text);

        Debug.Log("formate y from " + yPosF.text + " to " + y);

        targetElement.transform.position = new Vector3(x, y, z);
        gameObject.SetActive(false);

        Destroy(this);
    }
}

