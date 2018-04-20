using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Text txt_highscore;
   
	void Start () {
        txt_highscore.text = ((int)PlayerPrefs.GetFloat("highscore")).ToString();
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("space_scene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
