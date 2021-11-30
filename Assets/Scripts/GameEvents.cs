using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public event EventHandler FirstPlayDone;
    public event EventHandler BuyButton;
    public static GameEvents ge;
    void Awake()
    {
        ge = this;
    }
    void Start()
    {
        
        OnFirstPlayDone();
    }
    private void OnFirstPlayDone(){ // THIS WILL TEST IF THE GAME IS STARTED FOR THE FIRST TIME
        
        int x = PlayerPrefs.GetInt("fxpxlxdxn", 0);
        if (x == 0){
            CoinSerDes.coinSerDes.SaveCoin( new CoinData(1) );
            FirstPlayDone?.Invoke(this, EventArgs.Empty);
            PlayerPrefs.SetInt("fxpxlxdxn", 1);
        }

        
    }

    public CoinData coinData;
    public string strList;
    public void Purchase(){
        
        
        Debug.Log("Item to be Serialized: " + strList);
        

        List<string> spriteNameList = SkinListBinarySerDes.skinListBinarySerDes.DesNameList();
        Debug.Log("Add item: " + strList);
        spriteNameList.Add(strList);
        Debug.Log("Skin added: " + strList);
        PlayerPrefs.SetInt(strList,1);
        CoinSerDes.coinSerDes.SaveCoin(coinData);
        SkinListBinarySerDes.skinListBinarySerDes.SerNameList(spriteNameList);
        BuyButton?.Invoke(this, EventArgs.Empty);
    }
    
}
