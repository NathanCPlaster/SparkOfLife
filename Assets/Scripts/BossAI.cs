using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    /*
     public Rigidbody2D rb;
     public float accelerationTime = 2f;
     public float maxSpeed = 5f;
     private Vector2 movement;
     private float timeLeft;
 */
    public Transform player;
    public float speed = 2f;
    private float minDistance = 8f;
    private float range;

    void Update()
    {
        /*      timeLeft -= Time.deltaTime;
              if (timeLeft <= 0)
              {
                  movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                  timeLeft += accelerationTime;
              }
        */
        range = Vector2.Distance(transform.position, player.position);
        if (range < minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -1 * speed * Time.deltaTime);
        }

    }
/*
    void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed);
    }
*/
}
