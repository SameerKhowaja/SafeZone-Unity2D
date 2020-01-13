using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    public Rigidbody2D enemy;
    public GameObject blast;
    private Transform player;
    float speed;
    int spinSpeed = 180;
    Vector3 Target_pos;

    void Start()
    {
        speed = Random.Range(3f, 5f);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Target_pos = new Vector2(player.position.x, player.position.y);
    }

    
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target_pos, speed * Time.fixedDeltaTime);
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);

        if (transform.position == Target_pos)
        {
            endGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "enemy" || collision.collider.tag == "Player" || collision.collider.tag == "coin")
        {
            endGame();
        }
    }


    void endGame()
    {
        GameObject Blast_effect = Instantiate(blast, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(Blast_effect, 0.8f);
    }

}
