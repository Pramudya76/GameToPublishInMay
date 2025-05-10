using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleMove : MonoBehaviour
{
    private float startY;
    private float startX;
    public float moveTentacle = 3f;
    private float moveSpeed = 1f;
    public float waktuJeda; // Time offset for the sine wave
    public GameObject Enemy; // Parent object to follow
    
    void Start()
    {
        if (Enemy != null)
        {
            startX = transform.position.x - Enemy.transform.position.x;
            startY = transform.position.y - Enemy.transform.position.y;
        }
        
    }

    void Update()
    {
        if (Enemy != null)
        {
            float moveY = Mathf.Sin((Time.time + waktuJeda) * moveSpeed) * moveTentacle;
            float moveX = Mathf.Sin((Time.time + waktuJeda) * moveSpeed) * moveTentacle;
            
            Vector3 newPosition = Enemy.transform.position + new Vector3(startX + moveX, startY + moveY, 0);
            
            transform.position = newPosition;
        }
    }
}