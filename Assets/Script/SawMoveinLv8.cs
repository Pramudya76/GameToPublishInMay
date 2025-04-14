using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMoveinLv8 : MonoBehaviour
{
    private float moveSpeed = 40f;
    public float moveSpeedSaw = 2f;
    private float startX;
    public float moveDistance = 9f;
    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, moveSpeed * Time.deltaTime);

        float newX = startX + Mathf.PingPong(Time.time * moveSpeedSaw, moveDistance);
        transform.position = new Vector2(newX, transform.position.y);

    }
}
