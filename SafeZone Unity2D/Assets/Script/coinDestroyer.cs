using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinDestroyer : MonoBehaviour
{
    public AudioSource bonusPointSound, respawnSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            bonusPointSound.Play();
            gameObject.transform.position = new Vector2(20f,0f); //outside screen //destroy after some time
        }

        if (collision.collider.tag == "enemy")
        {
            respawnSound.Play();
            gameObject.transform.position = new Vector3(-gameObject.transform.position.x, -gameObject.transform.position.y, 0f);
        }
    }

}
