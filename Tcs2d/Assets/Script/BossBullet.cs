using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed;
    
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        Destroy(gameObject, 4f);
    }
}
