using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePalletBottom : MonoBehaviour
{
    private Vector2 mousePosition;
    private Vector2 position;
    private Vector2 target;
    private float speed = 10.0f;
    private Camera cam;
    float step;
    private Vector2 positionCurrent;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
         
         step = speed * Time.deltaTime;
        positionCurrent = transform.position;
        // move sprite towards the target location
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.y = transform.position.y;
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "danger")
        {
            transform.position = positionCurrent;
            Debug.Log("danger Bottom");

        }

        else if (other.gameObject.tag == "techo")
        {
            transform.position = positionCurrent;
            Debug.Log("techo SIDE");
        }



    }

}
