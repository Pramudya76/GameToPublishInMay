using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeManager : MonoBehaviour
{
    public CanvasGroup AllMode;
    private GameManager GM;
    public Image Mode1Press;
    public Image Mode2Press;
    public Image Mode3Press;
    private bool muncul = false;
    private String PreviousMode = "";
    private Coroutine CurrentCoroutine = null;
    // Start is called before the first frame update
    void Start()
    {
        AllMode.gameObject.SetActive(false);
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        Mode1Press.gameObject.SetActive(true);
        Mode2Press.gameObject.SetActive(false);
        Mode3Press.gameObject.SetActive(false);
        PreviousMode = GM.mode;
    }

    // Update is called once per frame
    void Update()
    {
        if(GM.mode != PreviousMode) {
            muncul = false;
            PreviousMode = GM.mode;
        }


        if(GM.mode == "Mode1") {
            Mode1Press.gameObject.SetActive(true);
            Mode2Press.gameObject.SetActive(false);
            Mode3Press.gameObject.SetActive(false);
            if(!muncul) {
                if(CurrentCoroutine != null) StopCoroutine(CurrentCoroutine);
                CurrentCoroutine = StartCoroutine(CDAllMode());
            }
        }else if(GM.mode == "Mode2") {
            Mode1Press.gameObject.SetActive(false);
            Mode2Press.gameObject.SetActive(true);
            Mode3Press.gameObject.SetActive(false);
            if(!muncul) {
                if(CurrentCoroutine != null) StopCoroutine(CurrentCoroutine);
                CurrentCoroutine = StartCoroutine(CDAllMode());
            }
        }else if(GM.mode == "Mode3") {
            Mode1Press.gameObject.SetActive(false);
            Mode2Press.gameObject.SetActive(false);
            Mode3Press.gameObject.SetActive(true);
            if(!muncul) {
                if(CurrentCoroutine != null) StopCoroutine(CurrentCoroutine);
                CurrentCoroutine = StartCoroutine(CDAllMode());
            }
        }



    }

    IEnumerator CDAllMode() {
        muncul = true;
        AllMode.gameObject.SetActive(true);
        AllMode.alpha = 1f;
        yield return new WaitForSeconds(2f);
        while(AllMode.alpha > 0) {
            AllMode.alpha -= 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        AllMode.gameObject.SetActive(false);
    }


}
