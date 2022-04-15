using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var button = transform.GetComponent<Button>();
        button.onClick.AddListener(this.clickFuncion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void clickFuncion()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

    }
   public void clickWelcome()
    {
        SceneManager.LoadScene("welcome");

    }
}
