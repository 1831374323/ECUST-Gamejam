using FightingScene.UnitSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkillBase : ScriptableObject
{
    public string m_name;
    public virtual void SkillApply(UnitMono skillUser, UnitMono target)
    {

    }

    public virtual void SkillDisable(UnitMono skillUser, UnitMono target)
    {

    }
}
