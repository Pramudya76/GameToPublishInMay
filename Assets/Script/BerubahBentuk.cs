using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class BerubahBentuk : MonoBehaviour
{
    //private GameObject player;
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    private Vector2 posisiObjectAwal;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject playerObject = GameObject.FindWithTag("Bones");
        //player = GetComponentInParent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        posisiObjectAwal = transform.position;
        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            //Destroy(gameObject);
            Instantiate(object1, posisiObjectAwal, Quaternion.identity);
            Debug.Log("Game object : " + gameObject.name);
            DestroyParent();
        }else if(Input.GetKeyDown(KeyCode.Alpha3)) {
            Instantiate(object2, posisiObjectAwal, Quaternion.identity);
            Debug.Log("Game object : " + gameObject.name);
            DestroyParent();
        }else if(Input.GetKeyDown(KeyCode.Alpha1)) {
            Instantiate(object3, posisiObjectAwal, Quaternion.identity);
            Debug.Log("Game object : " + gameObject.name);
            DestroyParent();
        }


    }
    public void DestroyParent() {
        if(transform.parent != null) {
            Destroy(transform.parent.gameObject);
        }else {
            Destroy(gameObject);
        }
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if(collision.gameObject.tag == "Buff") {
    //         Destroy(collision.gameObject);
    //         Instantiate(object2, posisiObjectAwal, Quaternion.identity);
    //         Destroy(player);
    //     }
    // }

}
