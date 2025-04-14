using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SawMoveinLv7 : MonoBehaviour
{
    private float moveSpeed = 50f;
    private float moveDirection = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float sudut = Mathf.PingPong(Time.time * moveSpeed, moveDirection * 2) - moveDirection;
        transform.rotation = Quaternion.Euler(0, 0, sudut);
    }
}
