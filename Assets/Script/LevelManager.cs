using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float waktu;
    private bool isRunning = true;
    public float bintang2;
    public float bintang3;
    public bool isLevelCompleted = false;
    public TextMeshProUGUI waktuText;
    public TextMeshProUGUI waktuTextGameWin;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public GameObject Star0_2Position;
    public GameObject Star0_3Position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning) {
            waktu += Time.deltaTime;
            waktuText.text = "Time : " + waktu.ToString("F2");
            if(waktu <= bintang3) {
                waktuText.color = Color.green;
            }else if(waktu > bintang3 && waktu <= bintang2) {
                waktuText.color = Color.yellow;
            }else {
                waktuText.color = Color.red;
            }
        }
        
    }

    public void LevelDonePanelinTimer() {
        waktuText.text = "Time : " + waktu.ToString("F2");
    }

    public void LevelDonePanelinGameWin() {
        waktuTextGameWin.text = "Time : " + waktu.ToString("F2") + "s";
    }

    public void LevelSystem() {
        isRunning = false;
        int bintang = hitungBintang(waktu);
        int LevelNumber = SceneManager.GetActiveScene().buildIndex - 1;
        PlayerPrefs.SetFloat("Timer_Level" + LevelNumber, waktu);
        PlayerPrefs.SetInt("Star_Level" + LevelNumber, bintang);
        int nextLevel = LevelNumber + 1;
        PlayerPrefs.SetInt("Level" + nextLevel + "_Unlock", 1);
        PlayerPrefs.Save();

    }

    public int hitungBintang(float waktu) {
        if(!isLevelCompleted) return 0;

        if(waktu <= bintang3) {
            return 3;
        }else if(waktu <= bintang2) {
            return 2;
        }else {
            return 1;
        }
    }
}
