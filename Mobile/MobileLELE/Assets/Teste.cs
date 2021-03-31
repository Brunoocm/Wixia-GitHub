using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inter
{
    public class Teste : MonoBehaviour
    {
        public DialogController dialogController;

        public bool clicou = false;

        void Update()
        {
            if (Input.touchCount > 0 && clicou == false)
            {
                DialogController.instance.CreateDialog("cacador", "Isso é um caçador falando");
            }
        }

        public void Clicou()
        {
            clicou = true;
        }
    }
}


