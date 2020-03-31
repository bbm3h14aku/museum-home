using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ServiceState { MENU, HALL, LOADING }
public delegate void OnStateChangeHandler();

public class ServiceWorker : MonoBehaviour
{
    public static ServiceWorker instance = null;

    private const float API_MAX = 10 * 60.0f; // 10 Minutes

    public string keyWord;
    public string[] results;
    public int current_page;
    public int multiplic_page = 20;

    public GameObject hallPrefab;
    public GameObject playerPrefab;

    private AssetBundle assetBundle;

    private float api_timer;

    // Called when the Object is initialized
    void Awake()
    {
        // if it doesn't exists
        if (instance == null)
        {
            instance = this;
        }

        // There can only be a single instance of the game manager
        else if (instance != this)
        {
            // destroy the current object, so there is just one manager
            Destroy(gameObject);
        }

        // dont destroy this object when loading scenes
        DontDestroyOnLoad(gameObject);
        Instantiate(playerPrefab, new Vector3(0, 1, 0), Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        /*
        for ( int i = 1; i <= 5; i++)
        {
            Instantiate(hallPrefab, new Vector3(5 * i, 1, 0), Quaternion.identity);
        }
        Debug.Log("loading custome scenes form resources");
        */       
    }

    // Update is called once per frame
    void Update()
    {
        api_timer -= Time.deltaTime;
        if ( api_timer <= 0 )
        {
            API.OpenWeatherController.GetWeather("London,uk");
        }
    }


    public void loadScene(int page_idx)
    {
        //TODO: Neu Szene aus vorhandenem Material dynamisch erstellen. Prefab HallElement
        SceneManager.LoadScene("Level");
    }
}
