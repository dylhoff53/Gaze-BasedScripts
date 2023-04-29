using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Transform player;
    public Text scoreText;
    public int playerScore;
    public int comboCounter;
    public Text comboText;
    public GameObject comboTextScreen;
    public float timer;
    public float muti;

    void Update()
    {
        timer -= Time.deltaTime * muti;
        if(timer <= 0)
        {
            timer = 1f;
            comboCounter = 0;
            comboTextScreen.SetActive(false);
        }
    }

    public void ChangeScore(int change)
    {
        playerScore += change;
        scoreText.text = "Score: " + playerScore.ToString("0");
    }

    public void ComboIncrese()
    {
        comboCounter++;
        timer = 1f;
        if(comboCounter == 1)
        {
            comboTextScreen.SetActive(true);
        }
        comboText.text = "Combo: " + comboCounter;
    }


}
