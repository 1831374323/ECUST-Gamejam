using EcustGamejam;
using FightingScene.UnitSystem;
using UnityEngine;

namespace FightingScene.SkillSystem.SpellSkill.Passive
{
    [CreateAssetMenu(fileName = "PassiveSpellSkillPig",menuName = "ScriptableObject/Skill/SpellSkill/Passive/Pig",order = 4)]

    public class PassiveSpellSkillPig : SkillBase
    {
        public override void SkillApply(UnitMono player,UnitMono enemy)
        {
            Debug.Log("这是" + this.m_name + "的调用技能：技能释放前生效 ，即优先级高于双方技能释放，先回复生命双方再释放技能");
            player.SetHp(10);
        }
        public override void SkillDisable(UnitMono player,UnitMono enemy)
        {
            Debug.Log("这是" + this.m_name + "的停止调用技能：");
        }
    }
}
