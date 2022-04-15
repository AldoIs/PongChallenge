using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class tutorialController : MonoBehaviour
{
    public int estadoTutorial;
    Text intro;
    GameObject ball;
    GameObject palletbot;
    GameObject palletside;
    GameObject enemy;
    public LifeCounter life;




    string text1 = @"BIENVENIDO AL ENTRENAMIENTO PIXIE.
Has Sido elegido entre todos para defender al universo de las fuerzas malvadas que asechan, que te parece si empezamos a practicar un poco.";
    string text2 = @"ADISTRAMIENTO
Un gran elemento de las fuerzas Pixie de las fuerzas Pixie debe ser diestro con ambas manos, para controlar la base inferior mueve el MOUSE a los LADOS. ";
    string text3 = @"PRECISIÓN
Algo que distingue a los miembros de la comunidad Pixie es un precisión, para mover las barras laterales usa ARRIBA o ABAJO en tu teclado o W y S.";
    string text4 = @"TTACTICO
Ten Cuidado con las zonas rojas te quitaran corazones hay que mantenernos alejados de esas zonas, si presionas el MOUSE cuando golpea PALETA INFERIOR podras atrapar el proyectil, pero su dirección continuara cuando lo sueltes.";
    string text5 = @"VENCER
Rebotar en las zonas blancas da puntos y derrotar a los enemigos tambien, pero ten cuidado que los enemigos no lleguen hasta la parte inferior o perderas la partida automaticamente.";
    // Start is called before the first frame update
    void Start()
    {
        estadoTutorial = 0;
        GameObject tmp = GameObject.Find("intro");
        intro = tmp.GetComponent<UnityEngine.UI.Text>();
        palletbot = GameObject.Find("PalletBot");
        palletside = GameObject.Find("SidePallet");
        ball = GameObject.Find("ball");
        enemy = GameObject.Find("Villanos");
    


    var button = transform.GetComponent<Button>();
        button.onClick.AddListener(this.clickFuncion);

        palletbot.SetActive(false);
        palletside.SetActive(false);
        ball.SetActive(false);
        enemy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (life.liveCounter <= 2)
        {
            life.liveCounter = 5;
        }
        switch (estadoTutorial)
        {
            case 0:
                {
                    intro.text = text1;
                    break;  
                }
            case 1:
                {
                    palletbot.SetActive(true);
                    intro.text = text2;
                    break;
                }
            case 2:
                {
                    palletside.SetActive(true);
                    intro.text = text3;
                    break;
                }
            case 3:
                {
                    ball.SetActive(true);
                    intro.text = text4;
                    break;
                }
            case 4:
                {
                    enemy.SetActive(true);
                    intro.text = text5;
                    var colors = transform.GetComponent<Button>().colors;
                    colors.normalColor = Color.cyan;
                    transform.GetComponent<Button>().colors = colors;
                    transform.GetComponent<Button>().enabled = false;
                    transform.GetComponent<Button>().enabled = true;
             
                    break;
                }

            default:
                {
                    SceneManager.LoadScene("Game");
                    break;
                }
           
        }
    }
    public void  clickFuncion()
    {
        estadoTutorial++;
        

    }
    void clickTest()
    {

        switch (estadoTutorial)
        {
            case 0:
                {
                    palletbot.SetActive(true);
                    intro.text = text1;
                    break;
                }
            case 1:
                {
                    intro.text = text2;
                    break;
                }
            case 2:
                {
                    intro.text = text3;
                    break;
                }
            case 3:
                {
                    intro.text = text4;
                    break;
                }
            case 4:
                {
                    intro.text = text5;
                    break;
                }

            default:
                {
                    SceneManager.LoadScene("Game");
                    break;
                }

        }

    }

}
