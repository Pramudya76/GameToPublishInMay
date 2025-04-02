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
    //private int SceneIndex = 1;
    // Start is called before the first frame update
    void Start()
    {
        Audio.gameObject.SetActive(false);
        if(PlayerPrefs.HasKey("vol")) {
            float saveVol = PlayerPrefs.GetFloat("vol");
            volumeMusic.value = saveVol;
        }else {
            mixerMusic.SetFloat("vol", 0);
            volumeMusic.value = 0f;
        }
        music.Play();


        //Time.timeScale = 1;
        // if(!PlayerPrefs.HasKey("SceneIndex")) {
        //     PlayerPrefs.SetInt("SceneIndex", 1);
        //     PlayerPrefs.Save();
        // }
        //SceneIndex = PlayerPrefs.GetInt("SceneIndex", 1);     
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Audio.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ChangeScene() {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings) {
            nextSceneIndex = 0; // Scene pertama (Lv1)
        }

        SceneManager.LoadScene(nextSceneIndex);
    }


    public void ExitGame() {
        PlayerPrefs.DeleteKey("vol");
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
    }




}
