using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public AudioSource lose;
    public AudioSource killenemy;
    public GameObject [] enemiesGameobject;
    GameObject enemyGameobject;
    // Start is called before the first frame update
    void Start()
    {
        createEnemy(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("enemy").Length <= 0)
        {
            int index = Random.Range(0,enemiesGameobject.Length);
            int pos = Random.Range(-3, 3);
            createEnemy(pos, index);
        }
    }

    void createEnemy(int posX, int i = 0)
    {

        enemyGameobject = Instantiate(enemiesGameobject[i], transform.position, transform.rotation) as GameObject;

        enemyGameobject.transform.position = new Vector2(posX, 7);
        
        enemyGameobject.transform.parent = gameObject.transform;

        //create a new SpriteRenderer for Shadow gameobject
        enemyMove enemySc = enemyGameobject.GetComponent<enemyMove>();
        enemySc.lose = this.lose;
        enemySc.killenemy = this.killenemy;
        enemySc.speed = 1f;
  
}

}
