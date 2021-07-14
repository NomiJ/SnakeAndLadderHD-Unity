using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCup : MonoBehaviour
{
    public GameObject diceObject;
    public int turn = 1;

    private Animator animator;

    private int rollOnce = 0;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.instance.canWin == true)
        {
            if (turn == 1)
            {
                if (Input.GetMouseButtonDown(0) && GameManager.instance.playerTurn == 1)
                {
                    StartCoroutine(Roll());
                    rollOnce = 0;
                }

            }
            else if (turn == 2 && GameManager.instance.playerTurn == 2)
            {
                if (rollOnce == 0)
                {
                    StartCoroutine(Roll());
                    rollOnce = 1;
                }

            }

        }

    }

    public void RollDice()
    {
        Instantiate(diceObject, transform.position, transform.rotation);
    }

    IEnumerator Roll()
    {
        animator.SetBool("Shake", true);

        yield return new WaitForSeconds(0.6f);

        animator.SetBool("Shake", false);
        
        if(GameManager.instance.playerTurn == 1)
        {
            GameManager.instance.playerTurn = 2;
            rollOnce = 0;
        }
        else if (GameManager.instance.playerTurn == 2)
        {
            GameManager.instance.playerTurn = 1;
            rollOnce = 0;
        }

    }

}
