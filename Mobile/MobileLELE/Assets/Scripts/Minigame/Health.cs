using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameObject desativaTudo;

    public static float intHealth;
    private float maxHealth = 3;

    Image health;
    GameObject camera;
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        intHealth = maxHealth;
        health = GetComponent<Image>();
    }

    void Update()
    {
        health.fillAmount = intHealth / maxHealth;
        if(intHealth <= 0)
        {
            //ativaaqui
            camera.transform.position = new Vector3(-1.08f, 0.3f, -10);
            VitoriaDerrota.AtivaDerrota();
            Destroy(desativaTudo);
        }
    }
}
