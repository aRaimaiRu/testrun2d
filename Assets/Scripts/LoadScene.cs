using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // เพิ่มมา

public class LoadScene : MonoBehaviour
{
    public Text highScoreText; // เป็นการประกาศตัวแปรรับค่า Text
    public void LoadGame(string scenename){
        SceneManager.LoadScene(scenename);
    }
    public void ExitGame(){
        Debug.Log("Exit Game");
        Application.Quit();
    }
    private void Start() { 
        highScoreText.text = "Highscore : "+(int) PlayerPrefs.GetFloat("Highscore"); }
}
