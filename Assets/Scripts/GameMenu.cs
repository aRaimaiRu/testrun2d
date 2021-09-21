using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public Text highScoreText;
    // Start is called before the first frame update
    private void Start() {
        highScoreText.text = "Highscore : "+(int) PlayerPrefs.GetFloat("Highscore");
    }
    public void Play(){
        SceneManager.LoadScene("gameplay");
    }
}
