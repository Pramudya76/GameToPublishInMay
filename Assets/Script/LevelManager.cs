using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private float waktu;
    private bool isRunning = true;
    public float bintang2;
    public float bintang3;
    public bool isLevelCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning) {
            waktu += Time.deltaTime;
            //Debug.Log(waktu);
        }
        
    }

    public void LevelSystem() {
        isRunning = false;
        int bintang = hitungBintang(waktu);
        int LevelNumber = SceneManager.GetActiveScene().buildIndex - 1;
        PlayerPrefs.SetFloat("Timer_Level" + LevelNumber, waktu);
        PlayerPrefs.SetInt("Star_Level" + LevelNumber, bintang);
        //Debug.Log("LevelNumber index : " + LevelNumber);
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
