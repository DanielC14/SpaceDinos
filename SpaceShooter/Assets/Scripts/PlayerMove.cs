using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 20;
    public float movespeed = 40;
    public static bool isDead = false;
    public EndGame endgame;
    public AudioClip explosion;
    public AudioClip dinoAttack;
    AudioSource audioSource;
    public static bool isFast = false;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        isDead = false;
        isFast = false;
    }

    // Update is called once per frame
    void FixedUpdate () {
        
        if(!isDead)
        {
            if(speed > 150f)
            {
                isFast = true;
            }

            if (speed < 350f)
            {
                speed += 0.05f;
            }
            if (movespeed < 50f)
            {
                movespeed += 0.005f;
            }

            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * movespeed, 0, 1 * speed * Time.deltaTime);
            
        }
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Dino")
        {
            Game.StopAllAudio();
            audioSource.PlayOneShot(explosion, 1f);
            audioSource.PlayOneShot(dinoAttack, 1f);
            isDead = true;
            endgame.ToggleEndMenu();
        }
    }


}
