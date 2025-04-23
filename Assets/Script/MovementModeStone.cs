using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModeStone : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 5f;
    private float jumpForce = 1f;
    private bool isGround;
    private GameManager GM;
    private bool walk = false;
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
        float moveY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && isGround) {
            //Debug.Log("Jalan");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * 1f);
        }

        if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) {
            GM.StoneSound.Stop();
            walk = true;
        }
        if(Input.GetKey(KeyCode.A) && walk || Input.GetKey(KeyCode.D) && walk) {
            GM.StoneSound.Play();
            StartCoroutine(CDWalk());
        } 

    }

    void OnDestroy()
    {
        GM.StoneSound.Stop();
        
    }

    IEnumerator CDWalk() {
        yield return new WaitForSeconds(0.1f);
        walk = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground") {
            isGround = true;
        }else {
            isGround = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Star") {
            LM.isLevelCompleted = true;
            GM.CatcheStarSound.Play();
            LM.LevelSystem();
            GM.StartCoroutine(GM.CDChangeToGameWin());
            //StartCoroutine(CDChangeScene());
            Destroy(collision.gameObject);
        }
    }

    // IEnumerator CDChangeScene() {
    //     yield return new WaitForSeconds(0.1f);
    //     GM.CDChangeToGameWin();     
    // }

    



}
