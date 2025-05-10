using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MechanicWork : MonoBehaviour
{
    private Vector3 posisi;
    private Vector3 posisiAwal;
    private Vector3 posisiDoor;
    private Vector3 posisiAwalDoor;
    public GameObject door;
    private float moveSpeed = 0.5f;
    private bool moving;
    private GameManager GM;
    private bool song;
    // Start is called before the first frame update
    void Start()
    {
        posisiAwal = transform.position;
        posisi = new Vector3(transform.position.x, transform.position.y - 3, transform.position.z);
        posisiDoor = new Vector3(door.transform.position.x, door.transform.position.y + 15,door.transform.position.z);
        posisiAwalDoor = door.transform.position;
        GameObject GameManagerObject = GameObject.FindWithTag("GameManager");
        GM = GameManagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moving) {
            transform.position = Vector2.Lerp(transform.position, posisi, Time.deltaTime * moveSpeed);
            door.transform.position = Vector2.Lerp(door.transform.position, posisiDoor,Time.deltaTime * moveSpeed);
            song = true;
            StartCoroutine(CdSoundGate());
        }else {
            transform.position = Vector2.Lerp(transform.position, posisiAwal, Time.deltaTime * moveSpeed);
            door.transform.position = Vector2.Lerp(door.transform.position, posisiAwalDoor, Time.deltaTime * moveSpeed * 1.5f);
            song = true;
            StartCoroutine(CdSoundGate());
        }

        if((door.transform.position - posisiAwalDoor).magnitude >= 3f) {
            if(!GM.GateSound.isPlaying) {
                GM.GateSound.Play();
            }
            song = true;
        }else {
            if(song) {
                GM.GateSound.Stop();
                song = false;
            }
        }
    }

    IEnumerator CdSoundGate() {
        yield return new WaitForSeconds(1f);
        song = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "StoneMode") {
            moving = true;
            StartCoroutine(CDReset());
        }        
    }

    IEnumerator CDReset() {
        yield return new WaitForSeconds(3f);
        moving = false;
    }

}
