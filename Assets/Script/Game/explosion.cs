using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour


{
    Animator animator;
    float exitTime = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("logogog");
        if (EndAnimationDone())
        {
            Destroy(gameObject);
        }
    }
    bool EndAnimationDone()

    {

        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f;

    }





}