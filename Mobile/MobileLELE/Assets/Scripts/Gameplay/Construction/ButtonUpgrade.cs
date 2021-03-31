using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inter
{
    public class ButtonUpgrade : MonoBehaviour
    {
        public UpgradeConstruction upgradeScript;

        private Collider2D coll;
        private SpriteRenderer sprite;
        void Start()
        {
            coll = GetComponent<Collider2D>();
            sprite = GetComponent<SpriteRenderer>();
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
                        sprite.color = Color.gray;
                        upgradeScript.UpgradeThis();
                    }
                    if (!coll == touchCollider)
                    {
                        sprite.color = Color.white;
                    }
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);
                    if (coll == touchCollider)
                    {
                        sprite.color = Color.white;
                    }
                }
            }
        }
    }
}
