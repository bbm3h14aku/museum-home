using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataObjectController : MonoBehaviour
{
    public int editorScene;
    public int visitorScene;

    public GameObject hallElement;
    public GameObject cornerElement; 
    public GameObject entryElement;
    public GameObject exponatElement;

    public GameObject uiTransformPanel;
    public GameObject uiElementSelector;

    public GameObject serviceElement; 

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void loadEditor()
    {
        SceneManager.LoadScene(editorScene);
    }

    public void loadVisitor()
    {
        SceneManager.LoadScene(visitorScene);
    }
}
