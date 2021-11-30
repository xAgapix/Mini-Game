using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RaceRank : MonoBehaviour
{ 
   public List <Transform> balls;
   public Transform player;
   public Transform finishLine;
   public Text rankText;
   float[] distance;
   float playerDistance;
   int rank = 0;
   void Start(){
    
     balls.Add(player);
   }
   void Update(){
        

     for (int i = 0; i<balls.Count; i++){
            for (int j = i + 1; j<balls.Count; j++){
                if (Vector3.Distance(balls[j].position,finishLine.position) < Vector3.Distance(balls[i].position,finishLine.position)){
                    Transform temp = balls[i];
                    balls[i] = balls[j];
                    balls[j] = temp;
                }
            }
        }
        int index = balls.IndexOf(player) + 1;
        switch (index){
            case 1:
                rankText.text = index.ToString() + "ST";
                break;
            case 2:
                rankText.text = index.ToString() + "ND";
                break;
            case 3:
                rankText.text = index.ToString() + "RD";
                break;
            default:
                rankText.text = index.ToString() + "TH";
                break;
        }
        
   }
}
