using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    //bewegungsgeschwindigkeit
    float bewegungsgeschwindigkeitMaus = 50f;


    // Update is called once per frame
    void Update()
    {
        //Hole X und Y von der Maus
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        //Wenn linke Maustaste gedrückt
        if (Input.GetMouseButton(0))
        {
            //rotiere die Kamera 
            //Time.deltaTime: Sekunden seit dem letzten Frame
            //Time.deltaTime * bewegungsgeschwindigkeitMaus: Damit sich die Maus gleichmäßig bewegt
            transform.Rotate(-vertical * Time.deltaTime * bewegungsgeschwindigkeitMaus, 
                    horizontal * Time.deltaTime * bewegungsgeschwindigkeitMaus, 0);

            //float drx = -vertical * Time.deltaTime * bewegungsgeschwindigkeitMaus;
            //float dry = horizontal * Time.deltaTime * bewegungsgeschwindigkeitMaus;


            //transform.rotation.eulerAngles = Quaternion.Euler(transform.rotation.x + drx, transform.rotation.y, 0f);
             transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
        
        }

    }



}
