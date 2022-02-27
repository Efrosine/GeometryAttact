using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    void Start()
    {
        
    }

 
    void Update()
    {
        for(int i = 0; i < Input.touchCount; i++)
        {
            Vector3 touchPost = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            Debug.DrawLine(Vector3.zero, touchPost, Color.red);
        }
    }
}
