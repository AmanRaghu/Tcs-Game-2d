using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateY : MonoBehaviour
{
    private PlayerScript playerScript;
    public GameObject EnemyPrefeb;
    public float MinY;
    public float MaxY;
    public int count;
    public float SpawnTime;
    
    void Start()
    {
        playerScript = GameObject.FindObjectOfType<PlayerScript>();
        InvokeRepeating("SpawnEnemy", SpawnTime, Random.Range(1f,4f));
    }
    private void Update()
    {
       

    }
    void SpawnEnemy()
    {
        if (count != 0 && playerScript.IsPlayerAlive==true)
        {
            SpawnTime = Random.Range(1f, 4f);
            
            Vector2 SpawnY = new Vector2(transform.position.x, Random.Range(MinY, MaxY));
          GameObject enemy = Instantiate(EnemyPrefeb, SpawnY, Quaternion.identity);
            count--;
        }
    }
}
