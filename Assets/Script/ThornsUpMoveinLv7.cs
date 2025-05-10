using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornsUpMoveinLv7 : MonoBehaviour
{
    private float moveDistance = 0.8f;
    private float moveSpeed = 0.5f;
    private float startY;
    private bool move = false;
    private bool moving = true;
    private Vector2 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
        targetPosition = new Vector2(transform.position.x, startY + moveDistance);
    }

    // Update is called once per frame
    void Update()
    {
        if(move) return;
        
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        
        if(Vector2.Distance(transform.position, targetPosition) <= 0.1f) {
            StartCoroutine(CDStay());
        }


    }

   IEnumerator CDStay() {
        move = true;
        yield return new WaitForSeconds(2.5f);

        moving = !moving;
        float newY = moving ? startY + moveDistance : startY;
        targetPosition = new Vector2(transform.position.x, newY);

        move = false;
   }



}
