using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightController : MonoBehaviour
{
    public Light lightComp;
    private Color current;

    private int curr_x_rot = 20;
    public static int max_x_rot = 40;
    public static int min_x_rot = -7;

    private int curr_y_rot = -85;
    private int max_y_rot = 10;
    private int min_y_rot = -85;

    private bool move_back_x = false;
    private bool move_back_y = false;

    private int fc = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Add the light component
        //Light lightComp = lightObject.AddComponent<Light>();
        lightComp = gameObject.GetComponent<Light>();

        // Set color and position
        lightComp.color = Color.blue;

        // change type to spot
        lightComp.type = LightType.Spot;

        // change spot angle size
        lightComp.spotAngle = 40;

        // set Intensity
        lightComp.intensity = 5;

        // set range
        lightComp.range = 150;

        // Set the position (or any transform property)
        gameObject.transform.position = gameObject.transform.position;
        gameObject.transform.rotation = Quaternion.Euler(20, -85, 0);
    }

    void moveOnX()
    { 
        if (fc == 5)
        {
            if ( move_back_x == false)
            {
                curr_x_rot--;
                if ( curr_x_rot == min_x_rot )
                {
                    move_back_x = true;
                }
            }
            else
            {
                if ( move_back_x == true )
                {
                    curr_x_rot++;
                    if (curr_x_rot == max_x_rot)
                    {
                        move_back_x = false;
                    }
                }
            }
        }
    }

    void moveOnY()
    {
        if ( fc == 3)
        {
            if ( move_back_y == false )
            {
                curr_y_rot++;
                if ( curr_y_rot == max_y_rot )
                {
                    move_back_y = true;
                }
            }
            else
            {
                if ( move_back_y == true )
                {
                    curr_y_rot--;
                    if ( curr_y_rot == min_y_rot )
                    {
                        move_back_y = false;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        fc++;
        moveOnX();
        moveOnY();
        gameObject.transform.rotation = Quaternion.Euler(curr_x_rot, curr_y_rot, 0);
        Debug.Log("moving spot light: " + curr_x_rot);

        if ( fc == 5)
        { 
            fc = 0;
        }
    }
}
