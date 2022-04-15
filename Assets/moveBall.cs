using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBall : MonoBehaviour
{
    public float speed = 30.0f;
     float speed2;
    private Rigidbody2D rb;
    private Vector2 dir;
    private float x = 1.0f;
    private float y = 1.0f;
    public AudioSource audio;
    public AudioSource death;
    public LifeCounter life;
    public AudioSource lose;
    private bool press = false;
    private bool atrap = false;
    
    scoreController score;


    private AudioSource[] allAudioSources;


    // Start is called before the first frame update
    void Start()
    {
        speed2 = speed;
        rb = GetComponent<Rigidbody2D>();
        dir = new Vector2(x, y).normalized;
        score = GameObject.FindGameObjectsWithTag("score")[0].GetComponent<scoreController>();

    }
    void Awake()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            press = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            press = false;
            speed = speed2;
            atrap = false;
            transform.parent = null;

        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!atrap)
        {
            rb.velocity = speed * Time.deltaTime * dir;

        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "dangerfin")
        {
            death.Play(0);


            life.liveCounter--;
            y = y * -1.0f;
            audio.Play(0);
            dir = new Vector2(x, y).normalized;

            if (life.liveCounter == 0)
            {
                StopAllAudio();
                speed = 0.0f;
                lose.Play(0);
            }


        }
        else if (other.gameObject.tag == "safe")
        {
            x = x * (-1.0f);
            audio.Play(0);
            dir = new Vector2(x, y).normalized;
            score.hitSafe();
        }
        else if (other.gameObject.tag == "techo")
        {
            score.hitTop();
            y = y * -1.0f;
            audio.Play(0);
            dir = new Vector2(x, y).normalized;
            

        }
        else if (other.gameObject.tag == "palletbot")
        {
            score.hitTop();
            y = y * -1.0f;
            audio.Play(0);
            dir = new Vector2(x, y).normalized;
            if (press)
            {
                speed = 0;
                atrap = true;
                transform.parent = other.gameObject.transform;

            }
            else
            {
                speed = speed2;
                atrap = false;
                transform.parent = null;

            }

        }
        else if (other.gameObject.tag == "danger")
        {
            death.Play(0);


            life.liveCounter--;
            x = x * (-1.0f);
            audio.Play(0);
            dir = new Vector2(x, y).normalized;

            if (life.liveCounter == 0)
            {
                StopAllAudio();
                speed = 0.0f;
                lose.Play(0);
            }
        }
        else if (other.gameObject.tag == "enemy")
        {
            score.hitEnemy();
        }



    }
    void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }
}
