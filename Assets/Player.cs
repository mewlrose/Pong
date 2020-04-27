using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject barrierPrefab;
    public float speed = 40;
    public string axis = "Vertical";
    public int score = 0;
    public int playerId;

    void Start(){
        playerId = axis == "Vertical" ? 1 : 2;
    }

    void FixedUpdate()
    {
        float v = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;

        if (Input.GetKeyDown(axis == "Vertical" ? KeyCode.D : KeyCode.J))
        {
            if (score>=10)
            {
                GameObject.Find("ScoreManager").GetComponent<ScoreManager>().ScoreUpdate(playerId, -10);
                var playerBarrier = (GameObject)Instantiate(    barrierPrefab, 
                                                                new Vector2(    gameObject.transform.position.x + (10 * ((playerId == 1) ? 1 : -1)), 
                                                                                gameObject.transform.position.y), 
                                                                Quaternion.identity);
                playerBarrier.SendMessage("Init", playerId);
            }
        }
    }
}
