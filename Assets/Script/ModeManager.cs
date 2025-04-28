using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeManager : MonoBehaviour
{
    private GameManager GM;
    public Image Mode1Press;
    public Image Mode2Press;
    public Image Mode3Press;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        Mode1Press.gameObject.SetActive(true);
        Mode2Press.gameObject.SetActive(false);
        Mode3Press.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GM.mode == "Mode1") {
            Mode1Press.gameObject.SetActive(true);
            Mode2Press.gameObject.SetActive(false);
            Mode3Press.gameObject.SetActive(false);
        }else if(GM.mode == "Mode2") {
            Mode1Press.gameObject.SetActive(false);
            Mode2Press.gameObject.SetActive(true);
            Mode3Press.gameObject.SetActive(false);
        }else if(GM.mode == "Mode3") {
            Mode1Press.gameObject.SetActive(false);
            Mode2Press.gameObject.SetActive(false);
            Mode3Press.gameObject.SetActive(true);
        }
    }
}
