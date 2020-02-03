using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private PlayerScript playerScript;   
    //Enenmy Move
    public float speed;

    [SerializeField]
    private Transform PlayerPos;

    //EnemyShoot
    public GameObject EnemyBulletPrefeb;
   
    public Transform ShootPos;

    public float SpawnTime;
    void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("EnemyShoot", SpawnTime, 5f);
        playerScript = GameObject.FindObjectOfType<PlayerScript>();
    }

    void FixedUpdate()
    {
       // enemy move
       if (Vector2.Distance(transform.position, PlayerPos.position) > 2 && playerScript.IsPlayerAlive==true)
       {
            transform.position = Vector2.MoveTowards(transform.position, PlayerPos.position, speed * Time.fixedDeltaTime);
        }
        

       if(GameManager.Instance.IsPhase2Active==true)
        {
            speed = 1f;
           
        }
    }

    void EnemyShoot()
    {
        if (GameManager.Instance.IsGameOver == false)
        {
            SpawnTime = Random.Range(1f, 5f);
            GameObject bull = Instantiate(EnemyBulletPrefeb, ShootPos.position, Quaternion.identity);
        }
    }
}
