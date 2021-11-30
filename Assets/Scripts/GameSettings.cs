using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    private static readonly string firstPlay = "fp";
    private static readonly string gamePP = "gv";
    private static readonly string sfxPP = "se";
    int firstP;
    float bgVolume,sfxVolume;
    public Slider gameSlider,sfxSlider; 
    void Start(){
        bgVolume = PlayerPrefs.GetFloat(gamePP,0.5f);
        sfxVolume = PlayerPrefs.GetFloat(sfxPP,0.7f);

        
        
        gameSlider.value = bgVolume;
        sfxSlider.value = sfxVolume;
    }
    //This function is gets the saved volume from the last saved option of run time. If the game is first played,
    //It gets the default volume value.
    void Update(){
      //  firstP = PlayerPrefs.GetInt(firstPlay,0);
       /* if (firstP == 0){
          //  gV = 0.5f;
           // sV = 0.7f;
            PlayerPrefs.SetFloat(gamePP,gV);
            PlayerPrefs.SetFloat(sfxPP,sV);
            PlayerPrefs.SetInt(firstPlay,1);
        }else{*/
            PlayerPrefs.SetFloat(gamePP,bgVolume);
            PlayerPrefs.SetFloat(sfxPP,sfxVolume);
            bgVolume=gameSlider.value;
        sfxVolume=sfxSlider.value;
            
       /* }*/
    }
}
