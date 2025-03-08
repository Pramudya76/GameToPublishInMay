using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornMoveinLv2 : MonoBehaviour
{
    private float moveDistance = 2f;
    private float moveSpeed = 1f;
    private float startX;
    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float newX = startX + Mathf.PingPong(Time.time * moveSpeed, moveDistance);
        transform.position = new Vector2(newX, transform.position.y);
    }
}
