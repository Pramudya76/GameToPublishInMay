using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SawMoveinLv9 : MonoBehaviour
{
    public Transform[] points;
    private float moveSpeedRotate = 20;
    private float moveSpeed = 2f;
    private int index = 0;
    private Transform targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = points[index];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, moveSpeedRotate * Time.deltaTime);

        transform.position = Vector2.MoveTowards(transform.position, targetPosition.position, Time.deltaTime * moveSpeed);
        if(Vector2.Distance(transform.position, targetPosition.position) <= 0.0001f) {
            index++;
            if(index == points.Length) {
                index = 0;
            }
            targetPosition = points[index];
            
        }
    }
}
