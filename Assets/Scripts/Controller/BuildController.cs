using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using UnityEngine.UI;

using UnityEngine;
using API;

/*
 *  API Objekte
 *  ElementObejct hält Serialsierte Datensätze die über den Builder aufgerufen werden und das Grundgerüst erstellen
 *  MuseumObject hält Meta Daten des genutzen Museums
 */

public class BuildController : MonoBehaviour
{
    public int museumId;
    public Camera camera;

    public GameObject exponatElement;

    public GameObject contentList;
    public GameObject selectedElement;

    public DataObjectController dataObject;

    //public TransformPanelController transformController;

    public Transform editCamera;
    public Transform uiBuildOverlay;
    public Transform canvas;

    public GameObject uiNewElementOverlay;
    public GameObject exportControllerObject;

    public APIClient client;
   
    private int lastId;

    // uiTransformPanel
    void Awake()
    {
        /* Erst wird das Global Datenobject geladen, damit die Benötigtten Assets System weit zur Verfügung stehen */
        this.dataObject = GameObject.FindGameObjectsWithTag("DataObject")[0].GetComponent<DataObjectController>();
        this.lastId = this.dataObject.lastIdx;
    }

    public void Preview()
    {
        this.editCamera.gameObject.SetActive(false);
        Instantiate(this.dataObject.serviceElement);
        this.uiBuildOverlay.gameObject.SetActive(false);
        Debug.Log("adding new Element to scene");
    }

    public void AddDoorElement()
    {
        this.AddElement(this.dataObject.doorElement);
    }

    public void AddCornerElement()
    {
        this.AddElement(this.dataObject.cornerElement);
    }

    public void AddHallElement()
    {
        this.AddElement(this.dataObject.hallElement);
    }

    public void AddElement(GameObject newElementObject)
    {
        if ( newElementObject == null )
        {
            Debug.LogError("missing gameobject to instantiate");
            return;
        }

        if ( this.uiNewElementOverlay == null )
        {
            Debug.LogError("missing new element overlay");
            return;
        }
        GameObject obj = Instantiate(this.uiNewElementOverlay);
        obj.GetComponent<AddElementPanelController>().newElement = newElementObject;
    }

    public void CloseAddElementPanel()
    {
        this.uiNewElementOverlay.GetComponent<AddElementPanelController>().newElement = null;
        this.uiNewElementOverlay.SetActive(false);
    }
}
