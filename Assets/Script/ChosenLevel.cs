using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChosenLevel : MonoBehaviour
{
    public GameObject[] level;
    public GameObject bintang1;
    public GameObject bintang2;
    public GameObject bintang3;
    public GameObject bintang0;
    public LevelManager LM;
    public Transform parentTransform;
    private int star;
    private int levelKe;
    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.DeleteKey("Star_Level10");
        // PlayerPrefs.DeleteKey("Timer_Level10"); // Jika kamu juga ingin reset waktu
        // PlayerPrefs.Save();
        for (int i = 0; i < level.Length; i++)
        {
            levelKe = i + 1;
            star = PlayerPrefs.GetInt("Star_Level" + levelKe, 0);
            

            // Menyalakan bintang sesuai jumlahnya
            if (star == 1) {
                int index = i + 1;
                Destroy(level[i]);
                level[i] = Instantiate(bintang1, level[i].transform.position, Quaternion.identity, parentTransform);
                TextMeshProUGUI buttonText = level[i].GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = "Lv " + (i + 1);
                Button btn = level[i].GetComponentInChildren<Button>();
                btn.onClick.AddListener(() => {
                    SceneManager.LoadScene("Lv" + index);
                });
            }else if(star == 2) {
                int index = i + 1;
                Destroy(level[i]);
                level[i] = Instantiate(bintang2, level[i].transform.position, Quaternion.identity, parentTransform);
                TextMeshProUGUI buttonText = level[i].GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = "Lv " + (i + 1);
                Button btn = level[i].GetComponentInChildren<Button>();
                btn.onClick.AddListener(() => {
                    SceneManager.LoadScene("Lv" + index);
                });
            }else if(star == 3) {
                int indexp = i + 1;
                string scene = "Lv" + indexp;
                Destroy(level[i]);
                level[i] = Instantiate(bintang3, level[i].transform.position, Quaternion.identity, parentTransform);
                TextMeshProUGUI buttonText = level[i].GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = "Lv " + (i + 1);
                Button btn = level[i].GetComponentInChildren<Button>();
                btn.onClick.AddListener(() => {
                    SceneManager.LoadScene("Lv" + indexp);
                    Debug.Log("Lv " + indexp);
                });
            }
            int nextLevel =  levelKe + 1;
            int unlock = PlayerPrefs.GetInt("Level" + nextLevel + "_Unlock");

            if(unlock == 1 && nextLevel - 1 < level.Length) {
                int index = nextLevel;
                Destroy(level[i+1]);
                level[i+1] = Instantiate(bintang0, level[i+1].transform.position, Quaternion.identity, parentTransform);
                TextMeshProUGUI buttonText = level[i+1].GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = "Lv " + (nextLevel);
                Button btn = level[i+1].GetComponentInChildren<Button>();
                btn.onClick.AddListener(() => {
                    SceneManager.LoadScene("Lv" + index);
                });
            }

            


            
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        // int LevelNumber = SceneManager.GetActiveScene().buildIndex - 1;
        // for(int a = 1; a <= 5; a++) {
        //     if(PlayerPrefs.HasKey("Star_Level" + level[a])) {
        //         if(PlayerPrefs.GetInt("Star_Level" + level[a]) == 3) {

        //         }
        //     }

        // }
    }
}