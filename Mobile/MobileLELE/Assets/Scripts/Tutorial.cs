using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public int acabaTexto;

    public GameObject caixaDeTexto;
    public GameObject ConstuirTutorial;
    public GameObject ConstuirTutorial2;
    public GameObject ConstuirTutorial3;

    public Image sprite;
    public TMP_Text nome;
    public TMP_Text text;
    private int numArray;

    [TextArea(5, 20)]
    public string[] tutoriais;

    public Sprite[] Personagens;
    public bool[] paje; // image 0
    public bool[] pesca; // image 1
    public bool[] hunt; // image 2
    public bool[] xama; // image 3
    public bool[] coleta; // image 4

    void Start()
    {

    }

    void Update()
    {
        text.text = tutoriais[numArray];

        if(paje[numArray]) // PAJÉ
        {
            sprite.sprite = Personagens[0];
            nome.text = "Pajé";
        }
        if (pesca[numArray]) // PESCADOR
        {
            sprite.sprite = Personagens[1];
            nome.text = "pescador";
        }
        if (hunt[numArray]) // HUNT
        {
            sprite.sprite = Personagens[2];
            nome.text = "Caçador";
        }
        if (xama[numArray]) // HUNT
        {
            sprite.sprite = Personagens[3];
            nome.text = "Xamã";
        }
        if (coleta[numArray]) // COLETA
        {
            sprite.sprite = Personagens[4];
            nome.text = "Coletora";
        }

        if (numArray == 8)
        {
            ConstuirTutorial.SetActive(true);
        }else ConstuirTutorial.SetActive(false);
        if (numArray == 9 || numArray == 16)
        {
            ConstuirTutorial2.SetActive(true);
        }else ConstuirTutorial2.SetActive(false);
        if (numArray == 15)
        {
            ConstuirTutorial3.SetActive(true);
        }else ConstuirTutorial3.SetActive(false);

        if (numArray == acabaTexto)
        {
            Destroy(gameObject);
        }
    }

    public void Proximo()
    {
        numArray++;
    }

    public void AudioPaje()
    {
        if (paje[numArray] && numArray == 1) // PAJÉ
        {
            FindObjectOfType<AudioManager>().Play("VozPaje");                  
        }
    }
    public void AudioPescador()
    {
        if (pesca[numArray] && numArray == 10) // PAJÉ
        {
            FindObjectOfType<AudioManager>().Play("VozPescador");
        }
    }
    public void AudioHunt()
    {
        if (hunt[numArray] && numArray == 5) // PAJÉ
        {
            FindObjectOfType<AudioManager>().Play("VozHunt");
        }
    }
    public void AudioXama()
    {
        if (xama[numArray] && numArray == 1) // PAJÉ
        {
            FindObjectOfType<AudioManager>().Play("VozXama");
        }
    } 
    public void AudioColetora()
    {
        
        if (coleta[numArray] && numArray == 19) // COLETORA
        {
            print("A");
            FindObjectOfType<AudioManager>().Play("VozFeminina");
        }
    }

}
