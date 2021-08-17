using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
     public string URL = "https://github.com/harrypaul961/Alpha";

     public void PlayGame()
     {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
     }

     public void QuitGame()
     {
         Application.Quit();
     }

     public void loadurl()
     {
         Application.OpenURL(URL);
     }
}

