using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    public void ResetLevels(){
        PlayerPrefs.SetInt("cl",0);
        Debug.LogWarning("Level Reset Successful");
    }
    public void QuitGame(){
        Application.Quit();
    }
}
