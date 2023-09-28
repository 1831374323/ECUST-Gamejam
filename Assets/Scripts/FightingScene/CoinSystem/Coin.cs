using UnityEngine;
using UnityEngine.UI;

namespace FightingScene.CoinSystem
{
    
    public class Coin : MonoBehaviour
    {
        [Tooltip("硬币的id")] public int id = -1;
        [Tooltip("硬币的正反，ture为正")] public bool statu = true;
        [Tooltip("硬币是否被选择")] public bool isChosen = true;
        [Tooltip("硬币文本")] public Text coinText;

        /// <summary>
        /// 投掷硬币，返回0为反，返回1为正
        /// </summary>
        public void DoRandom()
        {
            int result = Random.Range(0, 2);//返回0或者1
            statu = (result != 0); 
        }
        /// <summary>
        /// 选择或者不选钱币，不选择图片就会暗淡
        /// </summary>
        public void RevertThisCoin()
        {
            this.isChosen = !this.isChosen;
            float lighta = !this.isChosen ? 0.5f : 1f;
            this.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, lighta);
        }
    }
}
