using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeCounter : MonoBehaviour
{
    public int liveCounter = 3;
    public Sprite heartSprite;
    public float width = 25.0f;
    public float height = 25.0f;
    public float space = 25.0f;
    public float offsetX = 25.0f;
    public float offsetY = -25.0f;
    private GameObject[] gameObjectImage; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        reHeath();
    }

    void reHeath()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        for (int i = 0; i < liveCounter; i++)
        {
            GameObject NewObj = new GameObject(); //Create the GameObject
            Image NewImage = NewObj.AddComponent<Image>(); //Add the Image Component script
            NewImage.sprite = heartSprite; //Set the Sprite of the Image Component on the new GameObject
            NewObj.GetComponent<RectTransform>().SetParent(gameObject.transform); //Assign the newly created Image GameObject as a Child of the Parent Panel.
            RectTransform uitransform = NewObj.GetComponent<RectTransform>();
            uitransform.anchorMin = new Vector2(0, 1);
            uitransform.anchorMax = new Vector2(0, 1);
            uitransform.pivot = new Vector2(0, 1);
            NewObj.SetActive(true); //Activate the GameObject
            NewObj.transform.localPosition = new Vector3(((i * space+offsetX) + width  * i ) , offsetY, 0);
            NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);

        }
    }
}
