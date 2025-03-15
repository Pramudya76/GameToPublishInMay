using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyMode : MonoBehaviour
{
    private Rigidbody2D rb;
    private LayerMask TargetLayer;
    // private LayerMask ceilingLayer;
    // private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        TargetLayer = LayerMask.GetMask("Walls", "Ground","ceilingLayer");
        // ceilingLayer = LayerMask.GetMask("ceilingLayer");
        // groundLayer = LayerMask.GetMask("Ground");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(moveX * 3, rb.velocity.y);
        
        float distance = 0.69f;
        RaycastHit2D HitLeft = Physics2D.Raycast(transform.position, Vector2.left, distance, TargetLayer);
        RaycastHit2D HitRight = Physics2D.Raycast(transform.position, Vector2.right, distance, TargetLayer);
        RaycastHit2D HitDown = Physics2D.Raycast(transform.position, Vector2.down, distance, TargetLayer);
        RaycastHit2D HitUp = Physics2D.Raycast(transform.position, Vector2.up, distance, TargetLayer);
        
        if(HitDown.collider != null && HitLeft.collider == null && HitRight.collider == null) {
           rb.velocity = new Vector2(moveX * 3, rb.velocity.y);
           rb.gravityScale = 1;
        }else if(HitLeft.collider != null && HitUp.collider ==  null) {
            rb.velocity = new Vector2(-1f, -moveX * 3);
            rb.gravityScale = 0;
        }else if(HitUp.collider != null && HitLeft.collider == null && HitRight.collider == null) {
            rb.velocity = new Vector2(moveX * 3, 1f);
            rb.gravityScale = -1;
        }else if(HitRight.collider != null && HitUp.collider == null ) {
            rb.velocity = new Vector2(1f, moveX * 3);
            rb.gravityScale = 0;
        }else if(HitDown.collider == null && HitLeft.collider == null && HitUp.collider == null && HitRight.collider == null) {
            rb.gravityScale = 1;
        }

        
        
        if(HitUp.collider != null && HitLeft.collider != null) {
            if(Input.GetKey(KeyCode.A)) {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - 2);
            }else if(Input.GetKey(KeyCode.D)) {
                rb.velocity = new Vector2(rb.velocity.x + 2, rb.velocity.y);
            }
        }

        if(HitLeft.collider != null && HitDown.collider != null) {
            if(Input.GetKey(KeyCode.A)) {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 2);
                //Debug.Log("Tembok");
            }else if(Input.GetKey(KeyCode.D)) {
                rb.velocity = new Vector2(rb.velocity.x + 2, rb.velocity.y);
                //Debug.Log("Tanah");
            }
        }

        if(HitUp.collider != null && HitRight.collider != null) {
            if(Input.GetKey(KeyCode.D)) {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - 2);
            }else if(Input.GetKey(KeyCode.A)) {
                rb.velocity = new Vector2(rb.velocity.x - 2, rb.velocity.y);
            }
        }

        if(HitDown.collider != null && HitRight.collider != null) {
            if(Input.GetKey(KeyCode.A)) {
                rb.velocity = new Vector2(rb.velocity.x - 2, rb.velocity.y);
            }else if(Input.GetKey(KeyCode.D)) {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 2);
            }
        }
        
        
        
        
        
        
        Debug.DrawRay(transform.position, Vector2.left * distance, Color.red);
        Debug.DrawRay(transform.position, Vector2.right * distance, Color.green);
        Debug.DrawRay(transform.position, Vector2.down * distance, Color.blue);
        Debug.DrawRay(transform.position, Vector2.up * distance, Color.white);

    }

    

}
