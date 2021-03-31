using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class coinController : MonoBehaviour
{
    public int coinTotal;
    public TMP_Text coinTextUI;
    public TMP_Text coinTextLoja;
    public ItemData_SO comidaSO;
    public ItemData_SO madeiraSO;

    public bool podeComprar;

    void Update()
    {
        coinTextUI.text = coinTotal.ToString();
        coinTextLoja.text = coinTotal.ToString();
        if(coinTotal <= 150) {
            podeComprar = false;
        }
    }


    public void AtualizaCoins(int valor)
    {
        if (((valor < 0 && (coinTotal - valor) > 0 && coinTotal != 0) || valor > 0))
        {
            print("Atualiza Moedas");
            coinTotal += valor;
            podeComprar = true;
        } 
        else 
        {
            //ATIVAR AQUI O AVISO DE MOEDAS INSUFICIENTES 
            podeComprar = false;
        }
    }

    public void AtualizaMadeira(int valor)
    {
        if((madeiraSO.itemTotal + valor > madeiraSO.itemMax)){
            madeiraSO.itemTotal = madeiraSO.itemMax;
        } else if(podeComprar) madeiraSO.itemTotal += valor;
    }
    public void AtualizaComida(int valor)
    {
        if((comidaSO.itemTotal + valor > comidaSO.itemMax)){
            comidaSO.itemTotal = comidaSO.itemMax;
        } else if(podeComprar) comidaSO.itemTotal += valor;
    }
}
