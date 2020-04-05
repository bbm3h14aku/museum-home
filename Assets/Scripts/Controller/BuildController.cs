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
    public GameObject _drag;

    public Vector3 screenPosition;
    //public GameObject elementSelector;

    public DataObjectController dataObject;

    public GameObject transformPanel;
    //public TransformPanelController transformController;

    public Transform editCamera;
    public Transform uiBuildOverlay;
    //public Transform uiTransformPanel;

    public APIClient client;

    public MuseumObject _current_museum;

    private List<GameObject> tempElements;
    private int lastId;

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
        this.lastId++;
        GameObject tmp = (GameObject) Instantiate(newElementObject, newElementPosition, newElementRotation);
        tmp.AddComponent<ElementController>();
        tmp.GetComponent<ElementController>().id = this.lastId;
        tmp.GetComponent<ElementController>().editable = true;
        this.tempElements.Add(tmp);

        GameObject btn = (GameObject) Instantiate(this.dataObject.uiElementSelector, this.contentList.transform.position, this.contentList.transform.rotation);
        btn.transform.SetParent(this.contentList.transform);
        btn.GetComponent<ElementSelectorController>().index = this.tempElements.Count;
        btn.GetComponent<Button>().onClick.AddListener(() => OnClick(btn.GetComponent<ElementSelectorController>().index));
        btn.transform.GetChild(0).GetComponent<Text>().text = "Object" + this.tempElements.Count;
        btn.gameObject.SetActive(true);
        btn.GetComponent<ElementSelectorController>().enabled = true;
    }

    public void mouseHover()
    {
        Debug.Log("mouse over object");
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
        this.lastId = 0;
    }

    public void showTransformPanel()
    {
        this.transformPanel.GetComponent<TransformPanelController>().targetElement = this.selectedElement;
        this.transformPanel.GetComponent<TransformPanelController>().enabled = true;
        this.transformPanel.SetActive(true);
    }

    public void OnClick(int idx)
    {
        GameObject _selected = this.tempElements[idx];
        if ( _selected == null )
        {
            Debug.LogError("failed to load element from list.");
            return;
        }
        this.selectedElement = _selected;
        /*
        GameObject.Find("Canvas").GetComponent<TransformPanelController>().enabled = true;
        //Vector3 current_pos = _selected.transform.position + transform.position;
        //Debug.Log("try to transform [" + idx + "]. Position(" + current_pos + ")");
        //Debug.Log(_selected.transform.position);
        //this.uiBuildOverlay.GetComponent<TransformPanel>().GetComponent<TransformPanelController>().targetElement = _selected;
        //this.uiBuildOverlay.GetComponent<TransformPanel>().gameObject.SetActive(true);
        */
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                // whatever tag you are looking for on your game object
                if (hit.collider.tag == "BuildableElement")
                {
                    Debug.Log("---> Hit: ");
                }
               else
                {
                    Debug.Log("wrong tag[" + hit.collider.tag + "]");
                }
            }
        }
    }
}
