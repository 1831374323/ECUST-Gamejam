using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    [CreateAssetMenu(menuName ="MyData/Skill/QianAtk")]
    public class QianAtkSkill : PositionAtkSkill
    {
        public int value;
        protected override float GetAtkValue()
        {
            Debug.Log("Ǭ���й���");
            return value;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}