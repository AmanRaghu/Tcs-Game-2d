using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateY : MonoBehaviour
{
    public GameObject EnemyPrefeb;
    public float MinY;
    public float MaxY;
    public int count;
    public float SpawnTime;
    public float SpawnRate;
    void Start()
    {
       
        InvokeRepeating("SpawnEnemy", SpawnTime, SpawnRate);
    }
    private void Update()
    {
       

    }
    void SpawnEnemy()
    {
        if (count != 0)
        {
            SpawnTime = Random.Range(1f, 4f);
            SpawnRate = Random.Range(1f, 3f);
            Vector2 SpawnY = new Vector2(transform.position.x, Random.Range(MinY, MaxY));
          GameObject enemy = Instantiate(EnemyPrefeb, SpawnY, Quaternion.identity);
            count--;
        }
    }
}
