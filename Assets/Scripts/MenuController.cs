using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public GameObject WinMenu;
    public GameObject DeathMenu;
    public GameObject GameplayUI;
    public GameObject PauseMenu;
    // Start is called before the first frame update
    public void Win(){
        WinMenu.SetActive(true);
        GameplayUI.SetActive(false);
    }
    public void Death(){
        StartCoroutine(Wait());
        DeathMenu.SetActive(true);
        PauseMenu.SetActive(false);
        WinMenu.SetActive(false);
        GameplayUI.SetActive(false);
    }
    public void Restart(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Pause(){
        Time.timeScale = 0f;
        GameplayUI.SetActive(false);
        PauseMenu.SetActive(true);
}
public void Resume(){
        Time.timeScale = 1f;
        GameplayUI.SetActive(true);
        PauseMenu.SetActive(false);
}
    IEnumerator Wait(){
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 0f;
    }
}