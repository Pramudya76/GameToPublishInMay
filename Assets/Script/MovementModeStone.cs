using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModeStone : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 5f;
    private float jumpForce = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Jalan");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * 1f);
        }

        

    }

    // public void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if(collision.gameObject.tag == "Walls" && Input.GetKey(KeyCode.A) || collision.gameObject.tag == "Walls" && Input.GetKey(KeyCode.D)) {
    //         rb.velocity = new Vector2.zero;
    //     } 
    // }

}
