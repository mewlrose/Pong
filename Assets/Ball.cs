﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
    public float originalSpeed = 40;
    private Rigidbody2D body;
    private ScoreManager scoreManager;
    public float speed;
    public float accelerationRate = 10;

    void Start()
    {
        speed = originalSpeed;
        body = GetComponent<Rigidbody2D>();
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        
        ResetBall();
    }

    void ResetBall()
    {
        
        transform.position = new Vector2(0, 0);
        body.velocity = new Vector2(5f, Random.Range(-2, 2)).normalized * speed;
        speed = originalSpeed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject collideObj = col.gameObject;
        float vertAttackAngle = (transform.position.y - col.transform.position.y)/col.collider.bounds.size.y;
        
        if (collideObj.name == "RacketLeft" || collideObj.name == "RacketRight"){

            body.velocity = new Vector2(
                                (collideObj.name == "RacketLeft") ? 1 : -1,
                                vertAttackAngle).normalized * speed;
            
            scoreManager.ScoreUpdate(collideObj.name == "RacketLeft" ? 1 : 2, 1);

        }

        if (collideObj.name == "Barrier"){

            body.velocity = new Vector2(1, vertAttackAngle).normalized * speed;
            
        }
        speed += accelerationRate;

    }

    void OnTriggerEnter2D(Collider2D trigger)
    {

        if (trigger.name == "WallLeft" || trigger.name == "WallRight"){
            scoreManager.ScoreUpdate(trigger.name == "WallRight" ? 1 : 2, 5);
        }

        ResetBall();
    }


}
