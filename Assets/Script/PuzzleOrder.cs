using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleOrder : MonoBehaviour
{
    public Transform[] Thorns;
    private String[] correctPuzzle = {"Green", "Blue", "Yellow", "Red"};
    private int indexButton = 0;
    public GameObject door;
    private GameManager GM;
    private Vector2 positionDoorAfter;
    void Start()
    {
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        positionDoorAfter = new Vector2(door.transform.position.x, door.transform.position.y + 4.5f);
    }
    public void CheckPuzzle(String buttonName) {
        if(buttonName == "Purple") {
            for(int a = 0; a < 7; a++) {
                Thorns[a].position = new Vector2(Thorns[a].position.x, Thorns[a].position.y - 1f);
            }

            for(int b = 7; b < 19; b++) {
                Thorns[b].position = new Vector2(Thorns[b].position.x, Thorns[b].position.y + 1f);
            }

            return;

        }
        if(buttonName == correctPuzzle[indexButton]) {
            indexButton++;
            if(indexButton >= correctPuzzle.Length) {
                door.transform.position = new Vector2(door.transform.position.x, door.transform.position.y + 4);
                GM.GateSound.Play();
            }
        }else {
            indexButton = 0;
        }


    }
    
}
