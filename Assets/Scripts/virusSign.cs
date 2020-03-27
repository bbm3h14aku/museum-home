using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusSign : MonoBehaviour
{

    public GameObject paperPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void OnMouseDown()
    {
        Debug.Log("mouse click detected");
         for ( int i = 1; i <= 20; i++)
        {
            Instantiate(paperPrefab, new Vector3(transform.position.x, transform.position.y + 5 *i, transform.position.z), Quaternion.identity);
        }  
         
    }*/

     void OnMouseOver()
    {
        Debug.Log("mouse click detected");
        if (Input.GetMouseButtonDown(1))
         {
            for ( int i = 1; i <= 20; i++)
            {
                Instantiate(paperPrefab, new Vector3(transform.position.x, transform.position.y + 5 *i, transform.position.z), Quaternion.identity);
            }   
         }            
    }

    


}
