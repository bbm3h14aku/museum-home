using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using API;

public class MuseumController
{
    public const int Default = 1;
    private Museum museum;

    public static Museum Load(int id)
    {
        if (id > 0)
        {
            APIClient clt = new APIClient("http://localhost/api/museum.php");
            clt.SetKey("sd");
            clt.SetParam("id", id.ToString());

             return JsonUtility.FromJson<Museum>(clt.Get());
        }
        throw new APIException();
    }
}      
