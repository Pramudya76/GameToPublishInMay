using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicinLv6 : MonoBehaviour
{
    private GameManager GM;
    private Vector3 FloorPosition;
    private bool isDestroy = false;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        FloorPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(isDestroy) return;
        if(collision.gameObject.tag == "Bones" || collision.gameObject.tag == "StoneMode" || collision.gameObject.tag == "StickyMode") {
            isDestroy = true;
            GM.SpawnFloor(FloorPosition);
            StartCoroutine(CDDestroyFloor());
        }
    }

    IEnumerator CDDestroyFloor() {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
