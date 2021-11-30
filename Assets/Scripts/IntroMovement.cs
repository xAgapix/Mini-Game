using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMovement : MonoBehaviour
{
    public GameObject gameHolder;
    public CameraMovement cm;
    public Transform start;
    public Transform end;
    public PlayerMovement playerMovement;
    Vector2 tempTrans;
    Camera cam;
    private float speed = 15f;
    float os = 12f;
    void Awake(){
        
    }
    void Start()
    {
        playerMovement.enabled = false;
        gameHolder.SetActive(false);
        cm.enabled = false;
        tempTrans = start.position;
        cam = GetComponent<Camera>();
        cam.orthographicSize = os;
        transform.position = tempTrans;
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,end.position,speed * Time.deltaTime);
        
        IntroDone();
    }
    void IntroDone(){
        if (transform.position.y == end.position.y) {
            if (os > 5){
            os -= 6* Time.deltaTime;
            cam.orthographicSize = os;

        } else {
            IntroMovement introMove = GetComponent<IntroMovement>();
            cm.enabled = true;
            playerMovement.enabled = false;
            gameHolder.SetActive(true);
            introMove.enabled = false;
            
        }
        }
    }
}
