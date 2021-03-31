using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inter 
{

public class SpawnMinigame : MonoBehaviour
    {

        [Header("Values")]       
        public bool ativarSeta;
        public float RandomNum;
        
        private bool ativo;
        private bool semTutorial;
        private float seconds;

        public static bool minigameOn;

        [Header("AllPos")]
        public Transform pos;
        public Transform posMinigame;
        public Transform cameraPos;

        [Header("Objects")]
        public GameObject ativarTutorial;
        public GameObject ativarMinigameTutorial;
        public GameObject sprite;
        public GameObject minigame;
        public GameObject minigameMusica2;
        public GameObject minigameMusica3;
        public AudioSource musiquinha;

        [Header("Anim")]
        public GameObject xawara;
        public GameObject Tempestade;
        public GameObject foguinho;
        public Animator anim;

        [Header("Tipo")]
        public bool isXawara;
        public bool isTempestade;
        public bool isFoguinho;



        public int minutes;
        private int chance;

        public Collider2D coll;
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
                        sprite.GetComponent<SpriteRenderer>().color = Color.gray;
                        if (ativarSeta)
                        {
                            //TUTORIAL UMA VEZ
                            if (semTutorial)
                            {
                                minigameOn = true;
                            }
                            else if (ativo)
                            {
                                ativarMinigameTutorial.SetActive(true);
                            }
                        }
                        if (!ativo)
                        {
                            ativarTutorial.SetActive(true);
                            ativo = true;
                        }
                    }
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    if (!ativarSeta)
                    {
                        anim.SetTrigger("NadaTrigger");
                    }
                    sprite.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }

            if (!minigameOn)
            {
                seconds += Time.deltaTime;
      
                if (seconds >= 60)
                {
                    minutes++; //contador de minutos

                    seconds = 0f;
                }
                if (minutes == 10)
                {
                    chance++;
                    RandomNum = Random.Range(0f, 1f);
                    minutes = 0;
                }
            }

            if(chance == 1 && RandomNum < 0.5f)
            {
                //spawnObject 30% de chance
                ativarSeta = true;
                xawara.SetActive(true);
                anim.SetTrigger("SetaTrigger");
                musiquinha.Pause();

                isXawara = true;
                isTempestade = false;
                isFoguinho = false;
               
            }
            if (chance == 2 && RandomNum < 0.5f)
            {
                //spawnObject 50% de chance
                ativarSeta = true;
                Tempestade.SetActive(true);
                anim.SetTrigger("SetaTrigger");
                musiquinha.Pause();

                isXawara = false;
                isTempestade = true;
                isFoguinho = false;
            }
            if (chance == 3)
            {
                //spawnObject 100% de chance
                ativarSeta = true;
                foguinho.SetActive(true);
                anim.SetTrigger("SetaTrigger");
                musiquinha.Pause();

                isXawara = false;
                isTempestade = false;
                isFoguinho = true;
            }

            if(minigameOn)
            {
                if(isXawara) Instantiate(minigame, posMinigame.position, Quaternion.identity);
                if(isTempestade) Instantiate(minigameMusica2, posMinigame.position, Quaternion.identity);
                if(isFoguinho) Instantiate(minigameMusica3, posMinigame.position, Quaternion.identity);

                xawara.SetActive(false);
                Tempestade.SetActive(false);
                foguinho.SetActive(false);

                cameraPos.position = pos.position;
                chance = 0;
                ativarSeta = false;
                minigameOn = false;
            }
        }

        public void AtivarTrue()
        {
            semTutorial = true;
        }
    
    }
}
