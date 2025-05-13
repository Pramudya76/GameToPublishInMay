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
    public bool isChangeMode = false;
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
        if(isChangeMode) return;
        posisiObjectAwal = transform.position;
        if(Input.GetKeyDown(KeyCode.Alpha2) && GM.mode != "Mode2") {
            GM.mode = "Mode2";
            Instantiate(object1, posisiObjectAwal, Quaternion.identity);
            DestroyParent();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) && GM.mode != "Mode3") {
            GM.mode = "Mode3";
            Instantiate(object2, posisiObjectAwal, Quaternion.identity);
            DestroyParent();
        }
        if(Input.GetKeyDown(KeyCode.Alpha1) && GM.mode != "Mode1") {
            GM.mode = "Mode1";
            Instantiate(object3, posisiObjectAwal, Quaternion.identity);
            DestroyParent();
        }


    }
    public void DestroyParent() {
        isChangeMode = true;
        if(transform.parent != null) {
            posisiObjectAwal = transform.parent.position;
            Destroy(transform.parent.gameObject);
        }else {
            posisiObjectAwal = transform.position;
            Destroy(gameObject);
        }
    }

}
