using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private bool inst = false;
    public BoxCollider2D boxCol;
    public SpriteRenderer sp;
    public Transform player;
    public ParticleSystem particle;
    AudioManager audioManager;
    void Start(){
        sp.color = new Color(0f,1f,0f,0.1f);
        Debug.Log(sp.color);
        boxCol.isTrigger = true;
        Vector3 checkpointScale = transform.localScale;
        var sh = particle.shape;
        sh.scale = checkpointScale;
        audioManager  = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }
  
    void Update(){
        if(inst == false && player.position.y > transform.position.y){
            sp.color = new Color(0f,1f,0f,1f);
            boxCol.isTrigger = false;
            var poof = Instantiate(particle,transform.position,Quaternion.identity);
            audioManager.PlaySound("Checkpoint");
            inst = true;
        }
    }
    
}
