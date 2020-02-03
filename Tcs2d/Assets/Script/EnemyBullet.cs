using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Transform Player;
    public float speed;
    private Vector2 TargetPos;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        TargetPos = new Vector2(Player.position.x, Player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, TargetPos, speed * Time.fixedDeltaTime);
        if (transform.position.x == TargetPos.x && transform.position.y == TargetPos.y)
        {
            Destroy(gameObject);
        }
    }
}
