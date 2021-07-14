using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;    
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        Time.timeScale = 1f;
        animator.SetBool("Fade", false);
    }

    public void Player1Button()
    {
        FadeOut();
        StartCoroutine(Player1Game());
    }

    public void Player2Button()
    {
        FadeOut();
    }
    public void MultiplayerButton(){
    {
        OnlineManager om = new OnlineManager();
        if(om.Authenticate())
            om.ReportScore();
            om.ShowLeaderBoardUI();
        } 
    }

    public void RemoveAdsButton()
    {

    }

    void FadeOut()
    {
        animator.SetBool("Fade", true);
    }

    IEnumerator Player1Game()
    {
        yield return new WaitForSeconds(0.3f);

        SceneManager.LoadScene("Game");

    }
    
    public void QuitButton()
    {
        Application.Quit();
        print("Quit");
    }

}
