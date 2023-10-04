using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    [CreateAssetMenu(menuName = "MyData/Buff/DamageReduceBuff")]
    public class DamageReduceBuffSO : BuffSO
    {
        public List<float> decreaseValue = new List<float>();
    }
}