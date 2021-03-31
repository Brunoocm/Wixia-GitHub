using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConstructionMovement : MonoBehaviour
{
    public float cellSize = 0.5f;

    private bool Holding;
    private float TimerHold = 0f;
    private Grid grid;
    private float Tap;
    private Collider2D coll;
    public SpriteRenderer artworkImage;
    public TMP_Text textInfo;

    void Update()
    {
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
                    artworkImage.color = Color.gray;
                    Holding = true;
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (Holding && TimerHold >= 0.5f)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                    transform.position = new Vector2(Mathf.RoundToInt(transform.position.x / cellSize) * cellSize, Mathf.RoundToInt(transform.position.y / cellSize) * cellSize);
                    artworkImage.color = Color.white;
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);
                if (coll == touchCollider)
                {
                    Holding = false;
                    TimerHold = 0;
                }
            }
        }
    }
}
