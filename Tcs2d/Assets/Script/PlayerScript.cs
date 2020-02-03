using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //For Movement
    public float speed;
    private Rigidbody2D rb;
    Vector2 mousePos;

    //For clamping
    public float MaxX;
    public float MinX;
    public float MaxY;
    public float MinY;
    
    //For Shoot
    public GameObject PlayerBulletPrefeb;
    public Transform ShootPosition;
    public float BulletSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //move Player
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up *speed* Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
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
    }

    void Shoot()
    {
        GameObject bull = Instantiate(PlayerBulletPrefeb, ShootPosition.position, Quaternion.identity);
        bull.GetComponent<Rigidbody2D>().AddForce(ShootPosition.up * BulletSpeed * Time.fixedDeltaTime);
    }


}
