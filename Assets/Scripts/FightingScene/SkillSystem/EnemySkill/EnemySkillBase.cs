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
            FightingUIManager.Instance.UpDateBehaviourText($"µ–»À Õ∑≈¡À{m_name}");
        }

        public virtual void SkillDisable(UnitMono skillUser, UnitMono target)
        {

        }
    }
}