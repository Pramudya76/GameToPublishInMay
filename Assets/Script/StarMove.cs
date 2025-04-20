using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMove : MonoBehaviour
{
    public float moveSpeedRotation = 50f;
    public float moveSpeed = 5f;
    public float moveRotation = 45f;
    public float moveDirection = 0.5f;
    private float startX;
    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = startX + Mathf.PingPong(Time.time * moveSpeed, moveDirection);
        transform.position = new Vector2(moveX, transform.position.y);


        float sudut = Mathf.PingPong(Time.time * moveSpeedRotation, moveRotation * 2) - moveRotation;
        transform.rotation = Quaternion.Euler(0, 0, sudut);
    }
}
