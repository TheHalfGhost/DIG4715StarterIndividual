using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Chop : MonoBehaviour
{

    Animator animator;
    AudioSource audioSource;

    public static bool IsInputEnabled = true;

    public int treehp;

    public ParticleSystem woodeffect;

    public float timeRemaining = 10;
    public bool timerIsRunning = false;

    public Text Win;
    public Text Lose;
    public Text Timer;

    public AudioClip Hitsound;
    public AudioClip Winsong;
    public AudioClip Losesong;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        treehp = 50;
        woodeffect.Stop();
        timerIsRunning = true;
        IsInputEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Chop.IsInputEnabled)
        {
            if (Input.GetKeyDown("space"))
            {
                animator.SetBool("Chop", true);
                treehp = treehp - 1;
                woodeffect.Play();
                audioSource.PlayOneShot(Hitsound);
            }
            else if (Input.GetKeyUp("space"))
            {
                animator.SetBool("Chop", false);
                woodeffect.Stop();
            }
            if (Input.GetKeyUp("space"))
            {
                woodeffect.Stop();
            }


        }
        if (treehp == 0)
        {
            IsInputEnabled = false;
            animator.SetBool("Chop", false);
            woodeffect.Stop();
            timerIsRunning = false;
            Win.text = "You Win! Thank you for playing. Game by Alexander Williams";
            audioSource.PlayOneShot(Winsong);

        }
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                Timer.text = "Time left: " + Mathf.Round(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                Lose.text = "You Lose! Try again. Press 'R' to restart";
                IsInputEnabled = false;
                audioSource.PlayOneShot(Losesong);
                
            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (Input.GetKey("r"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}