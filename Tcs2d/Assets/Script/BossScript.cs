using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossScript : MonoBehaviour
{
    public float moveSpeed;
    public GameObject Bullet;
    public Transform[] BulletShootPos;
    public bool IsMovingUp;
    public bool IsMovingDown;
    public float MaxY;
    public float MinY;
    public float bulletSpeed;
    public Image health;
    public float healths=1f;
    void Start()
    {
        StartCoroutine(WaitForEnabel());
        InvokeRepeating("Shoot", Random.Range(1f,3f),Random.Range(1f,4f));
    }

    void Update()
    {
        health.fillAmount = healths;   
        if (IsMovingUp== true)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }

        if (IsMovingDown == true)
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }

        if (transform.position.y > MaxY)
        {
            IsMovingDown = true;
            IsMovingUp = false;
        }
        else if (transform.position.y < MinY)
        {
            IsMovingUp = true;
            IsMovingDown = false;
        }

        if (healths < 0)
        {
            this.gameObject.SetActive(false);
            GameManager.Instance.IsGameOver = true;
        }
    }

    void Shoot()
    {
        for (int i = 0; i < BulletShootPos.Length; i++)
        {
            GameObject bull = Instantiate(Bullet, BulletShootPos[i].position, Quaternion.identity);
            
         }
    }

    IEnumerator WaitForEnabel()
    {
        yield return new WaitForSeconds(4);
        IsMovingUp = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            healths -= 0.03f;
        }
    }
}
