using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementController : MonoBehaviour
{
    public int id;
    public bool editable;

    public float xPos;
    public float yPos;
    public float zPos;

    public float x_angle;
    public float y_angle;
    public float z_angle;

    public void moveOnZ(float zPos)
    {
        this.zPos = zPos;
        this.move();
    }

    public void moveOnX(float xPos)
    {
        this.xPos = xPos;
        this.move();
    }

    public void rotate(float angle)
    {
        this.x_angle = angle;
        this.move();
    }

    void Update()
    {
        this.xPos = this.gameObject.transform.position.x;
        this.yPos = this.gameObject.transform.position.y;
        this.zPos = this.gameObject.transform.position.z;
    }

    private void move()
    {
        this.gameObject.transform.position = new Vector3(this.xPos, this.yPos, this.zPos);
        this.gameObject.transform.rotation = Quaternion.Euler(this.x_angle, this.y_angle, this.z_angle);
    }

    void OnMouseDown()
    {
        Debug.Log("trigger " + this.id);
    }
}
