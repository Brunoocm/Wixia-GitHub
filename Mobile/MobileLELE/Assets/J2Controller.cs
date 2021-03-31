using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J2Controller : MonoBehaviour
{
    public GameObject canvasGame;
    public GameObject canvasJ2;
    public GameObject primeiroTexto;
    public GameObject segundoTexto;

    void Start()
    {
        canvasGame.GetComponent<Canvas>().enabled = false;
        canvasJ2.SetActive(true);
        primeiroTexto.SetActive(true);
        segundoTexto.SetActive(false);
    }

    public void BotaoTexto()
    {
        primeiroTexto.SetActive(false);
        segundoTexto.SetActive(true);
    }

    public void ProGame()
    {
        canvasGame.GetComponent<Canvas>().enabled = true;
        canvasJ2.SetActive(false);
    }

}
