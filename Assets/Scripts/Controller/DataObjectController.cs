using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataObjectController : MonoBehaviour
{
    public int editorScene;
    public int visitorScene;

    public GameObject spawnElement;
    public GameObject hallElement;
    public GameObject cornerElement; 
    public GameObject doorElement;
    public GameObject exponatLoader;

    public GameObject uiTransformPanel;
    public GameObject uiExponatPanel;
    public GameObject uiElementSelector;

    public GameObject serviceElement;

    public int lastIdx;
    public GameObject[] worldElements;
    public const int MAX_WORLD_ELEMENTS = 8;

    public static DataObjectController GetInstance()
    {
        return GameObject.FindGameObjectsWithTag("DataObject")[0].GetComponent<DataObjectController>();
    }

    public static int AddWorldElement(GameObject element)
    {
        int last_free_index = -1;
        DataObjectController cntrlr = DataObjectController.GetInstance();

        last_free_index = GetFreeIndex(cntrlr.worldElements);
        if ( last_free_index > 0 )
            cntrlr.worldElements[last_free_index] = element;
       
        return last_free_index;
    }

    public static int GetFreeIndex(GameObject[] worldElements)
    {
        for (int i = 0; i < worldElements.Length; i++)
        {
            if (worldElements[i] == null)
            {
                return i;
            }
        }
        return -1;
    }

    void Awake()
    {
        this.worldElements = new GameObject[DataObjectController.MAX_WORLD_ELEMENTS];

        PlayerPrefs.SetString("key", "sd");
        PlayerPrefs.SetInt("playerId", 0);
        PlayerPrefs.SetInt("validPlayer", 0);
        PlayerPrefs.Save();

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
