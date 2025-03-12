using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //private int SceneIndex = 1;
    // Start is called before the first frame update
    void Start()
    {
        // if(!PlayerPrefs.HasKey("SceneIndex")) {
        //     PlayerPrefs.SetInt("SceneIndex", 1);
        //     PlayerPrefs.Save();
        // }
        //SceneIndex = PlayerPrefs.GetInt("SceneIndex", 1);     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene() {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings) {
            nextSceneIndex = 0; // Scene pertama (Lv1)
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

}
