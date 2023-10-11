using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    [CreateAssetMenu(menuName = "MyData/Skill/XunAtk")]
    public class XunAtkSkill : PositionAtkSkill
    {
        [SerializeField]
        List<int> atkValue = new List<int>();
        public List<int> probability = new List<int>();


        public GetMpBuffSO getMpBuffSO;
        protected override float GetAtkValue(int level)
        {
            GetMpBuff getMpBuff = new GetMpBuff(getMpBuffSO);

            if (Random.Range(0, 100) < probability[level])
            {
                getMpBuff.AddBuff(m_skillUser, level);
            }

            Debug.Log($"Ùã½øÐÐ{level}½×¹¥»÷");
            return atkValue[level];
        }

    }
}
