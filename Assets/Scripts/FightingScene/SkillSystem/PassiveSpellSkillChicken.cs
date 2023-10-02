using EcustGamejam;
using UnityEngine;

namespace FightingScene.SkillSystem
{
    [CreateAssetMenu(fileName = "PassiveSpellSkillChicken",menuName = "ScriptableObject/Skill",order = 0)]
    public class PassiveSpellSkillChicken : SkillBase
    {
        public override void SkillApply()
        {
            Debug.Log("这是" + this.m_name + "的调用技能：");
        }
        public override void SkillDisable()
        {
            Debug.Log("这是" + this.m_name + "的停止调用技能：");
        }
        
    }
}
