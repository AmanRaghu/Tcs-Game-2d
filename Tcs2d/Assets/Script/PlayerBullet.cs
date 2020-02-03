using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    PlayerScript playerScript;

    private void Start()
    {
        playerScript = GameObject.FindObjectOfType<PlayerScript>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            playerScript.Score += 1;
        }

        if (collision.tag == "EnemyBullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);

        }
    }
}
