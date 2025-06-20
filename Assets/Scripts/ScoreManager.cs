using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ScoreManager : MonoBehaviour
{
    private int score;

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("You heeft een munt opgepakt!");
    }

    private void Update()
    {
        Debug.Log("Uw score is" + score);
    }
}
