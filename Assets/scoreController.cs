using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoreController : MonoBehaviour
{
    private Text texto;
    public int score = 0;
    public int scoreSide = 10;
    public int scoreBottomUp = 15;
    public int scoreEnemy = 20;
    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponent<Text>();
      
    }

    // Update is called once per frame
    void Update()
    {
        texto.text = "Score: " + score;
    }
     public void hitSafe()
    {
        score += scoreSide;
    }
    public void hitTop()
    {
        score += scoreBottomUp;
    }
    public void hitEnemy()
    {
        score += scoreEnemy;
    }
}

