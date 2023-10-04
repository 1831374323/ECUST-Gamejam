using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    [CreateAssetMenu(menuName = "MyData/Buff/GetMpBuff")]
    public class GetMpBuffSO : BuffSO
    {
        public List<int> probability = new List<int>();
        public int extraMpCure;
    }
}