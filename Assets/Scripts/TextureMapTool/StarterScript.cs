using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterScript : MonoBehaviour
{
    public GameObject sphere;
    private SphereButtonEvent sphereButtonEvent;

    public GameObject saveManagerObj;
    private SaveManager saveManager;

    // Start is called before the first frame update
    void Start()
    {
        saveManager = saveManagerObj.GetComponent<SaveManager>();
        sphereButtonEvent = sphere.GetComponent<SphereButtonEvent>();
        sphereButtonEvent.saveManager = saveManager;

        saveManager.import();
        sphereButtonEvent.loadTexture(sphereButtonEvent.textureName);
        //sphereButtonEvent.loadButtons(saveManager.loadButtons(sphereButtonEvent.textureName));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
