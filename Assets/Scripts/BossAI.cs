using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BossAI : MonoBehaviour
{
    public Transform player;

    public static event Action bossDeath;

    public Rigidbody2D rb;
    public float accelerationTime = 1f;
    public float maxSpeed = 3f;
    public float speed = 1f;
    private float timeLeft;
    private float minDistance = 0f;
    private float range;
    private bool shoot = true;
    private float timestamp = 0f;
    private float timestamp2 = 0f;
    private float timestamp3 = 0f;
    public float timeBetweenLine;
    public float timeBetweenCircle;
    public float timeBetweenTrack;
    private Vector2 movement;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarScript healthbar;

    public ProjectileBehaviour ProjectilePrefab;
    public Transform LaunchOffset;
    public Transform LaunchOffsetC0;
    public Transform LaunchOffsetC1;
    public Transform LaunchOffsetC2;
    public Transform LaunchOffsetC3;
    public Transform LaunchOffsetC4;
    public Transform LaunchOffsetC5;
    public Transform LaunchOffsetC6;
    public Transform LaunchOffsetC7;

    public Homing antibodyTracking;

    public Animator animator;


    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }


    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft += accelerationTime;
        }
        rb.AddForce(movement * maxSpeed);
        range = Vector2.Distance(transform.position, player.position);
        if (range < minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -1 * speed * Time.deltaTime);
        }

        transform.Rotate(0, 0, 50 * Time.deltaTime);

        if (shoot && Time.time > timestamp)
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
            timestamp = Time.time + timeBetweenLine;
        }

        if(shoot && Time.time > timestamp2)
        {
            Instantiate(ProjectilePrefab, LaunchOffsetC0.position, LaunchOffsetC0.rotation);
            Instantiate(ProjectilePrefab, LaunchOffsetC1.position, LaunchOffsetC1.rotation);
            Instantiate(ProjectilePrefab, LaunchOffsetC2.position, LaunchOffsetC2.rotation);
            Instantiate(ProjectilePrefab, LaunchOffsetC3.position, LaunchOffsetC3.rotation);
            Instantiate(ProjectilePrefab, LaunchOffsetC4.position, LaunchOffsetC4.rotation);
            Instantiate(ProjectilePrefab, LaunchOffsetC5.position, LaunchOffsetC5.rotation);
            Instantiate(ProjectilePrefab, LaunchOffsetC6.position, LaunchOffsetC6.rotation);
            Instantiate(ProjectilePrefab, LaunchOffsetC7.position, LaunchOffsetC7.rotation);
            timestamp2 = Time.time + timeBetweenCircle;
        }

        if(shoot && Time.time > timestamp3)
        {
            Instantiate(antibodyTracking, LaunchOffset.position, LaunchOffset.rotation);
            timestamp3 = Time.time + timeBetweenTrack;
        }

        if(currentHealth == 0)
        {
            Debug.Log("Boss is Dead");
            bossDeath?.Invoke();
            Time.timeScale = 0;
        }

    }

    void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            TakeDamage(10);
            healthbar.SetHealth(currentHealth);
        }
    }
}
