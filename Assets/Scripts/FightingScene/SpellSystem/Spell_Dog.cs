using UnityEngine;

namespace FightingScene.SpellSystem
{
    /// <summary>
    /// 狗符咒
    /// </summary>
    [CreateAssetMenu(fileName = "Spell_Dog",menuName = "ScriptableObject/Spell/Spell_Dog",order = 1)]
    public class Spell_Dog : Spells
    {
        public override void Skill()
        {
            base.Skill();
            Debug.Log("这是" + id + "号" + this.name + "的技能：" + description);
        }
        public override void KillSkill()
        {
            base.KillSkill();
            Debug.Log("这是" + id + "号" + this.name + "的技能结束");
        }
        public override void MotiveSkill()
        {
            base.MotiveSkill();
            Debug.Log("这是" + id + "号" + this.name + "的主动技能：");
        }
        
        public override void KillMotiveSkill()
        {
            base.KillMotiveSkill();
            Debug.Log("这是" + id + "号" + this.name + "的主动技能结束");
        }
    }
}
