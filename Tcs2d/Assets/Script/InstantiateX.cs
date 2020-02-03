using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateX : MonoBehaviour
{
    public GameObject EnemeyPrefeb;
    public int Count;

    public float MinX;
    public float MaxX;
    public float SpawnTime;
    public float SpawnRate;
    private void Start()
    {
       
        InvokeRepeating("StartEnemySpawn", SpawnTime, SpawnRate);
    }
    void StartEnemySpawn()
    {
        if (Count != 0)
        {
            SpawnTime = Random.Range(1f, 3f);
            SpawnRate = Random.Range(2f, 4f);
            Vector2 InstantiatePositon = new Vector2(Random.Range(MinX, MaxX), transform.position.y);
            GameObject Enemy = Instantiate(EnemeyPrefeb, InstantiatePositon, Quaternion.identity);
            Count--;
        }
    }
}
