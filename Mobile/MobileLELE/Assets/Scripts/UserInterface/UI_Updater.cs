using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// using Inter.Data;

namespace Inter.GameControl
{

    public class UI_Updater : MonoBehaviour
    {
        [Serializable]
        public class UI_itemBar
        {
            [Header("Item Data")]
            public ItemData_SO itemData_SO;
            public float itemTotal;
            public float itemMax;
            public float itemPercentage = 0f;

            [Header("Slider Config")]
            public Image sliderSprite;
            public TMP_Text textUI;
            public Slider slider;
            public Image fillImage;
            public Color color;
        }

        //Liberados no Inspector
        [Header("Menus (Ativos/Desativo)")]
        public bool menuInicial;
        public bool menuConfig;
        public bool menuYanos;
        public GameObject[] menus;

        [Header("PlayerInfo")]
        public PlayerData_SO _playerDataSO;
        [Header("UI items")]
        public UI_itemBar[] _itemBars;

        private string _playerName;
        private int _playerLevel = 0;
        private GameObject lastMenu;
        private GameObject currentMenu;

        void Start()
        {
        }

        void Update()
        {
            for (int i = 0; i < _itemBars.Length; i++)
            {
                AtualizarItemBars(_itemBars[i]);
            }

            //Controle dos Menus ativos
            menuInicial = menus[0].activeInHierarchy ? true : false;
            menuConfig = menus[1].activeInHierarchy ? true : false;
            menuYanos = menus[2].activeInHierarchy ? true : false;
        }

        public void AtualizarItemBars(UI_itemBar _itemBar)
        {
            if (_itemBar.itemTotal <= _itemBar.itemMax)
            {
                //Item Data
                _itemBar.itemTotal = _itemBar.itemData_SO.itemTotal;
                _itemBar.itemMax = _itemBar.itemData_SO.itemMax;
                _itemBar.itemPercentage = _itemBar.itemTotal / _itemBar.itemMax;

                //Visual Config
                _itemBar.slider.value = _itemBar.itemPercentage;
                _itemBar.fillImage.color = _itemBar.color;
                if(_itemBar.sliderSprite != null)_itemBar.sliderSprite.sprite = _itemBar.itemData_SO.itemImage;
                _itemBar.textUI.text = FormatNumber(_itemBar.itemTotal);
            }
            else
            {
                _itemBar.textUI.text = FormatNumber(_itemBar.itemMax);
            }
        }

        private string FormatNumber(float _unformated)
        {
            var _formatInfo = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
            _formatInfo.NumberGroupSeparator = " ";
            string _formated = _unformated.ToString("#,0", _formatInfo);
            return _formated;
        }
    }
}

