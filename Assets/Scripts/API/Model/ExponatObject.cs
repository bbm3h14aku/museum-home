using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace API
{
    public class ExponatObject : ElementObject
    {
        public string label { get; set; }
        public string exponat { get; set; }
        public string description { get; set; }
        public string tag { get; set; }
        public string imageurl { get; set; }

        public float pos_x { get; set; }
        public float pos_y { get; set; }
        public float pos_z { get; set; }

        public float angle_x { get; set; }
        public float angle_y { get; set; }
        public float angle_z { get; set; }

        public Vector3 GetPosition()
        {
            return new Vector3(pos_x, pos_y, pos_z);
        }

        public Quaternion GetRotation()
        {
            return Quaternion.Euler(angle_x, angle_y, angle_z);
        }
    }
}