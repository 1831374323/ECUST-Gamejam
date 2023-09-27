using UnityEngine;

namespace FightingScene.CoinSystem
{
    public class Coin : MonoBehaviour
    {

        public int id = -1;
        public bool statu = true;
        public bool isChosen = true;

        public void DoRandom()
        {
            int _result = Random.Range(0, 2);
            if (_result == 0)
            {
                statu = false;
            }
            else
            {
                statu = true;
            }
        }

    }
}
