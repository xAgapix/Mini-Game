using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class BallSelectionSystem : MonoBehaviour
{
    public SkinDatabase skinDatabase;
    public SpriteRenderer menuBall;
    public GameObject player;
    SpriteRenderer playerSprite;
    int selNum;
     private string selectedSkinIndex = "ssi";
    public GameEvents ge;
    bool fpl;
    public SkinListBinarySerDes slsb;
    private List<string> extractedNameList = new List<string>();
    void SkinSelection(){
        extractedNameList = slsb.DesNameList() as List<string>;
        if(extractedNameList.Count <= 0 || extractedNameList == null){
            // Pass
        } else {
        string selectedSkin = extractedNameList[selNum];
        SpriteData spriteData = skinDatabase.SelectSkinAt(selectedSkin);
        Debug.Log("Skin Name Selected: " + spriteData.skin_Name);
        
        playerSprite.sprite = spriteData._sprite;
        if (menuBall == null){
            //pass
        }else {
        menuBall.sprite = spriteData._sprite;}
        }
        
        
    }
    void TestFirstPlay(object ob, EventArgs e){

            List <string> def = new  List<string>();
            def.Add("White");
            slsb.SerNameList(def);
            ge.FirstPlayDone -= TestFirstPlay;
            //PlayerPrefs.SetString("fpldn", "true");
        
        extractedNameList = slsb.DesNameList();
        if(extractedNameList.Count <= 0 || extractedNameList == null){
            // Pass
        }
        Debug.Log("Event Executed Recently");
    }
    void Awake(){
        ge.FirstPlayDone += TestFirstPlay;
        
    }
    void Start(){
        selNum = PlayerPrefs.GetInt(selectedSkinIndex);
        playerSprite = player.GetComponent<SpriteRenderer>();
        SkinSelection();
    
    }
    
    public void NextButton(){
        selNum+=1;
        if(selNum >= extractedNameList.Count){
        selNum = 0;
        }
            SkinSelection();

    }
    public void PrevButton(){
        selNum-=1;
        if(selNum <= -1){
        selNum = extractedNameList.Count - 1;
        }
            SkinSelection();

        
    }
    public void EquipButton(){
        PlayerPrefs.SetInt("mna",1);
        PlayerPrefs.SetInt(selectedSkinIndex,selNum);
        SkinSelection();
    }
}
