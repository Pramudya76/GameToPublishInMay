using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider volumeMusic;
    public Slider volumeMaster;
    public AudioMixer mixerMusic;
    public AudioMixer mixerMaster;
    public GameObject Audio;
    public AudioSource music;
    public AudioSource jumpSound;
    public AudioSource deadSound;
    public AudioSource StickySound;
    public AudioSource StoneSound;
    public AudioSource GateSound;
    public AudioSource CatcheStarSound;
    public AudioSource WinGameSound;
    private Vector3 startPosition;
    private GameObject player;
    private GameObject StoneMode;
    private GameObject StickyMode;
    public GameObject playerPrefabs;
    public GameObject StonePrefabs;
    public GameObject StickyPrefabs;
    public bool isDead;
    public string mode = "Mode1";
    public GameObject Thorn;
    public GameObject GameWinPanel;
    public GameObject FloorPrefabs;
    private LevelManager LM;
    public GameObject EyesPrefabs;
    private Light2D light2D;
    //private int SceneIndex = 1;
    // Start is called before the first frame update
    void Start()
    {
        Audio.gameObject.SetActive(false);
        GameWinPanel.gameObject.SetActive(false);
        if(light2D == null) {
            GameObject lightObject2D = GameObject.FindWithTag("Light");
            if(lightObject2D != null) {
                light2D = lightObject2D.GetComponent<Light2D>();
            }
        }
        Time.timeScale = 1;
        LM = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>();
        if(PlayerPrefs.HasKey("vol")) {
            float saveVol = PlayerPrefs.GetFloat("vol");
            volumeMusic.value = saveVol;
        }else {
            mixerMusic.SetFloat("vol", 0);
            volumeMusic.value = 0f;
        }
        if(PlayerPrefs.HasKey("MasterVolume")) {
            float saveMaster = PlayerPrefs.GetFloat("MasterVolume");
            volumeMaster.value = saveMaster;
        }else {
            mixerMaster.SetFloat("MasterVolume", 0);
            volumeMaster.value = 0f;
        }
        player = GameObject.FindWithTag("Player");
        StoneMode = GameObject.FindWithTag("StoneMode");
        StickyMode = GameObject.FindWithTag("StickyMode");
        //Thorn = GameObject.FindWithTag("Thorns");
        if(player != null) {
            startPosition = player.transform.position;
            Debug.Log("Berjalan");
        }



        music.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Audio.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        
        
    }

    public void callRespawn() {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn() {
        yield return new WaitForSeconds(0.1f);
        if(player == null && isDead && mode == "player") {
            player = Instantiate(playerPrefabs, startPosition, Quaternion.identity);
            deadSound.Play();
        }else if(StoneMode == null && isDead && mode == "StoneMode") {
            StoneMode = Instantiate(StonePrefabs, startPosition, Quaternion.identity);
            deadSound.Play();
        }else if(StickyMode == null && isDead && mode == "StickyMode") {
            StickyMode = Instantiate(StickyPrefabs, startPosition, Quaternion.identity);
            deadSound.Play();
        }
    }

    public void LevelDoneScene() {
        GameWinPanel.SetActive(true);
        LM.LevelDonePanelinGameWin();
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if(LM.waktu <= LM.bintang3) {
            LM.Star1.SetActive(true);
            LM.Star2.SetActive(true);
            LM.Star3.SetActive(true);
            LM.Star0_2Position.SetActive(false);
            LM.Star0_3Position.SetActive(false);
        }else if(LM.waktu > LM.bintang3 && LM.waktu <= LM.bintang2) {
            LM.Star1.SetActive(true);
            LM.Star2.SetActive(true);
            LM.Star3.SetActive(false);
            LM.Star0_2Position.SetActive(false);
            LM.Star0_3Position.SetActive(true);
        }else {
            LM.Star1.SetActive(true);
            LM.Star2.SetActive(false);
            LM.Star3.SetActive(false);
            LM.Star0_2Position.SetActive(true);
            LM.Star0_3Position.SetActive(true);
        }
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings) {
            WinGameSound.Play();
            //GameWinPanel.gameObject.SetActive(true);
            //Time.timeScale = 0;
            return;
            
        }
        Time.timeScale = 0;
        // if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings) {
        //     WinGameSound.Play();
        //     GameWinPanel.gameObject.SetActive(true);
        //     Time.timeScale = 0;
        // }else {
        //     GameWinPanel.gameObject.SetActive(true);
        //     LM.LevelDonePanel();
        //     Time.timeScale = 0;
        // }
        //PlayerPrefs.SetInt("HasSaveData", 1);
        //SceneManager.LoadScene(nextSceneIndex);
    }

    public void ChangeScene() {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        // if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings) {
        //     WinGameSound.Play();
        //     GameWinPanel.gameObject.SetActive(true);
        //     Time.timeScale = 0;
        //     return;
            
        // }
        PlayerPrefs.SetInt("HasSaveData", 1);
        SceneManager.LoadScene(nextSceneIndex);
    }

    // IEnumerator CDChangeScene() {
    //     yield return new WaitForSeconds(1f);
    //     ChangeScene();
    // }

    // public void CallCDChangeScene() {
    //     StartCoroutine(CDChangeScene());
    // }

    public void backToMenu() {
        SceneManager.LoadScene("MainMenu");
        WinGameSound.Stop();

    }


    public void ExitGame() {
        PlayerPrefs.DeleteKey("vol");
        PlayerPrefs.DeleteKey("MasterVolume");
        Application.Quit();
    }

    public void AudioSetting() {
        Audio.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ExitAudioSetting() {
        Audio.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void settingAudioMusic() {
        mixerMusic.SetFloat("vol", volumeMusic.value);
        PlayerPrefs.SetFloat("vol", volumeMusic.value);
        PlayerPrefs.Save();
    }

    public void settingAudioMaster() {
        mixerMaster.SetFloat("MasterVolume", volumeMaster.value);
        PlayerPrefs.SetFloat("MasterVolume", volumeMaster.value);
        PlayerPrefs.Save();
    }


    public IEnumerator callThornsBack(Vector3 thornsPosition) {
        yield return new WaitForSeconds(3f);
        Debug.Log("jalannnnnn");
        Instantiate(Thorn, thornsPosition, Thorn.transform.rotation);
    }

    public IEnumerator CDChangeToGameWin() {
        yield return new WaitForSeconds(1.5f);
        LevelDoneScene();    
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void SpawnFloor(Vector3 positionFloor) {
        StartCoroutine(CDSpawnFloorAfterDestroy(positionFloor));
    }

    IEnumerator CDSpawnFloorAfterDestroy(Vector3 positionFloor) {
        yield return new WaitForSeconds(3f);
        Instantiate(FloorPrefabs, positionFloor, Quaternion.identity);
    }

    public void newGame() {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("HasSaveData", 1);
        ChangeScene();
    }

    public void SpawnEyes(Transform posisi) {
        StartCoroutine(CDEyesSpawn(posisi));
    }

    IEnumerator CDEyesSpawn(Transform posisi) {
        yield return new WaitForSeconds(3f);
        light2D.pointLightOuterRadius = 3.6f;
        Instantiate(EyesPrefabs, posisi.position, Quaternion.identity);
    }




}
