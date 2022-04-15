using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public float speed = 5.0f;
    private float vertical;
    public AudioSource lose;
    public AudioSource killenemy;
    private AudioSource[] allAudioSources;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

    }
    // Update is called once per frame
    void Update()
    {
        vertical = speed * Time.deltaTime;
        transform.Translate(0, -vertical, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Finish")
        {

            StopAllAudio();
            lose.Play(0);
        }
        if (other.gameObject.tag == "Player")
        {
            killenemy.Play(0);

            Destroy(gameObject);

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
