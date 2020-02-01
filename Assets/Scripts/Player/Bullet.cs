﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    //public GameObject destroyEffect;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null) 
        {
            if (hitInfo.collider.CompareTag("Enemy")) 
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            else if (hitInfo.collider.CompareTag("Boss")) 
            {
                hitInfo.collider.GetComponent<BossHandler>().TakeDamage(damage);
            }
            DestroyProjectile();
        }


        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void DestroyProjectile() 
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
