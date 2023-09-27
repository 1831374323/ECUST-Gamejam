using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcustGamejam
{
    public class CoinManager : SingletonBase<CoinManager>
    {
        [SerializeField]
        public List<GameObject> coinList = new List<GameObject>();

        void Start()
        {
            //RollChosenCoins();
        }


        void Update()
        {

        }

        public void RollChosenCoins()
        {
            foreach (GameObject obj in coinList)
            {
                Coin coin = obj.GetComponent<Coin>();

                if (coin.isChosen)
                {
                    coin.DoRandom();
                    coin.isChosen = false;
                }
            }
        }

        private void DoCoinEffect()
        {

        }


    }


}