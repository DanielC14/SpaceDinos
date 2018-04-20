using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    public static float score;
    public Text scoreText;
    public Transform playerTransform;



    // Use this for initialization
    void Start()
    {
        score = 0;
        playerTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ((int)score).ToString();
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void FixedUpdate()
    {
        RaycastHit[] hits;

        hits = Physics.RaycastAll(playerTransform.position, playerTransform.TransformDirection(Vector3.back));

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if (hit.collider.gameObject.name == "RaycastWall")
            {
                score = hit.distance;
            }
        }


    }

    private static AudioSource[] allAudioSources;

    public static void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }


}
