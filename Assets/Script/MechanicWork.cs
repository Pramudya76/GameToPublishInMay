using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicWork : MonoBehaviour
{
    private Vector3 posisi;
    private Vector3 posisiDoor;
    public GameObject door;
    private float moveSpeed = 0.4f;
    private bool moving;
    // Start is called before the first frame update
    void Start()
    {
        posisi = new Vector3(transform.position.x, transform.position.y - 3, transform.position.z);
        posisiDoor = new Vector3(door.transform.position.x, door.transform.position.y + 15,door.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(moving) {
            transform.position = Vector2.Lerp(transform.position, posisi, Time.deltaTime * moveSpeed);
            door.transform.position= Vector2.Lerp(door.transform.position, posisiDoor,Time.deltaTime * moveSpeed);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bones") {
            moving = true;
        }        
    }
}
