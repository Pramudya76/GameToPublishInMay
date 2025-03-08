using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float sceneIndex = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene() {
        for (int i = 1; i <= 2; i++)  
    {
        string nextScene = "Lv" + i;
        if (sceneIndex > 2) sceneIndex = 1; 

        SceneManager.LoadScene(nextScene);  
    }
        
    }

}
