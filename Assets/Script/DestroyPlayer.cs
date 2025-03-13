using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    private GameObject player;
    private GameObject StoneMode;
    private GameObject StickyMode;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StoneMode = GameObject.FindWithTag("StoneMode");
        StickyMode = GameObject.FindWithTag("StickyMode");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Thorns") {
            Debug.Log("Kena duri");
            if(player != null) {
                Destroy(player);
            }else if(StoneMode != null) {
                Destroy(StoneMode);
            }else if(StickyMode != null) {
                Destroy(StickyMode);
            }
        }       
    }
}
