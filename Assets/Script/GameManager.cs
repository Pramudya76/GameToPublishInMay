using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int SceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        // if(!PlayerPrefs.HasKey("SceneIndex")) {
        //     PlayerPrefs.SetInt("SceneIndex", 1);
        //     PlayerPrefs.Save();
        // }
        SceneIndex = PlayerPrefs.GetInt("SceneIndex", 1);     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene() {
        SceneIndex++;
        if (SceneIndex > 3) SceneIndex = 1; 
        PlayerPrefs.SetInt("SceneIndex", SceneIndex);
        PlayerPrefs.Save();
        string nextScene = "Lv" + SceneIndex;
        SceneManager.LoadScene(nextScene);  
        Debug.Log(nextScene);
        
    }

}
