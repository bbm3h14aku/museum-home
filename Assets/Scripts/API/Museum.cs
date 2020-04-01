using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using API;
using System;

[System.Serializable]
public class Museum : APIObject
{
    private int id;
    private string label;
    private List<string> rooms;

    public Museum(int id, string label, List<string> rooms)
    {
        this.id = id;
        this.label = label;
        this.rooms = rooms;
    }
}
