using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitoriaDerrota : MonoBehaviour
{
    public static GameObject Derrota;
    public static GameObject Vitoria;
    public static AudioSource musiquinha;

    [Header("Data")]
    public ItemData_SO foodData;
    public ItemData_SO resourcesData;

    void Start()
    {
        Derrota = GameObject.Find("DerrotaMinigame");
        Vitoria = GameObject.Find("VitoriaMinigame");
        musiquinha = GameObject.Find("Musicacaaacaa").GetComponent<AudioSource>();
        Derrota.SetActive(false);
        Vitoria.SetActive(false);
    }

    void Update()
    {
        
    }

    public static void AtivaDerrota()
    {
        Derrota.SetActive(true);
        FindObjectOfType<AudioManager>().Play("SomDerrota");
        musiquinha.Play();
    }
    public static void AtivaVitoria()
    {
        Vitoria.SetActive(true);
        FindObjectOfType<AudioManager>().Play("SomVitoria");
        musiquinha.Play();
    }

    public void tirarRecursos()
    {
        if(foodData.itemTotal <= 1500)
        {
            foodData.itemTotal = 0;
        }
        else if(foodData.itemTotal > 1500)
        {
            foodData.itemTotal -= 1500;
        }

        if (resourcesData.itemTotal <= 1000)
        {
            resourcesData.itemTotal = 0;
        }
        else if(resourcesData.itemTotal > 1000)
        {
            resourcesData.itemTotal -= 1000;
        }
    }
}
