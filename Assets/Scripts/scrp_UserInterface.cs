using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scrp_UserInterface : MonoBehaviour
{

    public Text m_UITimer;

    //Game Timer
    private float m_Timer = 90.0f;

    public Text m_UIPlayer1Score;
    public Text m_UIPlayer2Score;

    //--------------------------------------------------------------------------------------
    // Update is called once per frame
    //      Display the updated text
    //      Restart level when timer runs out
    //--------------------------------------------------------------------------------------
    void Update()
    {
        m_Timer -= Time.deltaTime;
        m_UITimer.text = "Timer: " + ((int)m_Timer).ToString();

        if (m_Timer < 0)
        {
            SceneManager.LoadScene("Level01");
        }
    }

    //--------------------------------------------------------------------------------------
    // Set the scores to display current player score
    //
    // Param
    //		team: Which team score should change
    //		points: ho wmany points the player has
    //--------------------------------------------------------------------------------------
    public void UpdateScore(int team, int points)
    {
        switch (team)
        {
            case 1:
                m_UIPlayer1Score.text = "Player 1 Score:" + points;
                break;
            case 2:
                m_UIPlayer2Score.text = "Player 2 Score:" + points;
                break;
        }
    }
}
