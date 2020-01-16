using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Text point_Gain, lives_lost;
    public Camera cam;
    public float speed;
    public Animator animator;
    Vector2 movement, screenPos, playerPos;
    float xPosScreen, yPosScreen;
    public int points, lives;
    public endGame endgame;
    public Text gameOverText1, gameOverText2;
    public AudioSource hurtSound;

    private void Start()
    {
        lives = 3;
        speed = 3.5f;
        points = 0;
        lives_lost.text = lives.ToString();
    }

    void Update()
    {
        //For Mobile JoyButton Input System
        movement.x = SimpleInput.GetAxisRaw("Horizontal");
        movement.y = SimpleInput.GetAxisRaw("Vertical");
        //

        //For KeyBoard Input System
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        //

        xPosScreen = Screen.width;
        yPosScreen = Screen.height;
        screenPos = new Vector3(xPosScreen, yPosScreen, 0f);
        //Debug.Log(screenPos);

        playerPos = cam.WorldToScreenPoint(transform.position);
        //Debug.Log(playerPos);

        if (movement.x < 0 || movement.x < -1) // for flip player side animation
        {
            transform.localScale = new Vector3(-1f,1f,1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (lives < 1)
        {
            gameOverText1.enabled = gameOverText2.enabled = true;
            endgame.enabled = true;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        pos();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "enemy")
        {
            lives--;
            hurtSound.Play();
            lives_lost.text = lives.ToString();
        }

        if (collision.collider.tag == "coin")
        {
            points += 10;
            point_Gain.text = points.ToString();
            //Debug.Log("Coin : "+ points);
        }
    }

    //Code for making player dont go outside the screen
    void pos()
    {
        if (playerPos.x > screenPos.x)
        {
            transform.position = new Vector3(-transform.position.x+0.1f, transform.position.y, 0f);
        }
        if (playerPos.x <= 0)
        {
            transform.position = new Vector3(-transform.position.x-0.2f, transform.position.y, 0f);
        }
        if (playerPos.y > screenPos.y)
        {
            transform.position = new Vector3(transform.position.x, -transform.position.y+0.1f, 0f);
        }
        if (playerPos.y <= 0)
        {
            transform.position = new Vector3(transform.position.x, -transform.position.y-0.2f, 0f);
        }
    }

}
