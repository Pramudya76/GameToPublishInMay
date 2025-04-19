using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private AIPath path;
    [SerializeField] private float moveSpeed;
    private Transform DefaultMode;
    private Transform StoneMode;
    private Transform StickyMode;
    public GameObject[] points;
    private int indexPoints;
    private bool isArea = false;
    private bool hasPoints;
    private bool isChange = false;
    //public LayerMask layer;
    //public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        path = GetComponent<AIPath>();
        
    }

    // Update is called once per frame
    void Update()
    {
        path.maxSpeed = moveSpeed;
        GameObject ModeDefault = GameObject.FindWithTag("Bones");
        GameObject ModeStone = GameObject.FindWithTag("StoneMode");
        GameObject ModeSticky = GameObject.FindWithTag("StickyMode");

        if(ModeDefault != null) {
            DefaultMode = ModeDefault.transform;
        }else if(ModeStone != null) {
            StoneMode = ModeStone.transform;
        }else if(ModeSticky != null) {
            StickyMode = ModeSticky.transform;
        }
        if(isArea) {
            if(DefaultMode != null && isArea) {
                path.destination = DefaultMode.position;
                hasPoints = false;
            }
            if(StoneMode != null && isArea) {
                path.destination = StoneMode.position;
                hasPoints = false;
            }
            if(StickyMode != null && isArea) {
                path.destination = StickyMode.position;
                hasPoints = false;
            }
        }else {
            //hasPoints = true;
            if(!hasPoints) {
                indexPoints = Random.Range(0, points.Length);
                path.destination = points[indexPoints].transform.position;
                hasPoints = true;
                isChange = false;
                Debug.Log("index : " + indexPoints);
            }

            if(Vector2.Distance(transform.position, points[indexPoints].transform.position) <= 1f && !isChange) {
                Debug.Log("Reached point: " + indexPoints);
                //hasPoints = false;
                StartCoroutine(CDChangePosition());
            }


        }


        // Collider2D EnemyArea = Physics2D.OverlapCircle(transform.position, 2f);
        // if(EnemyArea != null && (EnemyArea.gameObject.tag == "Bones" || EnemyArea.gameObject.tag == "StoneMode")) {
            
        // }

        // Cek kalau semua target udah null tapi enemy masih dalam area
        if (isArea && DefaultMode == null && StoneMode == null && StickyMode == null)
        {
            isArea = false;
            hasPoints = false;
            Debug.Log("Target hilang (destroyed), kembali ke patrol.");
        }



    }

    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red; // Warna Gizmo
    //     Gizmos.DrawWireSphere(transform.position, 5f); // Menggambar bola di posisi objek
    // }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isArea) return;

        if(collision.gameObject.tag == "Bones" || collision.gameObject.tag == "StoneMode") {
            isArea = true;
            path.maxSpeed = moveSpeed;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bones" || collision.gameObject.tag == "StoneMode") {
            isArea = false;
        }
    }

    IEnumerator CDChangePosition() {
        isChange = true;
        yield return new WaitForSeconds(2f);
        hasPoints = false;
    }


}
