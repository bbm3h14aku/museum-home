using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class PlayerContronller : MonoBehaviour
{
    private class PlayerPosition
    {
        public int x { get; set; }
        public int z { get; set; }

        public int angle { get; set; }
    }
    public float walk_speed;
    public Transform UIMenu;
    public Vector3 lastValidPosition;

    // to keep our rigidbody
    Rigidbody rb;
    // to keep the collider
    Collider coll;

    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        UIMenu.gameObject.SetActive(false);
        isPaused = false;

        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();

        rb.MovePosition(new Vector3(0f, 1f, 0f));
        transform.position = new Vector3(0, 0, 0);
    }

    public void ExitPause()
    {
        UIMenu.gameObject.SetActive(false);
        isPaused = false;
        transform.position = lastValidPosition;
        rb.useGravity = true;
    }

    public void FQExit()
    {
        Application.Quit();
    }

    private void updatePosition()
    {
        Vector3 pos = transform.position;
        int x = (int)pos.x;
        int z = (int)pos.z;

        PlayerPosition position = new PlayerPosition();
        position.x = x;
        position.z = z;

        position.angle = 0;


        //Debug.Log("sending " + lastValidPosition.x + ", " + lastValidPosition.y + ", " + lastValidPosition.z + " to server");
        string json = JsonConvert.SerializeObject(position);
        APIClient client = new APIClient("http://localhost/api/player.php");
        client.SetKey("sd");
        client.Post(json);
    }

    // Update is called once per frame
    void Update()
    {
        updatePosition();
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            UIMenu.gameObject.SetActive(true);
            rb.useGravity = false;
            transform.position = new Vector3(1024, 1024, 1024);
            isPaused = true;
        }
        else if ( Input.GetKeyDown(KeyCode.Escape) && isPaused )
        {
            this.ExitPause();
        }
    }
  
    //sync with physics
    void FixedUpdate()
    {
        WalkHandler();
        RotationHandler();
    }

    void OnTriggerEnter(Collider collider)
    {
       
        if ( collider.gameObject.tag == "Door" )
        {
            //print("loading next level");
            //GameManager.instance.increaseLevel();
        }

    }

    //the camera rotates not the player itself
    void RotationHandler()
    {
        //prevert topple
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    void WalkHandler()
    {
        //get inputs
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        //get directions of input and map it on the vector of the camera
        Vector3 dh = hAxis * Camera.main.transform.right * (this.walk_speed / 2);
        Vector3 dv = vAxis * Camera.main.transform.forward * this.walk_speed;

        //translate by delta horicontal and delta vertical
        transform.Translate(dh * Time.deltaTime);
        transform.Translate(dv * Time.deltaTime);

        //Debug.Log("Current position:" + transform.position);
    }
    
}