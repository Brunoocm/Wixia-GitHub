using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionInfo : MonoBehaviour
{
    public string atual = "none";
    public GameObject cacaInfo;
    public GameObject pescaInfo;
    public GameObject recursoInfo;
    public GameObject botao;

    private Collider2D coll;

    public static ConstructionInfo instance;

    void Start()
    {
        coll = GetComponent<CircleCollider2D>();
        instance = this;
        botao.SetActive(false);
    }

    void Update()
    {
        Touch touch = Input.GetTouch(0);
        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);
        if (!coll == touchCollider)
        {
            ConstructionInfo.instance.botao.SetActive(false);
        }

        if (atual == "caca")
        {
            cacaInfo.SetActive(true);
            pescaInfo.SetActive(false);
            recursoInfo.SetActive(false);
        }
        else if (atual == "pesca")
        {
            cacaInfo.SetActive(false);
            pescaInfo.SetActive(true);
            recursoInfo.SetActive(false);
        }
        else if (atual == "recurso")
        {
            cacaInfo.SetActive(false);
            pescaInfo.SetActive(false);
            recursoInfo.SetActive(true);
        }
        else
        {
            cacaInfo.SetActive(false);
            pescaInfo.SetActive(false);
            recursoInfo.SetActive(false);
        }
    }

    public void SetInfo(string str)
    {
        atual = str;
    }
}
