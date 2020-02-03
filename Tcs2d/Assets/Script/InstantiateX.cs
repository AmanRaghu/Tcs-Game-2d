using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateX : MonoBehaviour
{
    PlayerScript playerScript;
    public GameObject EnemeyPrefeb;
    public int Count;

    public float MinX;
    public float MaxX;
    public float SpawnTime;
    
    private void Start()
    {
        playerScript = GameObject.FindObjectOfType<PlayerScript>();
        InvokeRepeating("StartEnemySpawn", SpawnTime, Random.Range(2f,5f));
    }
    void StartEnemySpawn()
    {
        if (Count != 0 && playerScript.IsPlayerAlive==true)
        {
            SpawnTime = Random.Range(1f, 3f);
           
            Vector2 InstantiatePositon = new Vector2(Random.Range(MinX, MaxX), transform.position.y);
            GameObject Enemy = Instantiate(EnemeyPrefeb, InstantiatePositon, Quaternion.identity);
            Count--;
        }
    }
}
