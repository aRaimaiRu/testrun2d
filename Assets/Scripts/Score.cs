using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public float score =0f;
    public Text ScoreText;


    void Update() {
        ScoreText.text = ((int)score).ToString();
    }
}