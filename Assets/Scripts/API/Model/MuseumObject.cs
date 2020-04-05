using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace API
{
    public class MuseumObject
    {
        public int id { get; set; }
        public string label { get; set; }
        public string author { get; set; }
        public ElementObject[] elements { get; set; }
    }
}
