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
    public GameObject exponatElement;

    public GameObject contentList;
    //public GameObject elementSelector;

    public DataObjectController dataObject;

    public Transform editCamera;
    public Transform uiBuildOverlay;
    //public Transform uiTransformPanel;

    public APIClient client;

    public MuseumObject _current_museum;

    private List<GameObject> tempElements;

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
        GameObject tmp = (GameObject) Instantiate(newElementObject, newElementPosition, newElementRotation);
        GameObject btn = (GameObject) Instantiate(this.dataObject.uiElementSelector, this.contentList.transform.position, this.contentList.transform.rotation);

        btn.transform.SetParent(this.contentList.transform);

        btn.GetComponent<ElementSelectorController>().index = this.tempElements.Count;
        btn.GetComponent<Button>().onClick.AddListener(() => OnClick(btn.GetComponent<ElementSelectorController>().index));
        btn.transform.GetChild(0).GetComponent<Text>().text = "Object" + this.tempElements.Count;
        btn.gameObject.SetActive(true);
        btn.GetComponent<ElementSelectorController>().enabled = true;
        this.tempElements.Add(tmp);
    }

    public void Preview()
    {
        this.editCamera.gameObject.SetActive(false);
        // this.createBuilding();
        Instantiate(this.dataObject.serviceElement);
        this.uiBuildOverlay.gameObject.SetActive(false);
        Debug.Log("adding new Element to scene");
    }
    // uiTransformPanel
    void Awake()
    {
        /* Erst wird das Global Datenobject geladen, damit die Benötigtten Assets System weit zur Verfügung stehen */
        this.dataObject = GameObject.FindGameObjectsWithTag("DataObject")[0].GetComponent<DataObjectController>();
        this.tempElements = new List<GameObject>();
    }

    public void OnClick(int idx)
    {
        GameObject _selected = this.tempElements[idx - 1];
        //Vector3 current_pos = _selected.transform.position + transform.position;
        //Debug.Log("try to transform [" + idx + "]. Position(" + current_pos + ")");
        //Debug.Log(_selected.transform.position);
        this.dataObject.uiTransformPanel.GetComponent<TransformPanelController>().targetElement = _selected;
        this.dataObject.uiTransformPanel.gameObject.SetActive(true);
    }

    void Start()
    {

    }
}
