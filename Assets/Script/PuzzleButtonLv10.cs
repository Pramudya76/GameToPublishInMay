using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButtonLv10 : MonoBehaviour
{
    private bool isPressed = false;
    public PuzzleManagerLv10 PM;
    private Vector2 positionButtonAfter;
    public float buttonPressedValue = 1f;
    // Start is called before the first frame update
    void Start()
    {
        positionButtonAfter = new Vector2(transform.position.x, transform.position.y + buttonPressedValue);
    }

    // Update is called once per frame
    void Update()
    {
        if(isPressed) {
            transform.position = positionButtonAfter;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(isPressed) return;
        if(collision.gameObject.tag == "Bones" && !isPressed || collision.gameObject.tag == "StickyMode" && !isPressed || collision.gameObject.tag == "StoneMode" && !isPressed) {
            isPressed = true;
            PM.checkedPuzzle();
        }
    }


}
