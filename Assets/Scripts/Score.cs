using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public int score = 0;
    public Text ScoreText;

    void Update(){
        ScoreText.text = ((int)score).ToString();
    }

        public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "item"){
            score++;
            Destroy(other.gameObject);
        }
    }
    public void OnWin(){ 
        if(score >PlayerPrefs.GetFloat("Highscore")){  //read 
        PlayerPrefs.SetFloat("Highscore",score);	//write 
 	    }
    }
}