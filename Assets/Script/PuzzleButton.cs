using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    public PuzzleOrder PO;
    private Vector2 positionButton;
    private Vector2 positionAwalButton;
    private float moveSpeedButton = 10f;
    private bool isPresed;
    // Start is called before the first frame update
    void Start()
    {
        positionButton = new Vector2(transform.position.x, transform.position.y + 1);
        positionAwalButton = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(isPresed) {
            transform.position = Vector2.Lerp(transform.position, positionButton, Time.deltaTime * moveSpeedButton);

        }else {
            transform.position = Vector2.Lerp(transform.position, positionAwalButton, Time.deltaTime * moveSpeedButton);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(isPresed) return;
        if(collision.gameObject.tag == "Bones" || collision.gameObject.tag == "StoneMode" || collision.gameObject.tag == "StickyMode") {
            isPresed = true;
            StartCoroutine(BackToNormalPosition());
            PO.CheckPuzzle(gameObject.name);
        }
    }

    IEnumerator BackToNormalPosition() {
        yield return new WaitForSeconds(1f);
        isPresed = false;
    }

}
