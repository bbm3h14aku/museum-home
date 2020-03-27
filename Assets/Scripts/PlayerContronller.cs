using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContronller : MonoBehaviour
{
    public float walk_speed = 8f;
    

    // to keep our rigidbody
    Rigidbody rb;
    // to keep the collider
    Collider coll;

    //GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();

        rb.MovePosition(new Vector3(0f, 0.01f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
       
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
            print("loading next level");
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
        Vector3 dh = hAxis * Camera.main.transform.right;
        Vector3 dv = vAxis * Camera.main.transform.forward;

        //translate by delta horicontal and delta vertical
        transform.Translate(dh * Time.deltaTime);
        transform.Translate(dv * Time.deltaTime);

    }
    
}