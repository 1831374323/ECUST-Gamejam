using EcustGamejam;
using FightingScene.UnitSystem;
using UnityEngine;

namespace FightingScene.SkillSystem.SpellSkill.Passive
{
    [CreateAssetMenu(fileName = "PassiveSpellSkillChicken",menuName = "ScriptableObject/Skill/SpellSkill/Passive/Chicken",order = 0)]
    public class PassiveSpellSkillChicken : SkillBase
    {
        [Tooltip("敌人原先的速度")] private int m_EnemyPastSpeed;
        /// <summary>
        /// 降低敌人30%攻击速度（计算方式为原速度乘以0.7）并将敌人攻击力削弱为原先的0.8
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        public override void SkillApply(UnitMono player,UnitMono enemy)
        {
            Debug.Log("这是" + this.m_name + "的调用技能：降低敌人30%攻击速度（计算方式为原速度乘以0.7）并将敌人攻击力削弱为原先的0.8");
            m_EnemyPastSpeed = enemy.speed;
            enemy.speed = Mathf.RoundToInt((float)(enemy.speed * 0.7));
        }
        
        /// <summary>
        /// 还原敌人速度
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        public override void SkillDisable(UnitMono player,UnitMono enemy)
        {
            Debug.Log("这是" + this.m_name + "的停止调用技能");
            enemy.speed = m_EnemyPastSpeed;
        }
    }
}
