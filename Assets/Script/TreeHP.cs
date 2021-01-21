using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHP : MonoBehaviour
{

    Animator animator;
    public int treehp;
    public float timeRemaining = 12;
    public bool timerIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        treehp = 50;

        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            treehp = treehp - 1;
        }
            if (treehp == 25)
        {
            animator.SetInteger("HP", 1);
        }
        if (treehp == 0)
        {
            animator.SetInteger("HP", 2);
        }
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        { 
            timeRemaining = 0;
            timerIsRunning = false;
            treehp = 100000;
        }
    }
}
