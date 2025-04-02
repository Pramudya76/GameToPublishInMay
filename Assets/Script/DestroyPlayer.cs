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
    public GameObject playerPrefabs;
    public GameObject StonePrefabs;
    public GameObject StickyPrefabs;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StoneMode = GameObject.FindWithTag("StoneMode");
        StickyMode = GameObject.FindWithTag("StickyMode");
        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");
        GM = gameManagerObject.GetComponent<GameManager>();
        startPosition = player.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Thorns") {
            Debug.Log("Kena duri");
            if(player != null) {
                Destroy(player);
                player = Instantiate(playerPrefabs, startPosition, Quaternion.identity);
                
            }
            if(StoneMode != null) {
                Destroy(StoneMode);
                StoneMode = Instantiate(StonePrefabs, startPosition, Quaternion.identity);
                
            }
            if(StickyMode != null) {
                Destroy(StickyMode);
                StickyMode = Instantiate(StickyPrefabs, startPosition, Quaternion.identity);
                
            }
            //Instantiate(playerPrefabs, startPosition, Quaternion.identity);
        }       
    }

}
