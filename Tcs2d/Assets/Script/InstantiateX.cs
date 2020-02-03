using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateX : MonoBehaviour
{
    public GameObject EnemeyPrefeb;
    public int Count;

    public float MinX;
    public float MaxX;
   

    private void Start()
    {
        InvokeRepeating("StartEnemySpawn", 1f, 1f);
    }
    void StartEnemySpawn()
    {
        if (Count != 0)
        {
            Vector2 InstantiatePositon = new Vector2(Random.Range(MinX, MaxX), transform.position.y);
            GameObject Enemy = Instantiate(EnemeyPrefeb, InstantiatePositon, Quaternion.identity);
            Count--;
        }
    }
}
