using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProtótipoValueUpdater : MonoBehaviour
{
    [System.Serializable]
    private class UI_DialogData
    {
        public Sprite sprite;
        public string tipo;
        [TextArea(3, 10)]
        public string texto;
        public bool ativo;
    }

    [Header("Item SO")]
    public ItemData_SO foodData;
    public ItemData_SO resourceData;
    public ItemData_SO cultureData;

    [Header("Dialog Items")]
    public GameObject dialogBox;
    public Image imagemUI;
    public TMP_Text textName;
    public TMP_Text textSpeech;
    public GameObject botaoShop;
    public GameObject botaoShop2;
    public GameObject botaoShop3;
    public GameObject botaoShop4;

    [Header("Dialog Info")]
    [SerializeField] private UI_DialogData[] dialogData;

    [Header("Construções")]
    public GameObject Yanos;
    public GameObject Hunt;
    public GameObject Resources;
    public GameObject Culture;

    public int etapa = 0;
    public int lastEtapa;
    private float timer;
    private bool pode = true;
    private bool pode2 = true;

    void Start()
    {
        etapa = 0;

        foodData.itemTotal = 0;
        resourceData.itemTotal = 0;
        cultureData.itemTotal = 0;

        resourceData.itemMax = 250;
        foodData.itemMax = 250;
    }

    void Update()
    {
        if (etapa == 0)
        {
            Yanos.SetActive(false);
            Hunt.SetActive(false);
            Resources.SetActive(false);
            Culture.SetActive(false);
            botaoShop.SetActive(false);
            dialogData[0].ativo = true;
            Guide(dialogData[0]);
            lastEtapa = 0;
        }
        else if (etapa == 1)
        {
            botaoShop.SetActive(true);
        }
        else if (etapa == 2)
        {
            Guide(dialogData[1]);
            botaoShop.SetActive(false);
            foodData.itemTotal = 250;
            resourceData.itemTotal += 150;
            cultureData.itemTotal += 50;
        }
        else if (etapa == 3)
        {
            Guide(dialogData[2]);
        }
        else if (etapa == 4)
        {
            botaoShop2.SetActive(true);
        }
        else if (etapa == 5)
        {
            Guide(dialogData[3]);
            botaoShop2.SetActive(false);
        }
        else if (etapa == 6)
        {

        }
        else if (etapa == 7)
        {
            Guide(dialogData[4]);
        }
        else if (etapa == 8)
        {
            botaoShop3.SetActive(true);
        }
        else if (etapa == 9)
        {
            botaoShop3.SetActive(false);
        }
        else if (etapa == 10)
        {
            Guide(dialogData[5]);
        }
        else if (etapa == 11)
        {
            botaoShop4.SetActive(true);
        }
        else if (etapa == 12)
        {
            botaoShop4.SetActive(false);
        }


        if (resourceData.itemTotal == 125 && pode)
        {
            etapa = 7;
            pode = false;
        }
        if (foodData.itemTotal == 280 && pode2)
        {
            etapa = 10;
            pode2 = false;
        }
    }

    private void Guide(UI_DialogData _dialogData)
    {
        dialogBox.SetActive(true);
        imagemUI.sprite = _dialogData.sprite;
        textName.text = _dialogData.tipo;
        textSpeech.text = _dialogData.texto;
        lastEtapa = etapa;
        etapa = 100;
    }

    public void DesativarDialog()
    {
        dialogBox.SetActive(false);
        etapa = lastEtapa + 1;
    }

    public void BotaoEtapa1()
    {
        Yanos.SetActive(true);
        etapa = 2;
    }
    public void BotaoEtapa2()
    {
        Resources.SetActive(true);
        resourceData.itemTotal -= 100;
        resourceData.itemMax = 500;
        etapa = 5;
        lastEtapa = 4;
    }
    public void BotaoEtapa3()
    {
        Hunt.SetActive(true);
        resourceData.itemTotal -= 50;
        foodData.itemMax = 500;
        etapa = 9;
        lastEtapa = 8;
    }
    public void BotaoEtapa4()
    {
        Culture.SetActive(true);
        cultureData.itemTotal += 100;
        etapa = 12;
        lastEtapa = 11;
    }
}
