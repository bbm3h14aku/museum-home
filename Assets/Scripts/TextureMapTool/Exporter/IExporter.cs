using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    T is the type of the container
*/
public interface IExporter<T> {
    void export(T table, string path);
    T import(string path);
} 