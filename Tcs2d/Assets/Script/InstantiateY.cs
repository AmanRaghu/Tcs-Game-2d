using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateY : MonoBehaviour
{
    public GameObject EnemyPrefeb;
    public float MinY;
    public float MaxY;
    public int count;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 5f, 1f);
    }

    void SpawnEnemy()
    {
        if (count != 0)
        {
         Vector2 SpawnY = new Vector2(transform.position.x, Random.Range(MinY, MaxY));
          GameObject enemy = Instantiate(EnemyPrefeb, SpawnY, Quaternion.identity);
            count--;
        }
    }
}
