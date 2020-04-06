using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementController : MonoBehaviour
{
    public int id;
    public string type;
    public bool editable;

    public float xPos;
    public float yPos;
    public float zPos;

    public float x_angle;
    public float y_angle;
    public float z_angle;

    public List<ElementController> childs;

    public API.ElementObject GetElementObject()
    {
        API.ElementObject obj = new API.ElementObject();
        obj.type = this.type;
        obj.pos_x = this.xPos;
        obj.pos_y = this.yPos;
        obj.pos_z = this.zPos;
        obj.rot_x = this.x_angle;
        obj.rot_y = this.y_angle;
        obj.rot_z = this.z_angle;

        return obj;
    }

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

    public void addChild(ElementController childController)
    {
        this.childs.Add(childController);
    }

    public ElementController getChild(int idx)
    {
        return this.childs[idx];
    }
}
