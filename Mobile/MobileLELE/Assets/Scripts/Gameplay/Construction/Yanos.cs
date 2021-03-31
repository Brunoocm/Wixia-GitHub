using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Inter 
{
    public class Yanos : MonoBehaviour
    {
        public static int Yanoslevel;
        public Sprite lv1;
        public Sprite lv2;
        public Sprite lv3;

        public CreateConstruction ConstructionScript;
        public GameObject Final;

        public SpriteRenderer yanosDesenho;
        public GameObject objectUpgrade;

        public Collider2D coll;

        [Header("Data")]
        public ItemData_SO foodData;
        public ItemData_SO resourcesData;

        private void Start()
        {
            Yanoslevel = 1;
        }
        void Update()
        {
            if(Yanoslevel == 1)
            {
                yanosDesenho.sprite = lv1;

                
                foodData.itemMax = 10000;
                resourcesData.itemMax = 10000;

                //coleta lv 1 - max 2 unidades
                //caça lv 1 - max 1 unidade
                //pesca lv 1 - max 1 unidade
            }
            if(Yanoslevel == 2)
            {
                yanosDesenho.sprite = lv2;

                foodData.itemMax = 25000;
                resourcesData.itemMax = 25000;

                //coleta lv 2 - max 3 unidades
                //caça lv 2 - max 2 unidades
                //pesca lv 2 - max 2 unidades
                //horta lv 2 - max 2 unidades
                //pesquisa - max 1 unidade
                //xamã - max 1 unidade
            }
            if (Yanoslevel == 3)
            {
                yanosDesenho.sprite = lv3;

                foodData.itemMax = 50000;
                resourcesData.itemMax = 50000;

            }

            if (Yanoslevel >= 3 && ConstructionScript.numHunt >= 3 && ConstructionScript.numFish >= 3 && ConstructionScript.numMadeira >= 4)
            {
                Final.SetActive(true);
            }


            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
           
                if (touch.phase == TouchPhase.Began)
                {
      
                    Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);

                    if (coll == touchCollider)
                    {
                        objectUpgrade.SetActive(true);
                        yanosDesenho.color = Color.gray;

                    }
                    if (!coll == touchCollider)
                    {
                        objectUpgrade.SetActive(false);
                    }
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    

                }

                if (touch.phase == TouchPhase.Ended)
                {
                    Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);
                    yanosDesenho.color = Color.white;
                }
            }
        }
    }
}
