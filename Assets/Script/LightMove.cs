using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMove : MonoBehaviour
{
    private Transform DefaultMode;
    private Transform StoneMode;
    private Transform StickyMode;
    // Start is called before the first frame update
    void Start()
    {
        // GameObject ModeDefault = GameObject.FindWithTag("Bones");
        // GameObject ModeStone = GameObject.FindWithTag("StoneMode");
        // GameObject ModeSticky = GameObject.FindWithTag("StickyMode");

        // if(ModeDefault != null) {
        //     DefaultMode = ModeDefault.transform;
        // }else if(ModeStone != null) {
        //     StoneMode = ModeStone.transform;
        // }else if(ModeSticky != null) {
        //     StickyMode = ModeSticky.transform;
        // }else {
        //     Debug.Log("GameObject tdk ditemukan");
        // }


    }

    // Update is called once per frame
    void Update()
    {
        GameObject ModeDefault = GameObject.FindWithTag("Bones");
        GameObject ModeStone = GameObject.FindWithTag("StoneMode");
        GameObject ModeSticky = GameObject.FindWithTag("StickyMode");

        if(ModeDefault != null) {
            DefaultMode = ModeDefault.transform;
        }else if(ModeStone != null) {
            StoneMode = ModeStone.transform;
        }else if(ModeSticky != null) {
            StickyMode = ModeSticky.transform;
        }

        if(DefaultMode != null) {
            transform.position = new Vector2(DefaultMode.position.x, DefaultMode.position.y);
        }else if(StoneMode != null) {
            transform.position = new Vector2(StoneMode.position.x, StoneMode.position.y);
        }else if(StickyMode != null) {
            transform.position = new Vector2(StickyMode.position.x, StickyMode.position.y);
        }

    }
}
