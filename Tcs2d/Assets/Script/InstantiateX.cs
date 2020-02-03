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

    private void Update()
    {
        if (GameManager.Instance.IsPhase2Active == true)
        {
            Count = 15;
        }

        if (GameManager.Instance.BossFight == true)
        {
            this.gameObject.SetActive(false);
        }
    }
    void StartEnemySpawn()
    {
        if (Count != 0 && playerScript.IsPlayerAlive==true && GameManager.Instance.BossFight == false)
        {
            SpawnTime = Random.Range(1f, 3f);
           
            Vector2 InstantiatePositon = new Vector2(Random.Range(MinX, MaxX), transform.position.y);
            GameObject Enemy = Instantiate(EnemeyPrefeb, InstantiatePositon, Quaternion.identity);
            Count--;
        }
    }
}
