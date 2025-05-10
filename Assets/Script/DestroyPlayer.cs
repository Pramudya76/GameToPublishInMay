using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DestroyPlayer : MonoBehaviour
{
    private GameManager GM;
    private GameObject player;
    private GameObject StoneMode;
    private GameObject StickyMode;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StoneMode = GameObject.FindWithTag("StoneMode");
        StickyMode = GameObject.FindWithTag("StickyMode");
        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");
        GM = gameManagerObject.GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Thorns") {
            if(player != null) {
                GM.mode = "player";
                GM.isDead = true;
                GM.callRespawn();
                Destroy(player);
                player = null;
            }else if(StoneMode != null) {
                GM.mode = "StoneMode";
                GM.isDead = true;
                GM.callRespawn();
                Destroy(StoneMode);
                StoneMode = null;
            }else if(StickyMode != null) {
                GM.mode = "StickyMode";
                GM.isDead = true;
                GM.callRespawn();
                Destroy(StickyMode);
                StickyMode = null;
            }
        }       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy") {
            if(player != null) {
                Debug.Log("player jalan");
                GM.mode = "player";
                GM.isDead = true;
                GM.callRespawn();
                Destroy(player);
                player = null;
            }else if(StoneMode != null) {
                GM.mode = "StoneMode";
                GM.isDead = true;
                GM.callRespawn();
                Destroy(StoneMode);
                StoneMode = null;
            }else if(StickyMode != null) {
                GM.mode = "StickyMode";
                GM.isDead = true;
                GM.callRespawn();
                Destroy(StickyMode);
                StickyMode = null;
            }
        }  
    }


}
