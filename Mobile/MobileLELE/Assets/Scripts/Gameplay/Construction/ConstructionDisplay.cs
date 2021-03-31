using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;

namespace Inter
{

    public class ConstructionDisplay : MonoBehaviour
    {
        public ScriptableConstruction construction;
        public SpriteRenderer artworkImage;
        public SpriteRenderer artworkBalao;

        public ItemData_SO foodData;
        public ItemData_SO resourcesData;
        public ItemData_SO cultureData;

        public string nameConstruction;
        private string infoConstruction;

        Image textCaixa;
        TMP_Text textName;
        TMP_Text textInfo;
        Vector3 lastPos;

        public GameObject ObjectButton;
        public float cellSize = 0.5f;
        public int thisItemValue = 2;
        public int level;

        public bool canPerSecond;
        private bool isTrigger = false;
        private bool Holding;
        private float TimerHold;
        private float Tap;
        public string thisTag;

        private Grid grid;
        private Collider2D coll;
        void Start()
        {
            artworkImage.sprite = construction.artwork;
            artworkBalao.sprite = construction.balao;
            coll = GetComponent<Collider2D>();

            //InfoConstruction
            textCaixa = GameObject.Find("ConstructionBox").GetComponent<Image>();
            textName = GameObject.Find("ConstructionName").GetComponent<TMP_Text>();    
            textInfo = GameObject.Find("ConstructionInfo").GetComponent<TMP_Text>();
            //InfoConstruction

            nameConstruction = construction.nameConstruction;
            infoConstruction = construction.infoConstruction;
            thisTag = construction.name;
        }

        void Update()
        {
            PerSecond();
            construction.vetorConstructions = GameObject.FindGameObjectsWithTag(thisTag);
            construction.areaDouble = Physics2D.OverlapCircle(transform.position, construction.checkRadius, construction.LayerDouble);

            for (int i = 0; i < construction.vetorConstructions.Length; i++)
            {
                construction.numConstructions = i + 1;
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                TimerHold += Time.deltaTime;
                if (touch.phase == TouchPhase.Began)
                {
                    Tap += Time.deltaTime;
                    Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);

                    if (coll == touchCollider)
                    {
                        CanCollectVoid();
                        artworkImage.color = Color.gray;
                        Holding = true;
                    }
                    if (!coll == touchCollider)
                    {
                        //InfoConstruction
                        ObjectButton.SetActive(false);
                        textName.text = null;
                        textInfo.text = null;
                        textCaixa.enabled = false;
                        textCaixa.GetComponent<BoxCollider2D>().enabled = false;
                        //InfoConstruction

                    }
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    if (Holding && TimerHold >= 0.5f)
                    {
                        transform.position = new Vector2(touchPosition.x, touchPosition.y);
                        transform.position = new Vector2(Mathf.RoundToInt(transform.position.x / cellSize) * cellSize, Mathf.RoundToInt(transform.position.y / cellSize) * cellSize);
                        artworkImage.color = Color.white;
                        if (isTrigger) artworkImage.color = Color.red;
                    }
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);
                    artworkImage.color = Color.white;
                    Holding = false;
                    TimerHold = 0;

                    if (isTrigger) transform.position = lastPos;
                    if (!isTrigger) lastPos = transform.position;

                    if (coll == touchCollider)
                    {                     
                                                

                        foreach (GameObject construction in construction.vetorConstructions)
                        {
                            construction.GetComponent<ConstructionDisplay>().artworkImage.color = Color.white;
                            construction.GetComponent<ConstructionDisplay>().artworkBalao.enabled = false;
                        }
                    }
                }
            }
        }
        public void PerSecond()
        {
            if (canPerSecond)
            {
                construction.timerInicio += Time.deltaTime;

                if (construction.timerInicio > construction.timerValue)
                {
                    construction.canCollect = true;
                    artworkBalao.enabled = true;
                    construction.timerInicio = 0f;
                    construction.itemValue += thisItemValue;
                }
                if (construction.itemValue >= construction.maxStore)
                {
                    construction.itemValue = construction.maxStore;
                }

            }
        }

        public void CanCollectVoid()
        {
            if (construction.canCollect)
            {
                construction.canCollect = false;
                if (thisTag == "Fish" || thisTag == "Hunt")
                {
                    foodData.itemTotal += construction.itemValue * construction.numConstructions;
                }
                else if (thisTag == "Resources")
                {
                    resourcesData.itemTotal += construction.itemValue * construction.numConstructions;
                }
                else if (thisTag == "Culture")
                {
                    cultureData.itemTotal += construction.itemValue * construction.numConstructions;
                }
                construction.itemValue = 0;
            }
            else if (Tap >= 0)
            {
                //InfoConstruction
                ObjectButton.SetActive(true);
                // textName.text = nameConstruction;
                // textInfo.text = infoConstruction;
                // textCaixa.enabled = true;
                // textCaixa.GetComponent<BoxCollider2D>().enabled = true;
                //InfoConstruction
                ConstructionInfo.instance.botao.SetActive(true);
                if(nameConstruction == "Armazem de Carne"){
                    infoButtonController.valorInfo = "caca";
                }
                else if(nameConstruction == "Armazem de Madeira"){
                    infoButtonController.valorInfo = "recurso";
                }   
                if(nameConstruction == "Pesca"){
                    infoButtonController.valorInfo = "pesca";
                }


                Tap = 0;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("TagUI"))
            {

            }
            else
            {
                isTrigger = true;
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("TagUI"))
            {

            }
            else
            {
                isTrigger = false;
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, construction.checkRadius);
        }
    }
}
