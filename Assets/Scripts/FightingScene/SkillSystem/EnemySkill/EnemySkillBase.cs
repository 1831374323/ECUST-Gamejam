using FightingScene.UnitSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    public class EnemySkillBase : ScriptableObject
    {
        public string m_name;
        public virtual void SkillApply(UnitMono skillUser, UnitMono target)
        {
            FightingUIManager.Instance.UpDateBehaviourText($"敌人释放了{m_name}");
        }

        public virtual void SkillBuffedApply(UnitMono skillUser, UnitMono target)
        {
            FightingUIManager.Instance.UpDateBehaviourText($"敌人处在强化卦位，释放了{m_name}，效果翻倍！！！");
        }

        public virtual void SkillDisable(UnitMono skillUser, UnitMono target)
        {

        }
    }
}