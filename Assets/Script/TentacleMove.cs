using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleMove : MonoBehaviour
{
    private float startY;
    private float startX;
    public float moveTentacle = 3f;
    private float moveSpeed = 1f;
    public float waktuJeda;
    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
        startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float moveY = startY + Mathf.Sin((Time.time + waktuJeda) * moveSpeed) * moveTentacle;
        float moveX = startX + Mathf.Sin((Time.time + waktuJeda) * moveSpeed) * moveTentacle;
        transform.position = new Vector2(moveX, moveY);
    }

    

}
