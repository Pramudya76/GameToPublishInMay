using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameManager GM;
    private Rigidbody2D rb;
    private float moveSpeed = 8f;
    private float jumpForce = 13f;
    private bool isGround;
    private LevelManager LM;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject GameManagerObject = GameObject.FindWithTag("GameManager");
        GM = GameManagerObject.GetComponent<GameManager>();
        GameObject LevelManagerObject = GameObject.FindWithTag("LevelManager");
        LM = LevelManagerObject.GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && isGround) {
            GM.jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * 10);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Star") {
            LM.isLevelCompleted = true;
            GM.CatcheStarSound.Play();
            LM.LevelSystem();
            GM.StartCoroutine(GM.CDChangeToGameWin());
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


    


}
