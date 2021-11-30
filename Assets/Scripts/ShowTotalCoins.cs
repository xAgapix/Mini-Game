using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ShowTotalCoins : MonoBehaviour
{
    public static ShowTotalCoins stc;

    public Text coinText;
    public CoinSerDes csd;
    public GameEvents gameEvents;
    void Awake(){
        stc = this;
        gameEvents.FirstPlayDone+=SubscriberShow;
    }
    void Start(){
    
        ShowCoinAmount();
        
        
    }
    void Update()
    {
    }
   public void ShowCoinAmount(){
        
        CoinData coinData = csd.LoadCoin();
        int temp = coinData.coinAmount;
        coinText.text = temp.ToString();
        Debug.Log("Total Money Amount: " + temp);
    }
    public void SubscriberShow(object ob,EventArgs ea){
        CoinData coinData = csd.LoadCoin();
        int temp = coinData.coinAmount;
        coinText.text = temp.ToString();
        Debug.Log("Total Money Amount: " + temp);
    }
}
