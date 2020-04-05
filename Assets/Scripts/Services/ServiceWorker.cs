using UnityEngine;
using UnityEngine.SceneManagement;

public enum ServiceState { MENU, HALL, LOADING }
public delegate void OnStateChangeHandler();

public class ServiceWorker : MonoBehaviour
{

    public static ServiceWorker instance = null;
    private const float API_MAX = 10 * 60.0f; // 10 Minutes

    public GameObject UIMenu;
    public GameObject playerPrefab;
    private bool isPaused = false;

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
    }


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab, new Vector3(3.46f, -1.35f, 1.71f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void loadScene(int page_idx)
    {
        //TODO: Neu Szene aus vorhandenem Material dynamisch erstellen. Prefab HallElement
        SceneManager.LoadScene("Level");
    }
}
