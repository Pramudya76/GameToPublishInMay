using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManagerLv10 : MonoBehaviour
{
    private GameManager GM;
    private Vector2 positionStartDoor;
    public GameObject Door;
    public GameObject[] buttonColor;
    private int indexButton = 0;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        positionStartDoor = new Vector2(Door.transform.position.x, Door.transform.position.y - 5f);
    }

    // Update is called once per frame
    public void checkedPuzzle()
    {
        indexButton++;
        if(indexButton >= buttonColor.Length) {
            Door.transform.position = positionStartDoor;
            GM.GateSound.Play();
        }


    }
}
