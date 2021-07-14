using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float moveTime;

    public Transform[] places;
    private AIDice dice;

    private bool canMove = true;
    private int spaces;

    private int moveSpaces;
    public float timeToMove;
    private float curTimeToMove;

    public GameObject winScreen;

    void Start()
    {
        curTimeToMove = timeToMove;
    }

    void Update()
    {
        if (GameManager.instance.canWin == true)
        {
            if (dice == null)
            {
                dice = GameObject.FindGameObjectWithTag("AIDice").GetComponent<AIDice>();

                if (dice == null)
                {
                    return;
                }

            }

            if (canMove == false)
            {
                if (curTimeToMove <= 0f)
                {
                    canMove = true;
                    curTimeToMove = timeToMove;
                }
                else
                {
                    curTimeToMove -= Time.deltaTime;
                }

            }

            if (canMove == true)
            {
                moveSpaces = dice.roll;
                spaces += dice.roll;

                transform.position = places[spaces - 1].position;

                canMove = false;
                dice.roll = 0;

            }

        }
        else
        {
            return;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("END"))
        {
            if (GameManager.instance.canWin == true)
            {
                GameManager.instance.playerWon = 2;
                print("PLAYER 2 WON");

                winScreen.SetActive(true);

                GameManager.instance.canWin = false;

            }

        }

        if (collision.CompareTag("LadderSpace"))
        {
            transform.position = collision.GetComponent<Ladder>().finalSpace.position;
            spaces += collision.GetComponent<Ladder>().skipSpaces;
        }

        if (collision.CompareTag("SnakeSpace"))
        {
            transform.position = collision.GetComponent<Snake>().finalSpace.position;
            spaces -= collision.GetComponent<Snake>().skipSpaces;
        }

    }

}
