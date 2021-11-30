using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    Vector3 store;
    void Update()
    {
        store = player.position;
        store.z = transform.position.z;
        transform.position = store;
        
        
    }
}
