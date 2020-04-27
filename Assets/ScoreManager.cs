using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public Text playerOneScoreText, playerTwoScoreText;
    public int winScore = 30;

    public void ScoreUpdate(int playerId, int pointIncrement){

        Player currentPlayer = GameObject.Find((playerId == 1) ? "RacketLeft" : "RacketRight")
            .GetComponent<Player>();

        currentPlayer.score += pointIncrement;

        ((playerId == 1) ? playerOneScoreText : playerTwoScoreText).text = 
            currentPlayer.score.ToString();

        if (currentPlayer.score >= winScore) {
            SceneManager.LoadScene("Player "+ playerId.ToString() +" Win");
        }

    }

} 