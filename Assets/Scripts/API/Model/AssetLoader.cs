using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetLoader : MonoBehaviour
{
    public GameObject[] buildIn;
    public GameObject[] buildEx;

    public int GetBuildInCount()
    {
        return buildIn.Length;
    }

    public GameObject GetBuildIn(string tag)
    {
        for ( int i = 0; i < GetBuildInCount(); i++ )
        {
            if ( buildIn[i].tag == tag )
            {
                return buildIn[i];
            }
        }

        return null;
    }
}
