using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject AfterHaveData;
    public GameObject BeforeHaveData;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("HasSaveData")) {
            AfterHaveData.gameObject.SetActive(true);
            BeforeHaveData.gameObject.SetActive(false);
        }else {
            AfterHaveData.gameObject.SetActive(false);
            BeforeHaveData.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
