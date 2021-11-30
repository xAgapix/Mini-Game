using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text countTExt;
    public PlayerMovement player;
    public EnemyAI[] enem;
    public GameObject countPanel;
    float countTime = 3.5f;
    AudioManager audioManager;
    int secondsLeft = 3;
    private bool decreasing = false;
    void Awake(){
        audioManager  = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }
    void Start(){
        //Disable the EnemyAI and PlayMovement script because there is still a countdown
        for (int i = 0; i < enem.Length; i++ ){
                enem[i].enabled = false;
            }
        player.enabled = false; 
        countTExt.text = secondsLeft.ToString();
    }
    void Update()
    {
        //This will be the countdown and when it's done, the EnemyAI and PlayerMovement script will be eneabled again
        if(decreasing == false && secondsLeft >= -1){
            StartCoroutine(Timer());
        } else if (secondsLeft <= 0){
            
            for (int i = 0; i < enem.Length; i++ ){
                enem[i].enabled = true;
            }
            
        player.enabled = true; 
        countPanel.SetActive(false);
        }
      

    }
    IEnumerator Timer(){
        
        decreasing = true;
        
        
        
        if (secondsLeft > 0){
            
        audioManager.PlaySound("Countdown");
        countTExt.text = secondsLeft.ToString();
        }else{
        audioManager.PlaySound("Beep");
        

        }
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        
        decreasing = false;
    }
}
