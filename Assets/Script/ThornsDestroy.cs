using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThornsDestroy : MonoBehaviour
{
    private GameManager GM;
    private Vector3 thornsPosition;
    // Start is called before the first frame update
    void Start()
    {
        GameObject GameManagerObject = GameObject.FindWithTag("GameManager");
        GM = GameManagerObject.GetComponent<GameManager>();
        thornsPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground") {
            //StartCoroutine(callThorns());
            GM.StartCoroutine(GM.callThornsBack(thornsPosition));
            Destroy(gameObject);
        }
    }
    // IEnumerator callThorns() {
    //     yield return new WaitForSeconds(3f);
    //     GM.callThornsBack(transform.position);
    // }



}
