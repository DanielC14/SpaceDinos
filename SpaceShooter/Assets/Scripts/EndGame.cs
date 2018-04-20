using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

    public Text scoreText;
    public GameObject new_highscore;
    public GameObject deadcontainer;

	// Use this for initialization
	void Start () {
        new_highscore.SetActive(false);
        deadcontainer.SetActive(false);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleEndMenu()
    {
        deadcontainer.SetActive(true); 
        scoreText.text = ((int)Game.score).ToString();
        if (Game.score > PlayerPrefs.GetFloat("highscore"))
        {
            PlayerPrefs.SetFloat("highscore", Game.score);
            new_highscore.SetActive(true);
            
        }
        
    }

    public void RestartGame()
    {
        PlayerMove.isDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
