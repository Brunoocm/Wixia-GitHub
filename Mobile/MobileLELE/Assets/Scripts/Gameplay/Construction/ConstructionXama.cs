using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inter
{
   public class ConstructionXama : MonoBehaviour
   {
        public GameObject ativarTutorial;
        private bool ativo;

        Collider2D coll;
              
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
                        if (!ativo)
                        {
                            ativarTutorial.SetActive(true);
                            ativo = true;
                        }
                    }
                }
                if (touch.phase == TouchPhase.Ended)
                {

                }
            }
        }














    }
}
