using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notas : MonoBehaviour
{
    public float TimeSpeed;

    public bool Azul;
    public bool Vermelho;
    public bool Verde;

    GameObject targetDirectionObject;
    Transform targetDirectionPos;
    private void Awake()
    {
        if (Azul) targetDirectionObject = GameObject.Find("targetDirectionAzul");
        if (Vermelho) targetDirectionObject = GameObject.Find("targetDirectionVermelho");
        if (Verde) targetDirectionObject = GameObject.Find("targetDirectionVerde");

        targetDirectionPos = targetDirectionObject.GetComponent<Transform>();
    }
    void Start()
    {
        StartCoroutine(DestroyNota());

    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetDirectionPos.position, TimeSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DestroyNota"))
        {
            Health.intHealth -= 1;
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyNota()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
