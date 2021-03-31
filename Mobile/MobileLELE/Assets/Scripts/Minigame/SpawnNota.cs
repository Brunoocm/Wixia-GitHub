using Inter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNota : MonoBehaviour
{
    public Transform posAZ;
    public Transform posVM;
    public Transform posVD;

    public GameObject main;
    public GameObject notaAZ;
    public GameObject notaVM;
    public GameObject notaVD;

    public float randomTime;
    public float TempoMusica;
    
    private float resetTime;
    public int randomPos;
    private int lastPos;

    GameObject camera;
    GameObject desativarUI;
    void Start()
    {
        RandomNum(1, 4);
        resetTime = randomTime;
        camera = GameObject.Find("Main Camera");
        desativarUI = GameObject.Find("Menu Principal");
        desativarUI.SetActive(false);
    }

    void Update()
    {
        randomTime -= Time.deltaTime;
        TempoMusica -= Time.deltaTime;
        if (TempoMusica >= 0)
        {
            if (randomPos == 1 && randomTime <= 0)
            {
                SpawnAZ();
            }
            if (randomPos == 2 && randomTime <= 0)
            {
                SpawnVM();
            }
            if (randomPos == 3 && randomTime <= 0)
            {
                SpawnVD();
            }
        }
        else
        {
            camera.transform.position = new Vector3(-1.08f, 0.3f, -10);
            StartCoroutine(DestroyTudo());
        }
    }

    
    public int RandomNum(int min, int max)
    {
        randomPos = Random.Range(min, max);
        while (lastPos == randomPos)
        {
            randomPos = Random.Range(min, max);
        }
        lastPos = randomPos;
        return randomPos;
    }

    public void SpawnAZ()
    {
        Instantiate(notaAZ, posAZ.position, posAZ.rotation);
        RandomNum(1, 4);
        randomTime = resetTime;
    }
    public void SpawnVM()
    {
        Instantiate(notaVM, posVM.position, posVM.rotation);
        RandomNum(1, 4);
        randomTime = resetTime;
    }
    public void SpawnVD()
    {
        Instantiate(notaVD, posVD.position, posVD.rotation);
        RandomNum(1, 4);
        randomTime = resetTime;
    }

    IEnumerator DestroyTudo()
    {
        Health.intHealth = 3;
        desativarUI.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        VitoriaDerrota.AtivaVitoria();
        Destroy(main);
    }

}
