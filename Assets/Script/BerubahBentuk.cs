using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerubahBentuk : MonoBehaviour
{
    public GameObject player;
    public GameObject object2;
    private Vector2 posisiObjectAwal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posisiObjectAwal = transform.position;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Buff") {
            Destroy(collision.gameObject);
            Instantiate(object2, posisiObjectAwal, Quaternion.identity);
            Destroy(player);
        }
    }

}
