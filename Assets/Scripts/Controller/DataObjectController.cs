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
    public GameObject doorElement;
    public GameObject exponatLoader;

    public GameObject uiTransformPanel;
    public GameObject uiElementSelector;

    public GameObject serviceElement;

    public int lastIdx;
    public GameObject[] worldElements;
    public const int MAX_WORLD_ELEMNTS = 8;

    public static DataObjectController GetInstance()
    {
        return GameObject.FindGameObjectsWithTag("DataObject")[0].GetComponent<DataObjectController>();
    }

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

    public void saveWorld()
    {

    }
}
