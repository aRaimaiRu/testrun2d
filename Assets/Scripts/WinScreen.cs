using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public Score sc;
    public Text scoreText;
    public Image BackgroundImg;
    private bool isShowned = true;
    private float transition = 0.0f;
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isShowned)return;
        transition +=Time.deltaTime;
        BackgroundImg.color = Color.Lerp(new Color(0,0,0,0),Color.black,transition);
        scoreText.text = "Score:"+((int) sc.score).ToString();
    }
    private void OnEnable() {
        
    }
}