using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
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
    public string mode;
    public GameObject Thorn;
    public GameObject GameWinPanel;
    //private int SceneIndex = 1;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Audio.gameObject.SetActive(false);
        GameWinPanel.gameObject.SetActive(false);
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

    public void ChangeScene() {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings) {
            WinGameSound.Play();
            GameWinPanel.gameObject.SetActive(true);
            Time.timeScale = 0;
            return;
            //nextSceneIndex = 0; // Scene pertama (Lv1)
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

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

    public IEnumerator CDChangeScene() {
        yield return new WaitForSeconds(1.5f);
        ChangeScene();     
    }




}
