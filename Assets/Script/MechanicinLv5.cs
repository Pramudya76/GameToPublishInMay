using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicinLv5 : MonoBehaviour
{
    private Vector3 posisi;
    private Vector3 posisiAwal;
    private Vector3 posisiWall;
    private Vector3 posisiAwalWall;
    public GameObject wall;
    private float moveSpeed = 2f;
    private bool moving;
    // Start is called before the first frame update
    void Start()
    {
        posisiAwal = transform.position;
        posisi = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        posisiAwalWall = wall.transform.position;
        posisiWall = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(moving) {
            transform.position = Vector2.Lerp(transform.position, posisi, Time.deltaTime * moveSpeed);
            wall.transform.position = Vector2.Lerp(wall.transform.position, posisiWall, Time.deltaTime * moveSpeed);
        }else {
            transform.position = Vector2.Lerp(transform.position, posisiAwal, Time.deltaTime * moveSpeed);
            wall.transform.position = Vector2.Lerp(wall.transform.position, posisiAwalWall, Time.deltaTime * moveSpeed);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bones" || collision.gameObject.tag == "StoneMode" || collision.gameObject.tag == "StickyMode") {
            moving = true;
            StartCoroutine(CDBack());
        }
    }

    IEnumerator CDBack() {
        yield return new WaitForSeconds(3f);
        moving = false;
    }


}
