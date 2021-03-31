using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarFlash : MonoBehaviour
{
    public bool bumDagua;
    public bool chocalho;
    public bool tambor;


    private bool isTouching;

    public Collider2D coll;

    public GameObject ObjectColor;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
                    spriteRenderer.color = Color.gray;
                    if (isTouching)
                    {
                        Destroy(ObjectColor);
                        print("oi");

                        //if(bumDagua) FindObjectOfType<AudioManager>().Play("BumDagua");
                        //if(chocalho) FindObjectOfType<AudioManager>().Play("Chocalho");
                        //if(tambor) FindObjectOfType<AudioManager>().Play("Tambor");
                    }
                    else
                    {
                       FindObjectOfType<AudioManager>().Play("Errou");
                    }

                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                spriteRenderer.color = Color.white;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Notas"))
        {
            isTouching = true;
            ObjectColor = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Notas"))
        {
            isTouching = false;
        }
    }
}

