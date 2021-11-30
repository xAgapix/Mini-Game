using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollected : MonoBehaviour
{
    public CircleCollider2D cCol;
    public GameObject deathParticle;
    
    void OnTriggerEnter2D(Collider2D col){
        Destroy(gameObject);
        GameObject dp = Instantiate(deathParticle,transform.position,Quaternion.identity);
    }
}
