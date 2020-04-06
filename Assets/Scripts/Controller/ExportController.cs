using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ExportController : MonoBehaviour
{
    public DataObjectController dataObject;
    public APIClient client;

    // Start is called before the first frame update
    void Start()
    {
        this.dataObject = GameObject.FindGameObjectsWithTag("DataObject")[0].GetComponent<DataObjectController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void export()
    {
        API.MuseumObject museum = new API.MuseumObject();
        int real_elements;

        Debug.Log("analyse " + dataObject.worldElements.Length + " world elements");

        real_elements = 0;
        for ( int i = 0; i < DataObjectController.MAX_WORLD_ELEMNTS; i++ )
        {
            if ( dataObject.worldElements[i] != null )
            {
                real_elements++;
            }
        }

        Debug.Log("found " + real_elements + " instantiate world elements.");

        int le = 0;
        museum.elements = new API.ElementObject[real_elements];
        for ( int i = 0; i < DataObjectController.MAX_WORLD_ELEMNTS; i++ )
        {
            if ( dataObject.worldElements[i] != null )
            {
                ElementController elementCntrl = dataObject.worldElements[i].GetComponent<ElementController>();
                museum.elements[le] = elementCntrl.GetElementObject();
                Debug.Log("adding element of type " + museum.elements[le].type);
                le++;
            }
        }

        string json = JsonConvert.SerializeObject(museum);
        Debug.Log("preparing museum for export. new room size: " + le + " jsonOject: " + json);

        APIClient clt = new APIClient("http://localhost/api/museum.php");
        clt.SetKey("sd");
        clt.SetParam("id", 0);
        clt.Post(json);
    }
}
