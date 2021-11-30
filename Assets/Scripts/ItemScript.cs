using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using System;

public class ItemScript : MonoBehaviour
{
    public static ItemScript itemScript;
    public GameObject confirmPurchase;
    public string skinName;
    public int itemPrice;
    int currentMoney;
    public Text priceText;
    public Button button;
    public CoinSerDes csb;
    public SkinListBinarySerDes slsb;
    void Awake(){
        itemScript = this;
        GameEvents.ge.BuyButton += Transact;
        
    }
    void Start(){
        
        priceText.text = itemPrice.ToString();
        LockItem();
      
    }
    public void LockItem(){
        if (PlayerPrefs.GetInt(skinName,0) == 1){
            ///Disable Button and change text
            button.enabled = false;
            priceText.text = "PURCHASED";
        }
    }
    public void Transact(object o, EventArgs e){
        if (PlayerPrefs.GetInt(skinName,0) == 1){
            ///Disable Button and change text
            button.enabled = false;
            priceText.text = "PURCHASED";
        }
        
    }/*
    public void Purchase(){
        PlayerPrefs.SetInt(skinName,1);
        List<string> spriteNameList = slsb.DesNameList() as List<string>;
        Debug.Log("Old List: "+spriteNameList);
        Debug.Log("Add item: " + skinName);
        spriteNameList.Add(skinName);
        Debug.Log("New List: "+spriteNameList);

        slsb.SerNameList(spriteNameList);

        

    }*/
    public void Buy(){
        CoinData coinData = csb.LoadCoin();
        Debug.Log("Money Extracted was: "+ coinData.coinAmount);
        Debug.Log("Item Price is: " + itemPrice);
        int currentMoney = coinData.coinAmount;
        currentMoney -= itemPrice;
        Debug.Log("The remaining amount: " + currentMoney);
        coinData.coinAmount = currentMoney;
        if (currentMoney >= 0){
        
        GameEvents.ge.coinData = coinData;
        GameEvents.ge.strList = skinName;
        confirmPurchase.SetActive(true);
       } else {
           // Code for Not enough Coins
       }
        

        
        }
        
    
}
