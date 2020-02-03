using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Transform Player;
    public float speed;
    private Vector2 TargetPos;

    private PlayerScript playerScript;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        TargetPos = new Vector2(Player.position.x, Player.position.y);
        playerScript = GameObject.FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameOver == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, TargetPos, speed * Time.fixedDeltaTime);
            if (transform.position.x == TargetPos.x && transform.position.y == TargetPos.y)
            {
                Destroy(gameObject);
            }
        }

        if (GameManager.Instance.IsPhase2Active == true)
        {
            speed = 3f;

        }
    }
}
