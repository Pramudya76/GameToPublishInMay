using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameManager GM;
    private Rigidbody2D rb;
    private float moveSpeed = 8f;
    private float jumpForce = 12f;
    private bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject GameManagerObject = GameObject.FindWithTag("GameManager");
        GM = GameManagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && isGround) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * 10);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Star") {
            StartCoroutine(CDChangeScene());
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Ground") {
            isGround = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground") {
            isGround = false;
        }
    }


    IEnumerator CDChangeScene() {
        yield return new WaitForSeconds(0.1f);
        GM.ChangeScene();     
    }


}
