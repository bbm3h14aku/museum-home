using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SphereButtonEvent : MonoBehaviour
{

    public GameObject buttonPrefab;
    public GameObject saveManagerObject;


    private double lastButtonSetTime = System.DateTime.Now.TimeOfDay.TotalMilliseconds;

    private Vector2 windowSize;
    private Vector2 windowPosition;
    private Rect windowRect;
    private bool showInfo = false;

    private string stringToEdit = "";
    public string textureName = "";


    private GameObject newButton = null; 
    Hashtable buttons = new Hashtable();

    private SaveManager saveManager = null;
        
    public List<GameObject> activeButtons = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        saveManager = saveManagerObject.GetComponent<SaveManager>();

        windowSize = new Vector2(200, 100);
        windowPosition = new Vector2(Screen.width/2 - windowSize.x/2, Screen.height/2 - windowSize.y/2);
        windowRect = new Rect(windowPosition.x, windowPosition.y, windowSize.x, windowSize.y);
        //buttonPrefab = GameObject.Find("Sphere");
        
    }

    // Update is called once per frame
    void Update()
    {
        handleCreateButton();
        
    }

    void OnGUI()
    {
        if(showInfo){
            windowRect = GUI.Window(0, windowRect, createWindowContent, "Zieltextur eingeben: ");
            
        }

    }

    void createWindowContent(int windowID)
    {

        
        stringToEdit =  GUI.TextField(new Rect(0, 20, 200, 20), stringToEdit, 25);
        if (GUI.Button(new Rect(0, 60, 100, 20), "OK") && Resources.Load("360View/Wald/" + stringToEdit))
        {
            activeButtons.Add(newButton);
            ButtonData bData = new ButtonData();
            bData.destination = stringToEdit;
            bData.position = newButton.transform.position;
            saveManager.addButton(textureName, bData);
            //saveManager.addButton(textureName, new ButtonData(stringToEdit, newButton.transform.position));
            changeSphereTexture teleport = newButton.GetComponent<changeSphereTexture>();
            teleport.scene = stringToEdit;
            newButton = null;
            showInfo = false;
        }

        GUI.DragWindow();
    }

    private void handleCreateButton()
    {
        //get current Time
        double time = System.DateTime.Now.TimeOfDay.TotalMilliseconds;
        //check if the last run isi 1000 ms ago and the right mouse button is pressed
        if(time - lastButtonSetTime > 1000 &&
            Input.GetMouseButton(2) && newButton == null)
        {
            //get the direction Vector(Ray) betreen camera and mouse
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

            //calc the position of the new button
            //position = camera position + skalierung der sphere(durchmesser) / 2 um den radius zu bekommen * direction of the camera mouse vector(ray)
            Vector3 buttonPosition = Camera.main.transform.position + transform.localScale.x / 2f * ray.direction;

            //create a new instance of the buttonPrefab
            newButton = (GameObject) Instantiate(buttonPrefab, buttonPosition, Quaternion.identity);
            

            //save the creation time to wait until the next butten can be made
            lastButtonSetTime = System.DateTime.Now.TimeOfDay.TotalMilliseconds;

            showInfo = true;
        } 
    }

    public void clearAllButtons()
    {
        foreach(var i in activeButtons)
        {
            Destroy(i);
        }

        activeButtons.Clear();
    }

    public void loadButtons(List<ButtonData> data)
    {
        foreach(var i in data)
        {
                    GameObject tempButton = (GameObject) Instantiate(buttonPrefab, i.position, Quaternion.identity);
                    changeSphereTexture teleport = tempButton.GetComponent<changeSphereTexture>();
                    teleport.scene = i.destination;

                    activeButtons.Add(tempButton);
        }


    }

}
