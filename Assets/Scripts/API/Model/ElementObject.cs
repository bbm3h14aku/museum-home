using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace API
{
    public class ElementObject
    {
        public int id { get; set; }
        public string type { get; set; }
        public float pos_x { get; set; }
        public float pos_y { get; set; }
        public float pos_z { get; set; }
        public float rot_x { get; set; }
        public float rot_y { get; set; }
        public float rot_z { get; set; }
        public int exponatListId { get; set; }
        public ExponatObject[] exponats { get; set;  }
        public GameObject gameObject { get; set; }
    }
}
