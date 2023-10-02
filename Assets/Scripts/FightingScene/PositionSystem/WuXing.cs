using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    [CreateAssetMenu(fileName = "WuXing", menuName = "MyData/WuXing")]
    public class WuXing : ScriptableObject
    {
        public int id;
        public string m_name;
        public int counterID;
        public int counteredID;

    }
}