using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inter;
public class UpgradeYanos : MonoBehaviour
{

    public ItemData_SO foodData;
    public ItemData_SO resourcesData;
    public ItemData_SO cultureData;

    public int tirarFoodLV2;
    public int tirarResourcesLV2;
    public int tirarFoodLV3;
    public int tirarResourcesLV3;

    public Collider2D coll;

    private bool canUpgrade;
    GameObject TextSemRecursos;
    void Start()
    {
        canUpgrade = true;
    }

    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);

                if (coll == touchCollider)
                {
                   
                    if (canUpgrade)
                    {
                       
                        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
                        if (Yanos.Yanoslevel == 1)
                        {
                            if (foodData.itemTotal > tirarFoodLV2 && resourcesData.itemTotal > tirarResourcesLV2)
                            {
                                foodData.itemTotal -= tirarFoodLV2;
                                resourcesData.itemTotal -= tirarResourcesLV2;
                                Yanos.Yanoslevel++;
                            }
                            else
                            {
                                StartCoroutine(TextInsuficiente.TextOFF()); //texto sem recursos
                            }
                        }
                        else if (Yanos.Yanoslevel == 2)
                        {
                            if (foodData.itemTotal > tirarFoodLV3 && resourcesData.itemTotal > tirarResourcesLV3)
                            {
                                foodData.itemTotal -= tirarFoodLV3;
                                resourcesData.itemTotal -= tirarResourcesLV3;
                                Yanos.Yanoslevel++;
                            }
                            else
                            {
                                StartCoroutine(TextInsuficiente.TextOFF()); //texto sem recursos
                            }
                        }
                    }
              
                  
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }


        if (Yanos.Yanoslevel == 3)
        {
            canUpgrade = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

}
