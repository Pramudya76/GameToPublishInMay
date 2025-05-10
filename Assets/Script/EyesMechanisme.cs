using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Rendering.Universal;
using UnityEngine.XR;

public class EyesMechanisme : MonoBehaviour
{
    private bool isDestroy = false;
    private Transform[] points;
    private GameManager GM;
    private Light2D light2D;
    private float OuterLight2D;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        light2D = GameObject.FindWithTag("Light").GetComponent<Light2D>();
        Transform pointsEyesParent = GameObject.FindWithTag("PointsEyes").transform;
        points = new Transform[pointsEyesParent.childCount];
        for(int a = 0; a < pointsEyesParent.childCount; a++) {
            points[a] = pointsEyesParent.GetChild(a);
        }
        OuterLight2D = light2D.pointLightOuterRadius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(isDestroy) return;

        if(collision.gameObject.tag == "Bones" || collision.gameObject.tag == "StoneMode") {
            isDestroy = true;
            light2D.pointLightOuterRadius = 1000;
            int RandomSpawn = Random.Range(0, points.Length);
            GM.SpawnEyes(points[RandomSpawn]);
            Destroy(gameObject);
        }
    }


}
