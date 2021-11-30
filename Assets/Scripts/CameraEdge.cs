using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEdge : MonoBehaviour
{
    
    public EdgeCollider2D edgeCollider;
    public RectTransform frame; 
    Vector3[] edgeVec = new Vector3[5];
    Vector2 [] setEdgePoints = new Vector2[5];
    void Start()
    {
        frame.GetLocalCorners(edgeVec);
        edgeVec[4] = edgeVec[0];
        for (int i =0; i < 5; i++){
            setEdgePoints[i] = new Vector2(edgeVec[i].x,edgeVec[i].y);
        }
        edgeCollider.points = setEdgePoints;
    }
}
