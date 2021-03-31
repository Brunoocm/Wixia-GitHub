using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Inter 
{

    public class CreateConstruction : MonoBehaviour
    {
        [Header("Data")]
        public ItemData_SO foodData;
        public ItemData_SO resourcesData;
        public ItemData_SO cultureData;

        [Header("Constructions")]
        public Yanos yanosScript;
        public GameObject Hunt;
        public GameObject Fish;
        public GameObject Madeira;

        [Header("Quantidade")]
        public int numHunt = 0;
        public int numFish = 0;
        public int numMadeira = 0;

        public static GameObject Construction;
        public static int tirarFood;
        public static int tirarResources;
        public static int tirarCulture;

        [Header("Hunt")]
        public int tirarFoodHunt;
        public int tirarResourcesHunt;
        private int allHunt = 1;

        [Header("Fish")]
        public int tirarFoodFish;
        public int tirarResourcesFish;
        private int allFish = 1;

        [Header("Madeira")]
        public int tirarFoodMadeira;
        public int tirarResourcesMadeira;
        private int allMadeira = 1;

        [Header("Text")]
        public TMP_Text textHunt;
        public TMP_Text textFish;
        public TMP_Text textMadeira;

        void Start()
        {
            yanosScript = GameObject.FindObjectOfType<Yanos>();
        }

        void Update()
        {
            textHunt.text = numHunt.ToString() + "/" + allHunt;
            textFish.text = numFish.ToString() + "/" + allFish;
            textMadeira.text = numMadeira.ToString() + "/" + allMadeira;

            if (Yanos.Yanoslevel == 1) allHunt = 1;
            if (Yanos.Yanoslevel == 2) allHunt = 2;
            if (Yanos.Yanoslevel == 3) allHunt = 3;

            if (Yanos.Yanoslevel == 1) allFish = 1;
            if (Yanos.Yanoslevel == 2) allFish = 2;
            if (Yanos.Yanoslevel == 3) allFish = 3;

            if (Yanos.Yanoslevel == 1) allMadeira = 2;
            if (Yanos.Yanoslevel == 2) allMadeira = 3;
            if (Yanos.Yanoslevel == 3) allMadeira = 4;

        }
        public void BuyHunt()
        {
            tirarFood = tirarFoodHunt;
            tirarResources = tirarResourcesHunt;

            if (foodData.itemTotal > tirarFoodHunt && resourcesData.itemTotal > tirarResourcesHunt)
            {

                if (Yanos.Yanoslevel == 1 && numHunt < allHunt)
                {
                    Construction = Hunt;
                }

                if (Yanos.Yanoslevel == 2 && numHunt < allHunt)
                {
                    Construction = Hunt;
                }

                if (Yanos.Yanoslevel == 3 && numHunt < allHunt)
                {
                    Construction = Hunt;
                }

                if (numHunt >= allHunt)
                {
                    Construction = null;
                    ResetData();
                }
            } 
            else ResetData();
        }
        public void BuyFish()
        {
            tirarFood = tirarFoodFish;
            tirarResources = tirarResourcesFish;

            if (foodData.itemTotal > tirarFoodFish && resourcesData.itemTotal > tirarResourcesFish)
            {

                if (Yanos.Yanoslevel == 1 && numFish < allFish)
                {
                    Construction = Fish;
                }
  
                if (Yanos.Yanoslevel == 2 && numFish < allFish)
                {
                    Construction = Fish;
                }

                if (Yanos.Yanoslevel == 3 && numFish < allFish)
                {
                    Construction = Fish;
                }

                if (numFish >= allFish)
                {
                    Construction = null;
                    ResetData();
                }

            }
            else ResetData();
        }
        public void BuyMadeira()
        {
            tirarFood = tirarFoodMadeira;
            tirarResources = tirarResourcesMadeira;

            if (foodData.itemTotal > tirarFoodMadeira && resourcesData.itemTotal > tirarResourcesMadeira)
            {              

                if (Yanos.Yanoslevel == 1 && numMadeira < allMadeira)
                {
                    Construction = Madeira;
                }
 
                if (Yanos.Yanoslevel == 2 && numMadeira < allMadeira)
                {
                    Construction = Madeira;
                }

                if (Yanos.Yanoslevel == 3 && numMadeira < allMadeira)
                {
                    Construction = Madeira;
                }

                if (numMadeira >= allMadeira)
                {
                    Construction = null;
                    ResetData();
                }
            }
            else ResetData();
        }

        public void SpawnConstruction()
        {
            if (Construction == Hunt) {numHunt++; FindObjectOfType<AudioManager>().Play("SomColocou");}
            if (Construction == Fish) {numFish++; FindObjectOfType<AudioManager>().Play("SomColocou");}
            if (Construction == Madeira) {numMadeira++; FindObjectOfType<AudioManager>().Play("SomColocou");}
            if(Construction == null) FindObjectOfType<AudioManager>().Play("ButtonErro");

            foodData.itemTotal -= tirarFood;
            resourcesData.itemTotal -= tirarResources;
            cultureData.itemTotal -= tirarCulture;
            Instantiate(Construction, new Vector3(0, 0, 0), Quaternion.identity);
        }

        private void ResetData()
        {
            Construction = null;
            tirarFood = 0;
            tirarResources = 0;
            tirarCulture = 0;
        }

    }
}
