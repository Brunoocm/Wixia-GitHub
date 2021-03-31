using System.Collections;
using UnityEngine;

namespace Inter
{
    public class UpgradeConstruction : MonoBehaviour
    {
        [Header("Data")]
        public ItemData_SO foodData;
        public ItemData_SO resourcesData;
        public ItemData_SO cultureData;

        [Header("Construction")]
        public ConstructionDisplay constructionScript;
        public Animator anim;

        [Header("TirarValueLV2")]
        public int tirarFood;
        public int tirarResources;
        public int tirarCulture;

        [Header("TirarValueLV3")]
        public int tirarFoodLV3;
        public int tirarResourcesLV3;
        public int tirarCultureLV3;

        [Header("Upgrade")]
        public int itemValueLV1;
        public int itemValueLV2;
        public int itemValueLV3;


        private bool podeLV2;
        private bool podeLV3;

        private Collider2D coll;
        GameObject TextSemRecursos;
        GameObject TextYanosBaixo;

        void Start()
        {
            coll = GetComponent<Collider2D>();
          
        }

        void Update()
        {
            
            if (constructionScript.level == 1)
            {
                if (foodData.itemTotal > tirarFood && resourcesData.itemTotal > tirarResources)
                {
                    podeLV2 = true;
                }
                else
                {
                    podeLV2 = false;
                }
            }
            else if (constructionScript.level == 2)
            {
                podeLV2 = false;
                if (foodData.itemTotal > tirarFoodLV3 && resourcesData.itemTotal > tirarResourcesLV3)
                {
                    podeLV3 = true;
                }
                else
                {
                    podeLV3 = false;
                }
            }

            if (constructionScript.level == 2)
            {
                anim.SetTrigger("UPlv2");
            }
            if (constructionScript.level == 3)
            {
                anim.SetTrigger("UPlv3");
            }
            else if (constructionScript.level > 3)
            {
                constructionScript.level = 3;
            }
        }


        public void UpgradeThis()
        {
            if (Yanos.Yanoslevel == 1)
            {
                StartCoroutine(TextInsuficiente.TextYanosOFF()); //texto nivel yanos baixo
            }
            if (Yanos.Yanoslevel == 2 && constructionScript.level == 1 )
            {
                 //upa a construção para o level 2
                TirarValue();
            }
            if (Yanos.Yanoslevel == 3 && constructionScript.level >= 1)
            {
                 //upa a construção para o level 3
                TirarValue();
            }
            else
            {
                StartCoroutine(TextInsuficiente.TextYanosOFF()); //texto nivel yanos baixo
            }
      

        }

        public void InicioAnim()
        {
            if (podeLV2 || podeLV3)
            {
                constructionScript.canPerSecond = false;
            }
        }

        //lv1
        public void FimAnimLv1()
        {
            constructionScript.thisItemValue = itemValueLV1; //ITEM POR SEGUNDO
            constructionScript.canPerSecond = true;
            FindObjectOfType<AudioManager>().Play("SomConstruindo");
        }
        //LV1

        //lv2
        public void FimAnimLv2()
        {
            if (podeLV2)
            {
                constructionScript.thisItemValue = itemValueLV2; //ITEM POR SEGUNDO
                constructionScript.canPerSecond = true;
                FindObjectOfType<AudioManager>().Play("SomConstruindo");
            }
        }
        //LV2

        //LV3
        public void FimAnimLv3()
        {
            if (podeLV2)
            {
                constructionScript.thisItemValue = itemValueLV3; //ITEM POR SEGUNDO
                constructionScript.canPerSecond = true;
                FindObjectOfType<AudioManager>().Play("SomConstruindo");
            }
        }
        //LV3

        private void TirarValue()
        {
            if(podeLV2)
            {
                foodData.itemTotal -= tirarFood;
                resourcesData.itemTotal -= tirarResources;
                cultureData.itemTotal -= tirarCulture;
                constructionScript.level++;
            }
            else if (podeLV3)
            {
                foodData.itemTotal -= tirarFoodLV3;
                resourcesData.itemTotal -= tirarResourcesLV3;
                cultureData.itemTotal -= tirarCultureLV3;
                constructionScript.level++;
            }
            else
            {
                StartCoroutine(TextInsuficiente.TextOFF()); //texto sem recursos
            }
        }


    }


}
