using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using API;

public class Reset : MonoBehaviour
{
    private APIClient client;

    private void createDefauklt()
    {
        ElementObject[] array = new ElementObject[2];
        array[0] = new ElementObject();
        array[0].id = 0;
        array[0].type = "hall";
        array[0].pos_x = 0;
        array[0].pos_y = 0;
        array[0].pos_z = 0;
        array[0].rot_x = 0;
        array[0].rot_y = 0;
        array[0].rot_z = 0;

        array[1] = new ElementObject();
        array[1].id = 1;
        array[1].type = "hall";
        array[1].pos_x = 5.35f;
        array[1].pos_y = 0;
        array[1].pos_z = 0;
        array[0].rot_x = 0;
        array[0].rot_y = 0;
        array[0].rot_z = 0;

        MuseumObject m = new MuseumObject();
        m.id = 0;
        m.label = "demo";
        m.author = "jan";
        m.elements = array;

        string json = JsonConvert.SerializeObject(m);
        Debug.Log(json);
        this.client = new APIClient("http://localhost/api/museum.php");
        this.client.SetKey("sd");
        this.client.SetParam("id", 0);
        this.client.Post(json);

        ExponatObject[] expoants = new ExponatObject[1];
        expoants[0] = new ExponatObject();
        expoants[0].id = 0;
        expoants[0].label = "demoExponat";
        expoants[0].pos_x = 0.18f;
        expoants[0].pos_y = 0.222f;
        expoants[0].pos_z = 0.05f;
        expoants[0].rot_x = 0;
        expoants[0].rot_y = 0;
        expoants[0].rot_z = 0;
        expoants[0].description = "Das ist eine Beschreibung zu dem Würfel. Der Würfel ist blau und hat die Maße 1x1x1 Einheit";
        expoants[0].exponat = "testbundle";

        json = JsonConvert.SerializeObject(expoants);
        this.client = new APIClient("http://localhost/api/exponat.php");
        this.client.SetKey("sd");
        this.client.SetParam("id", 0);
        this.client.Post(json);
    }
    // Start is called before the first frame update
    void Start()
    {
        this.createDefauklt();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
