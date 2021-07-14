using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;


public class OnlineManager {
    // Start is called before the first frame update
    ILeaderboard m_Leaderboard;
    public bool Authenticate()
    {
        bool m_Success = false;
        Social.localUser.Authenticate(success => {
            if (success)
            {
                Debug.Log("Authentication successful");
                string userInfo = "Username: " + Social.localUser.userName +
                    "\tUser ID: " + Social.localUser.id +
                    "\tIsUnderage: " + Social.localUser.underage;
                Debug.Log(userInfo);

                LeaderBoardManager l = new LeaderBoardManager();
                m_Leaderboard = l.GetLeaderboard();

                m_Leaderboard.LoadScores(result => DidLoadLeaderboard(result));
                m_Success = true;
    
            }
            else {
                Debug.Log("Authentication failed");
                m_Success = false;
            }
        });

        return m_Success;
    }


    void DidLoadLeaderboard(bool result)
    {
        Debug.Log("Received " + m_Leaderboard.scores.Length + " scores");
        foreach (IScore score in m_Leaderboard.scores)
            Debug.Log(score);
    }



    public void ReportScore() 
    {
            Social.ReportScore(4,"snakeAndLadderHD",HighScoreCheck);
    }

    public void ShowLeaderBoardUI(){
        Social.ShowLeaderboardUI();
    }


    static void HighScoreCheck(bool result) 
    {
        if(result)
            Debug.Log("score submission successful");
        else
            Debug.Log("score submission failed");
    }
}
