using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{
    public spawnFirePoints spn;
    public playerMovement pm;
    public coinScript cp;
    public Text live;
    public AudioSource gameoverSound, backMusic, hurtSoundFalse;
    int zero = 0;

    void Start()
    {
        spn.enabled = pm.enabled = cp.enabled = false;
        StartCoroutine(wait());
    }

    private void Update()
    {
        live.text = zero.ToString();

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator wait()
    {
        hurtSoundFalse.Stop();
        backMusic.Stop();
        gameoverSound.Play();
        hurtSoundFalse.mute = true;
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("lvl01");
    }

}
