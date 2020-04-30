using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float startTime;
    private bool finnished = false;
    public Text timerText;
    //private Animation santa;
    //private Animation top;
    public Animator santa;
    public Animator top;
    int ranMin;
    public AudioSource hoSanta;
    public AudioSource bgSound;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        //santa = GetComponentInChildren<Animation>();
        
        //top = GetComponentInChildren<Animation>();
        //Random ran = new Random();
        ranMin = Random.Range(10,15);
        //santa = GetComponentInChildren<Animator>();

        santa.enabled = false;

        //top = GetComponentInChildren<Animator>();

        top.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {


        if (finnished)
        {
           
            return;
        }

        float t = Time.time - startTime;
        //string mins = ((int)t / 60).ToString();
        //string seconds = (t % 60).ToString("f2");
        int mins = (int)(t/60);
        int sec = (int) (t % 60);

        
        timerText.text = mins.ToString() + ":" + sec.ToString();
        if (mins == ranMin)
        {
            Finnish();
        }
    }

    public void Finnish() {
        santa.enabled = true;
        top.enabled = true;
        finnished = true;
        StartCoroutine(SoundMixer());
        //santa.Play();
        //top.Play();
            timerText.color = Color.yellow;
       
        
    }

    IEnumerator SoundMixer() {
        yield return new WaitForSeconds(2);
        hoSanta.Play();
        bgSound.volume = 0.0f;
        yield return new WaitForSeconds(5);
        bgSound.volume = 1f;
    }
}
