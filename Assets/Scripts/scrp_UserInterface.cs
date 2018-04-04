using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scrp_UserInterface : MonoBehaviour {

    public Text m_UITimer;
    private float m_Timer = 90.0f;
    public Text m_UIPlayer1Score;
    public Text m_UIPlayer2Score;
	
	// Update is called once per frame
	void Update ()
    {
        m_Timer -= Time.deltaTime;
        m_UITimer.text = "Timer: " + ((int)m_Timer).ToString();

		//if(m_Timer < 0)
		//{
		//	SceneManager.LoadScene("Level01");
		//}

		//m_UIPlayer1Score.text = "Player 1 Score:";
		//m_UIPlayer2Score.text = "Player 2 Score:";
	}

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
