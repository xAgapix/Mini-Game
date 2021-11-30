using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 startTouch;
    Vector3 endTouch;
    Vector3 force;
    Vector3 clampedForce;
    public GameObject arrow;
    public Transform control;
    Vector3 arrowangle;
    public Rigidbody2D rb;
    private float max = 5f, power = 3f;
    Touch touch;
    CoinsManagerScript cMan;
    AudioManager audioManager;
    void Awake(){

        audioManager  = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }
    void Start(){
       
        arrow.SetActive(false);
        cMan = GameObject.FindWithTag("CoinsManager").GetComponent<CoinsManagerScript>();
    }
    void Update()
    {
        Vector3 storeVec = transform.position;
        control.position = storeVec;
        if(Input.touchCount > 0 ){
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began){
                startTouch = Camera.main.WorldToScreenPoint(touch.position);
                startTouch.z = 0;
                
            }

            if (touch.phase == TouchPhase.Moved){
                Vector3 dragPos = Camera.main.WorldToScreenPoint(touch.position);
                  dragPos.z = 0;
                  force = dragPos - startTouch ;
                  float angle = Mathf.Atan2(force.y,force.x) * Mathf.Rad2Deg;
                  control.rotation = Quaternion.Euler(0,0,angle);
                  arrow.SetActive(true);
                 
            }
            if(touch.phase == TouchPhase.Ended){
                rb.velocity = Vector3.zero; 
                endTouch = Camera.main.WorldToScreenPoint(touch.position);
                endTouch.z = 0;

                force = endTouch- startTouch ;
                clampedForce = Vector3.ClampMagnitude(force,max)*power;
                rb.AddForce(clampedForce,ForceMode2D.Impulse);
                arrow.SetActive(false);
                audioManager.PlaySound("Fly");
            }
            //Debug.Log("Start: " + startTouch + "Ended: "+endTouch+"Clamped Force: "+clampedForce);
        }else{
              if (Input.GetMouseButtonDown(0)){
                  startTouch = Camera.main.WorldToScreenPoint(Input.mousePosition);
                startTouch.z = 0;
                
              }
              if (Input.GetMouseButton(0)){
                  
                  Vector3 dragPos = Camera.main.WorldToScreenPoint(Input.mousePosition);
                  dragPos.z = 0;
                  force = dragPos - startTouch ;
                  float angle = Mathf.Atan2(force.y,force.x) * Mathf.Rad2Deg;
                  control.rotation = Quaternion.Euler(0,0,angle);
                  arrow.SetActive(true);
                 
              }
              if(Input.GetMouseButtonUp(0)){
                  rb.velocity = Vector3.zero; 
                endTouch = Camera.main.WorldToScreenPoint(Input.mousePosition);
                endTouch.z = 0;

                force = endTouch- startTouch ;
                clampedForce = Vector3.ClampMagnitude(force,max)*power;
                rb.AddForce(clampedForce,ForceMode2D.Impulse);
                arrow.SetActive(false);
                audioManager.PlaySound("Fly");
            }
        }

    }
    void OnCollisionEnter2D(Collision2D col){
        
        if (col.gameObject.tag != "Coin"){
            audioManager.PlaySound("Bounce");
        }
    }
    void OnTriggerEnter2D(Collider2D colly){
        //CoinsSystemPointUP
        if (colly.tag == "Coin"){
            cMan.CoinCalculate(1);
            audioManager.PlaySound("Coins");
        }
        
    }
}
