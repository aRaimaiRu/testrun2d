using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public GameObject WinMenu;
    public GameObject GameplayUI;
    // Start is called before the first frame update
    public void Win(){
        WinMenu.SetActive(true);
        GameplayUI.SetActive(false);
    }
    public void Death(){
        Time.timeScale = 0f;
        WinMenu.SetActive(false);
        GameplayUI.SetActive(false);
    }
}