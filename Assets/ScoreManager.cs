using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public Text playerOneScoreText, playerTwoScoreText;
    [HideInInspector] public int playerOneScore, playerTwoScore;
    public int winScore = 10;

    public void ScoreUpdate(int playerId){

        if (playerId == 1){playerOneScore ++;} else {playerTwoScore++;}
        ((playerId == 1) ? playerOneScoreText : playerTwoScoreText).text = 
            ((playerId == 1) ? playerOneScore : playerTwoScore).ToString();

        if (playerOneScore >= winScore || playerTwoScore >= winScore){
            SceneManager.LoadScene("Player "+ playerId.ToString() +" Win");
        }

    }
    
} 