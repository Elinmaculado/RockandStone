using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text score;
    private int scoreAmount;
    public int profit = 1;
    void Start()
    {
        scoreAmount = 0;
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = scoreAmount.ToString();
    }

    public void AddScore()
    {
        scoreAmount += profit; 
    }
}
