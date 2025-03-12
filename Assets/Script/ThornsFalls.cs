using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : MonoBehaviour
{
    private Rigidbody2D Parent;
    // Start is called before the first frame update
    void Start()
    {
        Parent = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bones" || collision.gameObject.tag == "Player") {
            Parent.gravityScale = 1;
        }
    }
}
