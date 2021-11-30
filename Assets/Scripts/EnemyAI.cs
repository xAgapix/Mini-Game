using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    Path path;
    public Transform target;
    int currentWayPoint = 0;
    float nextWayPoint = 1f;
    public Seeker seeker;
    public Rigidbody2D rb;
    Vector3 clampedForce;
    float spawnTime = 0f;
    void Awake(){
        
    }
    void Start()
    {
       
       
        AstarPath.active.Scan();
        
        
    }
    
    void Move(){
        if (Time.time > spawnTime){
            rb.velocity = Vector3.zero; 
            spawnTime = Time.time + 1f;
            rb.AddForce(clampedForce,ForceMode2D.Impulse);

            
            }
    }
   

    void Update()
    {
        if (seeker.IsDone()){
        seeker.StartPath(transform.position, target.position, OnPathComplete);
        }
        
        
        
        
    }

    void OnPathComplete(Path p){
        path = p;
        currentWayPoint = 1;
        Vector3 direction = (path.vectorPath[currentWayPoint] - transform.position).normalized;
        direction.z = 0;

        clampedForce = direction * 100f;

        Move();
    }
    void OnCollisionEnter2D(Collision2D colly){
        
    }
}
