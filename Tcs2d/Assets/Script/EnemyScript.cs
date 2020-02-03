using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //Enenmy Move
    public float speed;
    public Transform PlayerPos;

    //EnemyShoot
    public GameObject EnemyBulletPrefeb;
    public float bullspeed;
    public Transform ShootPos;

    public float SpawnTime;
    void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("EnemyShoot", SpawnTime, 5f);
    
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, PlayerPos.position) > 2)
        {
           transform.position = Vector2.MoveTowards(transform.position, PlayerPos.position, speed * Time.fixedDeltaTime);
        }
    }

    void EnemyShoot()
    {
        SpawnTime = Random.Range(1f, 5f);
        GameObject bull = Instantiate(EnemyBulletPrefeb, ShootPos.position, Quaternion.identity);
       
    }
}
