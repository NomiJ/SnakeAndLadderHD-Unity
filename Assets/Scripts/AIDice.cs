using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDice : MonoBehaviour
{
    public Sprite roll01;
    public Sprite roll02;
    public Sprite roll03;

    [Space(10)]
    public new SpriteRenderer renderer;
    public Sprite[] sprites;

    public GameObject destroyEffect;

    public float moveSpeed;
    public float speedDecreaseAmt;

    public int roll;

    private float rollTime = 1f;
    private bool move = true;

    void Start()
    {
        StartCoroutine(RollDice());
    }

    void Update()
    {
        StartCoroutine(DestroyDice());

        if (move == true)
        {
            rollTime -= Time.deltaTime;
            transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);

            moveSpeed -= speedDecreaseAmt;

            if (rollTime <= 0f)
            {
                move = false;
            }

        }

    }

    IEnumerator RollDice()
    {
        float rollTime = 0.08f;

        for (int i = 0; i < 3; i++)
        {
            renderer.sprite = roll01;
            yield return new WaitForSeconds(rollTime);

            renderer.sprite = roll02;
            yield return new WaitForSeconds(rollTime);

            renderer.sprite = roll03;
            yield return new WaitForSeconds(rollTime);

            rollTime += 0.025f;

        }

        yield return new WaitForSeconds(0.1f);

        roll = Random.Range(1, 6);
        if (roll == 0)
        {
            roll = 1;
        }

        renderer.sprite = sprites[roll - 1];

    }

    IEnumerator DestroyDice()
    {
        yield return new WaitForSeconds(1.5f);

        GameObject effectGO = Instantiate(destroyEffect, transform.position, Quaternion.identity) as GameObject;

        Destroy(effectGO, 1f);
        Destroy(gameObject);

    }

}
