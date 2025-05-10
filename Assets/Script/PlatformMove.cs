using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    private Vector3 posisiAwal;
    private Vector3 posisiAkhir;
    private float moveSpeed = 1f;
    private bool moving;
    // Start is called before the first frame update
    void Start()
    {
        posisiAwal = transform.position;
        posisiAkhir = new Vector3(transform.position.x, transform.position.y + 6, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(moving) {
            transform.position = Vector2.Lerp(transform.position, posisiAkhir, Time.deltaTime * moveSpeed);
        }else {
            transform.position = Vector2.Lerp(transform.position, posisiAwal, Time.deltaTime * moveSpeed);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bones") {
            moving = true;
            StartCoroutine(CDReset());
        }
    }

    IEnumerator CDReset() {
        yield return new WaitForSeconds(3f);
        moving = false;
    }

}
