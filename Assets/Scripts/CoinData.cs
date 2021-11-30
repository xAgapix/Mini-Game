using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CoinData{

 [HideInInspector]
 public int coinAmount;
 
 public CoinData(int coinInput){
     this.coinAmount = coinInput;
 }

}
