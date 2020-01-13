using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startGame : MonoBehaviour
{
    public spawnFirePoints spn;
    public playerMovement pm;
    public coinScript cp;
    public Text startGameTxt;
    public AudioSource bounusStartSound;

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            bounusStartSound.Play();
            startGameTxt.enabled = false;
            spn.enabled = pm.enabled = cp.enabled = true;
            this.enabled = false;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}
