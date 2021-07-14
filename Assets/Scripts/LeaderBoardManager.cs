using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;

public class LeaderBoardManager {
    // Start is called before the first frame update
    public ILeaderboard GetLeaderboard()
    {
        ILeaderboard leaderboard = Social.CreateLeaderboard();
        leaderboard.id = "snakeAndLadderHD";
        return leaderboard;
        
    }

}
