using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Inter
{

    public class DialogController : MonoBehaviour
    {

        [Header("Scene Objects")]
        public GameObject dialogObject;
        public Image imagemPersonagem;
        public TMP_Text texto;
        public TMP_Text textoNome;

        [Header("Sprites Personagens")]
        public Sprite cacador;
        public Sprite coleta;
        public Sprite pescador;
        public Sprite paje;

        //TIPOS 
        [HideInInspector] public readonly string CACADOR = "cacador";
        [HideInInspector] public readonly string PESCA = "pesca";
        [HideInInspector] public readonly string COLETA = "coleta";
        [HideInInspector] public readonly string PAJE = "paje";

        [HideInInspector] public static DialogController instance;

        void Start()
        {
            instance = this;
            dialogObject.SetActive(false);
        }

        public void CreateDialog(string _tipo, string _texto)
        {
            dialogObject.SetActive(true);
            texto.text = _texto;
            textoNome.text = _tipo;

            if (_tipo == CACADOR)
            {
                imagemPersonagem.sprite = cacador;
            }
            else if (_tipo == PESCA)
            {
                imagemPersonagem.sprite = pescador;
            }
            else if (_tipo == COLETA)
            {
                imagemPersonagem.sprite = coleta;
            }
            else if (_tipo == PAJE)
            {
                imagemPersonagem.sprite = paje;
            }
        }

        public void FecharDialog()
        {
            dialogObject.SetActive(false);
        }
    }
}
