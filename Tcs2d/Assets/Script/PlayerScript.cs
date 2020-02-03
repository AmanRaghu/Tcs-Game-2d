using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
    //For Movement
    public float speed;
    private Rigidbody2D rb;
    Vector2 mousePos;
    Vector2 Movement;

    //For clamping
    public float MaxX;
    public float MinX;
    public float MaxY;
    public float MinY;
    
    //For Shoot
    public GameObject PlayerBulletPrefeb;
    public Transform ShootPosition;
    public float BulletSpeed;

    //health
    public Image HealthImage;
    public float PlayerHealth = 1f;
    public bool IsPlayerAlive;

    //Score
    public Text ScoreText;
    public int Score;

    void Start()
    {
        IsPlayerAlive = true;
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        HealthImage.fillAmount = PlayerHealth;
        ScoreText.text = "Score:" + Score.ToString();
        //move Player

        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + Movement * speed * Time.deltaTime);

        //

        //Rotate with moouse
         mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos-rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x)*Mathf.Rad2Deg-90f;
        rb.rotation = angle;
        //

        //Clamp
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, MinX, MaxX), Mathf.Clamp(transform.position.y, MinY, MaxY));
        
        //

        //for Shoot
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        //


        //Check If Player Alive 
        if (PlayerHealth <= 0f)
        {
            GameManager.Instance.IsGameOver = true;
            IsPlayerAlive = false;
            gameObject.SetActive(false);
        }



        //Check For Phase 2
        if (Score == 20)
        {
            GameManager.Instance.IsPhase2Active = true;
        }

        if (Score == 40)
        {
            GameManager.Instance.IsPhase2Active = false;
            GameManager.Instance.BossFight = true;
        }
    }

    void Shoot()
    {
        GameObject bull = Instantiate(PlayerBulletPrefeb, ShootPosition.position, Quaternion.identity);
        bull.GetComponent<Rigidbody2D>().AddForce(ShootPosition.up * BulletSpeed * Time.fixedDeltaTime);
        Destroy(bull, 2f);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet")
        {
            PlayerHealth -= 0.05f;
            Destroy(collision.gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            PlayerHealth -= 0.2f;
            Destroy(collision.gameObject);
        }
    }

   
}
