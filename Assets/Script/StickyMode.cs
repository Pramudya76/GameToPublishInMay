using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyMode : MonoBehaviour
{
    private Rigidbody2D rb;
    private LayerMask TargetLayer;
    private GameManager GM;
    private bool walk = false;
    private LevelManager LM;
    // private LayerMask ceilingLayer;
    // private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        TargetLayer = LayerMask.GetMask("Walls", "Ground","Obstacle");
        // ceilingLayer = LayerMask.GetMask("ceilingLayer");
        // groundLayer = LayerMask.GetMask("Ground");
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
        //rb.velocity = new Vector2(moveX * 3, rb.velocity.y);
        
        float distance = 0.80f;
        RaycastHit2D HitLeft = Physics2D.Raycast(transform.position, Vector2.left, distance, TargetLayer);
        RaycastHit2D HitRight = Physics2D.Raycast(transform.position, Vector2.right, distance, TargetLayer);
        RaycastHit2D HitDown = Physics2D.Raycast(transform.position, Vector2.down, distance, TargetLayer);
        RaycastHit2D HitUp = Physics2D.Raycast(transform.position, Vector2.up, distance, TargetLayer);
        
        if(HitDown.collider != null && HitLeft.collider == null && HitRight.collider == null) {
           rb.velocity = new Vector2(moveX * 10, rb.velocity.y);
           //rb.gravityScale = 1;
           SetGravityForAllBones(1);
        }else if(HitLeft.collider != null && HitUp.collider ==  null) {
            rb.velocity = new Vector2(-1f, -moveX * 10);
            //rb.gravityScale = 0;
            SetGravityForAllBones(0);
        }else if(HitUp.collider != null && HitLeft.collider == null && HitRight.collider == null) {
            rb.velocity = new Vector2(moveX * 10, 1f);
            //rb.gravityScale = -1;
            SetGravityForAllBones(-1);
        }else if(HitRight.collider != null && HitUp.collider == null ) {
            rb.velocity = new Vector2(1f, moveX * 10);
            //rb.gravityScale = 0;
            SetGravityForAllBones(0);
        }else if(HitDown.collider == null && HitLeft.collider == null && HitUp.collider == null && HitRight.collider == null) {
            //rb.gravityScale = 1;
            rb.velocity = new Vector2(moveX * 10, rb.velocity.y);
            SetGravityForAllBones(1);
        }

        
        
        if(HitUp.collider != null && HitLeft.collider != null) {
            if(Input.GetKey(KeyCode.A)) {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - 5);
            }else if(Input.GetKey(KeyCode.D)) {
                rb.velocity = new Vector2(rb.velocity.x + 5, rb.velocity.y);
            }
        }

        if(HitLeft.collider != null && HitDown.collider != null) {
            if(Input.GetKey(KeyCode.A)) {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 5);
                //Debug.Log("Tembok");
            }else if(Input.GetKey(KeyCode.D)) {
                rb.velocity = new Vector2(rb.velocity.x + 5, rb.velocity.y);
                //Debug.Log("Tanah");
            }
        }

        if(HitUp.collider != null && HitRight.collider != null) {
            if(Input.GetKey(KeyCode.D)) {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - 5);
            }else if(Input.GetKey(KeyCode.A)) {
                rb.velocity = new Vector2(rb.velocity.x - 5, rb.velocity.y);
            }
        }

        if(HitDown.collider != null && HitRight.collider != null) {
            if(Input.GetKey(KeyCode.A)) {
                rb.velocity = new Vector2(rb.velocity.x - 5, rb.velocity.y);
            }else if(Input.GetKey(KeyCode.D)) {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 5);
            }
        }
        
        if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) {
            GM.StickySound.Stop();
            walk = true;
        }
        if(Input.GetKey(KeyCode.A) && walk || Input.GetKey(KeyCode.D) && walk) {
            GM.StickySound.Play();
            StartCoroutine(CDWalk());
        }
        
        
        
        
        Debug.DrawRay(transform.position, Vector2.left * distance, Color.red);
        Debug.DrawRay(transform.position, Vector2.right * distance, Color.green);
        Debug.DrawRay(transform.position, Vector2.down * distance, Color.blue);
        Debug.DrawRay(transform.position, Vector2.up * distance, Color.white);

    }

    void OnDestroy()
    {
        GM.StickySound.Stop();
    }

    IEnumerator CDWalk() {
        yield return new WaitForSeconds(0.1f);
        walk = false;
    }


    void SetGravityForAllBones(float gravity)
{
    Transform root = transform.parent; // Ambil parent Bone 17
    if (root != null)
    {
        foreach (Transform child in root) // Loop semua bone di dalam parent
        {
            Rigidbody2D childRb = child.GetComponent<Rigidbody2D>();
            if (childRb != null)
            {
                childRb.gravityScale = gravity; // Samakan gravity
            }
        }
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
