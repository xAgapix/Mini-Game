using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvBallMovement : MonoBehaviour
{
    public Rigidbody2D ballRB;
    float x,y;
    Vector2 poofVec;
    float countTime;

    void FixedUpdate()
    {
        x = Random.Range(-1,1);
        y = Random.Range(-1,1);
        poofVec = new Vector2(x,y) * 12f;
        
            if (countTime > 0){
            countTime -= 1* Time.deltaTime;

        }else{        
        ballRB.AddForce(poofVec,ForceMode2D.Impulse);
        countTime = 2f;
        
        }
        
    }
}
