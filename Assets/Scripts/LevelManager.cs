using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LevelManager : MonoBehaviour
{
    
    string coinStoragePath;
    int currentMoney;
    
    int currentLevel;
    string lvlString;
    public GameObject[] levels;
    GameObject spawnLevel;
    GameObject nextLevel;
    int levelIndex;
    public Text lvlText;
    void OnApplicationFocus(bool focus){
        if (!focus){
            PlayerPrefs.SetInt("mna",1);
        }
    }
    void OnApplicationQuit(){
        
            PlayerPrefs.SetInt("mna",1);
        
    }
    void OnApplicationPause(bool paused){
        if (paused){
            Debug.Log("GamePaused");
            PlayerPrefs.SetInt("mna",1);
        }
    }
    void Awake(){
        currentLevel = PlayerPrefs.GetInt("cl",0);
        Debug.Log(levels.Length);

        
        coinStoragePath = Application.persistentDataPath + "/cnDt.bin";
        
        
    }
    void Start(){
        levelIndex = PlayerPrefs.GetInt("cl");
        int menuActive = PlayerPrefs.GetInt("mna",1);
         if (PlayerPrefs.GetInt("cl") < levels.Length && menuActive == 0) {
            spawnLevel = Instantiate(levels[currentLevel]) as GameObject;
            lvlText.text = "Level "+(1+levelIndex).ToString();
         }
         
         
    }

    public void Home(){
        PlayerPrefs.SetInt("mna",1);
        SceneManager.LoadScene(0);
    }
    public void Restart(){
        PlayerPrefs.SetInt("cl",levelIndex);
        PlayerPrefs.SetInt("mna",0);
        if (PlayerPrefs.GetInt("cl") < levels.Length){
        SceneManager.LoadScene(1);
        }
        else{
        SceneManager.LoadScene(0);
        Debug.Log("Max Level Reached");
    }
    }
    public void Next(){

        
        PlayerPrefs.SetInt("mna",0);
        if (PlayerPrefs.GetInt("cl") < levels.Length){
        SceneManager.LoadScene(1);
        }
        else{
        PlayerPrefs.SetInt("mna",1);
        SceneManager.LoadScene(0);
        Debug.Log("Max Level Reached");
    }
    }
}