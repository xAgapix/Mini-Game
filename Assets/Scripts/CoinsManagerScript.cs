using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManagerScript : MonoBehaviour
{
    public Text coinText;
    int coinsCollected;
    
    public static int cc;
    void Start(){
        coinsCollected = 0;
    }
    void Update(){
        
        coinText.text = coinsCollected.ToString();
    }
    public void CoinCalculate(int coins){
        coinsCollected += coins;
        cc = coinsCollected;
    }
    
}
