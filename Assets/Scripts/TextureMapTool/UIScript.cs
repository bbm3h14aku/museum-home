using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIScript : MonoBehaviour
{
    
    //Objects to manage
    public GameObject saveManagerObj;
    private SaveManager saveManager;
    public GameObject sphere;
    private SphereButtonEvent sphereButtonEvent;
    
    //UI-Elements    
    public Button loadButton;
    public InputField textureName;
    public Button exportButton;
    public Button importButton;
    private string stringToEdit = "";

    //window properties
    private bool showDestinationWindow = false;
    private double lastButtonSetTime = System.DateTime.Now.TimeOfDay.TotalMilliseconds;

    private Vector2 windowSize;
    private Vector2 windowPosition;
    private Rect windowRect;


    private ButtonData newButtonData = null;

    // Start is called before the first frame update
    void Start()
    {
        //setup object scripts
        saveManager = saveManagerObj.GetComponent<SaveManager>();
        sphereButtonEvent = sphere.GetComponent<SphereButtonEvent>();
        
        //add click listener to all Buttons
        exportButton.onClick.AddListener(doExportButton);
        importButton.onClick.AddListener(doImportButton);
        loadButton.onClick.AddListener(loadTextureButton);

        //define size and position of the popup-window
        windowSize = new Vector2(215, 100);
        windowPosition = new Vector2(Screen.width/2 - windowSize.x/2, Screen.height/2 - windowSize.y/2);
        windowRect = new Rect(windowPosition.x, windowPosition.y, windowSize.x, windowSize.y);
    }

    // Update is called once per frame
    void Update()
    {
        handleCreateButton();
    }

    void OnGUI()
    {
        //check if window is visible
        if(showDestinationWindow){
            //draw the window and call createWindowContext
            windowRect = GUI.Window(0, windowRect, createWindowContent, "Zieltextur eingeben: ");
            
        }

    }

    void createWindowContent(int windowID)
    {
        //refresh Textfield
        stringToEdit =  GUI.TextField(new Rect(5, 20, 205, 20), stringToEdit, 25);
        //if button is pressed and texture name in stringToEdit is available
        if (GUI.Button(new Rect(5, 60, 100, 20), "OK") && Resources.Load("360View/Wald/" + stringToEdit))
        {
            //finish buttondata and add it to the sphere
            newButtonData.destination = stringToEdit;
            sphereButtonEvent.addButton(newButtonData);

            //add Buttondata to savestate
            saveManager.addButton(sphereButtonEvent.textureName, newButtonData);

            //delete temporary buttondata
            newButtonData = null;
            //disable window
            showDestinationWindow = false;
        }else if(GUI.Button(new Rect(110, 60, 100, 20), "Cancel"))
        {
            //cancel the window
            newButtonData = null;
            showDestinationWindow = false;
        }
    }

    private void handleCreateButton()
    {
        //get current Time
        double time = System.DateTime.Now.TimeOfDay.TotalMilliseconds;
        //check if the last run isi 1000 ms ago and the right mouse button is pressed
        if(time - lastButtonSetTime > 1000 &&
            Input.GetMouseButton(2) && newButtonData == null && !showDestinationWindow)
        {
            //get the direction Vector(Ray) betreen camera and mouse
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

            //calc the position of the new button
            //position = camera position + skalierung der sphere(durchmesser) / 2 um den radius zu bekommen * direction of the camera mouse vector(ray)
            Vector3 buttonPosition = Camera.main.transform.position + sphere.transform.localScale.x / 2f * ray.direction;

            //create a new ButtonData
            newButtonData = new ButtonData();
            newButtonData.position = buttonPosition;

            //save the creation time to wait until the next butten can be made
            lastButtonSetTime = System.DateTime.Now.TimeOfDay.TotalMilliseconds;

            //show window
            showDestinationWindow = true;
        } 
    }


    
    //export buttons
    void doExportButton()
    {
        saveManager.export();
    }

    //import buttons
    void doImportButton()
    {
        saveManager.import();
        //reload buttons
        sphereButtonEvent.loadButtons(saveManager.loadButtons(sphereButtonEvent.textureName));
    }

    //load texture
    public void loadTextureButton()
    {
        sphereButtonEvent.loadTexture(textureName.text);
    }

}
