using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    private LayerMask surfaceLayer;
    private Transform currentBuilding;
    private Camera myCamera;

    // Start is called before the first frame update
    void Start()
    {
        myCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( currentBuilding != null )
        {
            // Aktuellen Ray von der Kamera abholen. Basis ist die Maus Position
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if ( Physics.Raycast(ray, out hit, Mathf.Infinity) ) {
                currentBuilding.position = hit.point;
            }

            if ( Input.GetMouseButtonDown(1))
            {
                currentBuilding = null;
            }
        }
    }

    public void SetCurrentBuilding(GameObject currentBuilding)
    {
        this.currentBuilding = ((GameObject) Instantiate(currentBuilding)).transform;

    }
}
