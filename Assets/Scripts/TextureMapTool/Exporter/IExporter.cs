using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExporter<T> {
    void export(T table, string path);
    T import(string path);
} 