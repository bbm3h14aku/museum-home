using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using UnityEngine.UI;

using UnityEngine;
using API;

public class VisitorController : MonoBehaviour
{
    public int museumId;

    /* Building Objects */
    /*
    public GameObject hallElement;
    public GameObject cornerElement;
    public GameObject entryElement;
    */

    /* Exponat Objects */
    public GameObject exponatElement;
    /* Service Objects */
    public GameObject serviceElement;

    /* Global Ref to DataObject */
    public DataObjectController dataObject;

    /* Runtime Objects */
    public MuseumObject _current_museum;
    public APIClient client;

    void Awake()
    {
        /* Erst wird das Global Datenobject geladen, damit die Benötigtten Assets System weit zur Verfügung stehen */
        this.dataObject = GameObject.FindGameObjectsWithTag("DataObject")[0].GetComponent<DataObjectController>();
        /* Das Gebäude wird an Hand der übermittelten Id erstellt */
        this.createBuilding();
    }

    // Start is called before the first frame update
    void Start()
    {
        /* Service Runtime Element wird erstellt und die Kontrolle wird delegiert */
        Instantiate(this.dataObject.serviceElement);
    }

    public void createBuilding()
    {
        /* Objekte werden aus entfernter datenbank via api abgerufen */
        this.client = new APIClient("http://localhost/api/museum.php");
        this.client.SetKey("sd");
        this.client.SetParam("id", 0);
        string json = this.client.Get();
        /* Objekt wird erstellt */
        MuseumObject m = JsonConvert.DeserializeObject<MuseumObject>(json);

        for (int i = 0; i < m.elements.Length; i++)
        {
            Quaternion q = Quaternion.Euler(m.elements[i].rot_x, m.elements[i].rot_y, m.elements[i].rot_z);
            Vector3 p = new Vector3(m.elements[i].pos_x + 0.05f, m.elements[i].pos_y, m.elements[i].pos_z);
            GameObject instance = null;

            switch (m.elements[i].type)
            {
                case "hall":
                    instance = this.dataObject.hallElement;
                    break;
                case "corner":
                    instance = this.dataObject.cornerElement;
                    break;
                case "entry":
                    instance = this.dataObject.entryElement;
                    break;
                default:
                    continue;
            }
            if (instance != null)
            {
                m.elements[i].gameObject = Instantiate(instance, p, q);

                this.createExponats(m.elements[i].exponatListId);
            }
        }
        /* weise erstelltes museum öffentlicher variable für späteren zugriff zu */
        this._current_museum = m;
    }

    /* Lade Exponate aus Datenbank */
    public void createExponats(int id)
    { 
        if (id <= 0)
            return;
        this.client = new APIClient("http://localhost/api/exponat.php");
        this.client.SetKey("sd");
        this.client.SetParam("id", id);
        string json = this.client.Get();
        /* Erstellte Exponate in temporärem array */
        ExponatObject[] e = JsonConvert.DeserializeObject<ExponatObject[]>(json);

        for (int i = 0; i < e.Length; i++)
        {
            Debug.Log("loading element " + e[i].exponat);
            GameObject exponatElement = Instantiate(this.exponatElement);
            exponatElement.GetComponent<ExponatLoader>().assetName = e[i].label;
            exponatElement.GetComponent<ExponatLoader>().bundleName = e[i].exponat;
            exponatElement.GetComponent<ExponatLoader>().exponatData = e[i];
            exponatElement.GetComponent<ExponatLoader>().enabled = true;

        }
    }
}
