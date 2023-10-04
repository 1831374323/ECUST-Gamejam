using UnityEngine;

namespace FightingScene.UnitSystem
{
    public class UnitMono : MonoBehaviour
    {
        [Tooltip("人物名")] public string unitName;

        [Tooltip("人物最大血量")] public int maxHp;
        [SerializeField, Tooltip("人物当前血量")] private int currentHp;
        public int CurrentHp { get { return currentHp; } }
        
        [Tooltip("人物当前蓝量")] public int maxMp;
        [SerializeField, Tooltip("人物当前蓝量")] private int currentMp;
        public int CurrentMP { get { return currentMp; } }
        [Tooltip("人物蓝量恢复值")] public int cureMp;

        [Tooltip("人物速度值")] public int speed;

        [Tooltip("人物暴击率")] public float criticalHitRate;
        [Tooltip("人物暴击倍率")] public float criticalStrikeRate;

        [Tooltip("人物当前卦位")] public int currentPosition;
        
        [Tooltip("人物当前护盾值")] public int shield;

        /// <summary>
        /// 设置血量函数
        /// </summary>
        /// <param name="x">传入的是修改量，增加就是正数，减少就是负数</param>
        /// <returns>返回false就是没血死掉了，true就是成功设置</returns>
        public bool SetHp(int x)
        {
            if (x >= 0)//回血
            {
                currentHp += x;
                currentHp = (currentHp < maxHp) ? currentHp : maxHp;//防止治疗血量溢出
                Debug.Log("回血" + x);
            }
            else//扣血
            {
                if (currentHp + shield + x < 0)//先判断血量够不够
                {
                    return false;
                }
                else
                {
                    if (shield >= x)//先扣护盾
                    {
                        shield += x;
                    }
                    else 
                    { 
                        currentHp = currentHp + shield + x;
                        shield = 0;
                    }
                }
                Debug.Log("扣血" + x);
            }
            return true;
        }

        /// <summary>
        /// 设置蓝量函数
        /// </summary>
        /// <param name="x">传入的是修改量，增加就是正数，减少就是负数</param>
        /// <returns>返回false就是没蓝了，true就是成功设置</returns>
        public bool SetMp(int x)
        {
            if (currentMp + x < 0)//先判断蓝量够不够
            {
                return false;
            }
            currentMp += x;
            currentMp = (currentMp < maxMp) ? currentMp : maxMp;//防止回蓝溢出
            return true;
        }
        
        /// <summary>
        /// 返回每次造成的伤害
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="hpValue"></param>
        /// <param name="shieldValue"></param>
        public void GetComingDamage(int damage, out int hpValue, out int shieldValue)
        {
            hpValue = 0;
            if (this.shield > damage)
            {
                shieldValue = damage;
            }
            else
            {
                shieldValue = this.shield;
                hpValue = damage - this.shield;
            }
        }

    }
}
