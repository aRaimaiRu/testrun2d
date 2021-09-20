using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public GameObject PauseMenu; 
    public GameObject DeathMenu;
    public GameObject WinMenu;
    public GameObject GameplayUI;
    // Start is called before the first frame update
    public void Resume(){
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        GameplayUI.SetActive(true);
    }
    public void Pause(){
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
        GameplayUI.SetActive(false);
    }
    public void Restart(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Death(){
        Time.timeScale = 0f;
        DeathMenu.SetActive(true);
        GameplayUI.SetActive(false);
    }
    public void Win(){
<<<<<<< HEAD
        PauseMenu.SetActive(false);
=======
        WinMenu.SetActive(true);
>>>>>>> gameMenu
        GameplayUI.SetActive(false);
        WinMenu.SetActive(true);
    }
}