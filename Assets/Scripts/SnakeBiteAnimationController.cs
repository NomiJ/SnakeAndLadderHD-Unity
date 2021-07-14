using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBiteAnimationController : MonoBehaviour
{
    public Animator animator;

    void OnEnable()
    {
        animator.SetBool("Snake", true);
    }

    void OnDisable()
    {
        animator.SetBool("Snake", false);

    }

    public void End()
    {
        gameObject.SetActive(false);
    }

}
