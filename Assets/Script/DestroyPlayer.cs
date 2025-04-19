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
    // public GameObject playerPrefabs;
    // public GameObject StonePrefabs;
    // public GameObject StickyPrefabs;
    // private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StoneMode = GameObject.FindWithTag("StoneMode");
        StickyMode = GameObject.FindWithTag("StickyMode");
        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");
        GM = gameManagerObject.GetComponent<GameManager>();
        //startPosition = player.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Thorns") {
            //Debug.Log("Kena duri");
            if(player != null) {
                Debug.Log("player jalan");
                GM.mode = "player";
                GM.isDead = true;
                GM.callRespawn();
                Destroy(player);
                player = null;
                
                //GM.Respawn();
                //player = Instantiate(playerPrefabs, startPosition, Quaternion.identity);
            }else if(StoneMode != null) {
                GM.mode = "StoneMode";
                GM.isDead = true;
                GM.callRespawn();
                Destroy(StoneMode);
                StoneMode = null;
                
                //GM.Respawn();
                //StoneMode = Instantiate(StonePrefabs, startPosition, Quaternion.identity);
                
            }else if(StickyMode != null) {
                GM.mode = "StickyMode";
                GM.isDead = true;
                GM.callRespawn();
                Destroy(StickyMode);
                StickyMode = null;
                
                //GM.Respawn();
                //StickyMode = Instantiate(StickyPrefabs, startPosition, Quaternion.identity);
                
            }
            //GM.isDead = false;
            //Instantiate(playerPrefabs, startPosition, Quaternion.identity);
        }       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy") {
            //Debug.Log("Kena duri");
            if(player != null) {
                Debug.Log("player jalan");
                GM.mode = "player";
                GM.isDead = true;
                GM.callRespawn();
                Destroy(player);
                player = null;
                
                //GM.Respawn();
                //player = Instantiate(playerPrefabs, startPosition, Quaternion.identity);
            }else if(StoneMode != null) {
                GM.mode = "StoneMode";
                GM.isDead = true;
                GM.callRespawn();
                Destroy(StoneMode);
                StoneMode = null;
                
                //GM.Respawn();
                //StoneMode = Instantiate(StonePrefabs, startPosition, Quaternion.identity);
                
            }else if(StickyMode != null) {
                GM.mode = "StickyMode";
                GM.isDead = true;
                GM.callRespawn();
                Destroy(StickyMode);
                StickyMode = null;
                
                //GM.Respawn();
                //StickyMode = Instantiate(StickyPrefabs, startPosition, Quaternion.identity);
                
            }
            //GM.isDead = false;
            //Instantiate(playerPrefabs, startPosition, Quaternion.identity);
        }  
    }


}
