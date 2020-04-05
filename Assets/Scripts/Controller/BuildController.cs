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
    public GameObject uiNewElementOverlay;

    public APIClient client;
   
    private int lastId;

    // uiTransformPanel
    void Awake()
    {
        /* Erst wird das Global Datenobject geladen, damit die Benötigtten Assets System weit zur Verfügung stehen */
        this.dataObject = GameObject.FindGameObjectsWithTag("DataObject")[0].GetComponent<DataObjectController>();
        this.lastId = 0;
    }

    public void Preview()
    {
        this.editCamera.gameObject.SetActive(false);
        // this.createBuilding();
        Instantiate(this.dataObject.serviceElement);
        this.uiBuildOverlay.gameObject.SetActive(false);
        Debug.Log("adding new Element to scene");
    }

    public void AddDoorElement()
    {
        this.AddElement(this.dataObject.doorElement, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
    }

    public void AddCornerElement()
    {
        this.AddElement(this.dataObject.cornerElement, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
    }

    public void AddHallElement()
    {
        this.AddElement(this.dataObject.hallElement, new Vector3(0, 0, 0), Quaternion.Euler(0,0,0));
    }

    public void AddElement(GameObject newElementObject, Vector3 newElementPosition, Quaternion newElementRotation)
    {
        this.uiNewElementOverlay.SetActive(true);
        /*
        GameObject tmp = (GameObject) Instantiate(newElementObject, newElementPosition, newElementRotation);

        tmp.AddComponent<ElementController>();
        tmp.GetComponent<ElementController>().id = this.lastId;
        tmp.GetComponent<ElementController>().editable = true;

        this.createElementSelector();

        GameObject.FindGameObjectsWithTag("DataObject")[0].GetComponent<DataObjectController>().worldElements[this.lastId] = tmp;
        Debug.Log("Adding Element " + this.lastId + " to global list");
        this.lastId++;
        */
    }

    private void createElementSelector()
    {
        GameObject btn = (GameObject)Instantiate(this.dataObject.uiElementSelector, this.contentList.transform.position, this.contentList.transform.rotation);
        btn.transform.SetParent(this.contentList.transform);
        btn.GetComponent<ElementSelectorController>().index = this.lastId;
        btn.transform.GetChild(0).GetComponent<Text>().text = "Object " + this.lastId;
        btn.gameObject.SetActive(true);
        btn.GetComponent<ElementSelectorController>().enabled = true;
    }
   
}
