using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePalletSide : MonoBehaviour
{
    public float speed = 50.0f;
    private float horizontal, vertical;
    private Vector2 positionCurrent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        positionCurrent = transform.position;
        transform.Translate(0, vertical, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "danger" || other.gameObject.tag == "dangerfin")
        {
            transform.position = positionCurrent;
            Debug.Log("danger SIDE");

        }

        else if (other.gameObject.tag == "techo")
        {
            transform.position = positionCurrent;
            Debug.Log("techo SIDE");
        }



    }
}
