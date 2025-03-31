using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornsMoveinLv5 : MonoBehaviour
{
    private float moveDistance = 2.5f;
    private float moveSpeed = 2f;
    private float startY;
    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startY + Mathf.PingPong(Time.time * moveSpeed, moveDistance);
        transform.position = new Vector2(transform.position.x, newY);
    }
}
