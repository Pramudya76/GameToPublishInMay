using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class BerubahBentuk : MonoBehaviour
{
    private GameManager GM;
    //private GameObject player;
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    private Vector2 posisiObjectAwal;
    //public String checkMode;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        posisiObjectAwal = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        posisiObjectAwal = transform.position;
        //Debug.Log(posisiObjectAwal);
        if(Input.GetKeyDown(KeyCode.Alpha2) && GM.mode != "Mode2") {
            GM.mode = "Mode2";
            //posisiObjectAwal = transform.position;
            //Destroy(gameObject);
            Instantiate(object1, posisiObjectAwal, Quaternion.identity);
            Debug.Log("Game object : " + gameObject.name);
            //Debug.Log(clone.transform.position);
            DestroyParent();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) && GM.mode != "Mode3") {
            GM.mode = "Mode3";
            //posisiObjectAwal = transform.position;
            Instantiate(object2, posisiObjectAwal, Quaternion.identity);
            Debug.Log("Game object : " + gameObject.name);
            //Debug.Log(clone.transform.position);
            DestroyParent();
        }
        if(Input.GetKeyDown(KeyCode.Alpha1) && GM.mode != "Mode1") {
            GM.mode = "Mode1";
            //posisiObjectAwal = transform.position;
            Instantiate(object3, posisiObjectAwal, Quaternion.identity);
            Debug.Log("Game object : " + gameObject.name);
            //Debug.Log(clone.transform.position);
            DestroyParent();
        }


    }
    public void DestroyParent() {
        if(transform.parent != null) {
            posisiObjectAwal = transform.parent.position;
            Destroy(transform.parent.gameObject);
        }else {
            posisiObjectAwal = transform.position;
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
