using FightingScene.UnitSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    public class PositionSkill : ScriptableObject
    {

        public string m_name;
        public string describe;

        public List<int> MpCost = new List<int>();

        /// <summary>
        /// skillUserΪ�ͷ��ߣ�targetΪ���ͷ��ߣ����Ǽ������ö���;level=���ܽ׼�(0,1,2)
        /// </summary>
        /// <param name="skillUser"></param>
        /// <param name="target"></param>
        /// <param name="level"></param>
        public virtual void SkillApply(UnitMono skillUser, UnitMono target, int level)
        {
            

        }

        public virtual void SkillDisable(UnitMono skillUser, UnitMono target, int level)
        {

        }

    }
}