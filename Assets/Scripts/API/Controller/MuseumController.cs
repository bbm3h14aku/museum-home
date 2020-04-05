using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace API
{ 
    public class MuseumController
    {
        public const int Default = 1;
        private Museum museum;

        public static Museum Load(int id)
        {
            if (id >= 0)
            {
                APIClient clt = new APIClient("http://localhost/api/museum.php");
                clt.SetKey("sd");
                clt.SetParam("id", id.ToString());
                string json = clt.Get();
                Debug.Log(json);
                return JsonUtility.FromJson<Museum>(json);
            }
            return null;
        }

        public static void Create(Museum museum)
        {
            if (museum != null)
            {
                APIClient clt = new APIClient("http://localhost/api/museum.php");
                clt.SetKey("sd");
                clt.Post((APIObject) museum);
            }
        }
    }
}      
