using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace API {
    [System.Serializable]
    public class APIObject
    {
        public string Get()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
