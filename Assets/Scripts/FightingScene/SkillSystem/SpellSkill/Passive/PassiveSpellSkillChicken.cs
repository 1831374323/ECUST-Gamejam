using EcustGamejam;
using FightingScene.UnitSystem;
using UnityEngine;

namespace FightingScene.SkillSystem.SpellSkill.Passive
{
    [CreateAssetMenu(fileName = "PassiveSpellSkillChicken",menuName = "ScriptableObject/Skill/SpellSkill/Passive/Chicken",order = 0)]
    public class PassiveSpellSkillChicken : SkillBase
    {
        [Tooltip("敌人原先的速度")] private int m_EnemyPastSpeed;
        [Tooltip("敌人原先的增伤系数")] private float m_DecreaseValue;
        
        /// <summary>
        /// 降低敌人30%攻击速度（计算方式为原速度乘以0.7）并将敌人攻击力削弱为原先的0.8
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        public override void SkillApply(UnitMono player,UnitMono enemy)
        {
            FightingUIManager.Instance.UpDateBehaviourText(this.m_name + "的技能触发：降低敌人30%攻击速度，并将敌人攻击削弱为原先的0.8");
            m_EnemyPastSpeed = enemy.speed;
            enemy.speed = Mathf.RoundToInt((float)(enemy.speed * 0.7));
            //计算改变的敌人速度
            m_EnemyPastSpeed = m_EnemyPastSpeed - enemy.speed;

            m_DecreaseValue = enemy.decreaseValue;
            enemy.decreaseValue*=0.8f;
            m_DecreaseValue = m_DecreaseValue - enemy.decreaseValue;
        }
        
        /// <summary>
        /// 还原敌人速度
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        public override void SkillDisable(UnitMono player,UnitMono enemy)
        {
            FightingUIManager.Instance.UpDateBehaviourText(this.m_name + "的技能停止");
            //还原敌人速度
            enemy.speed += m_EnemyPastSpeed;
            enemy.decreaseValue += m_DecreaseValue;
        }
    }
}
