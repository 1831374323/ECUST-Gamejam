using UnityEngine;

namespace FightingScene.SpellSystem
{
    /// <summary>
    /// 猪符咒
    /// </summary>
    [CreateAssetMenu(fileName = "Spell_Pig",menuName = "ScriptableObject/Spell/Spell_Pig")]
    public class Spell_pig : Spells
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
    }
}
