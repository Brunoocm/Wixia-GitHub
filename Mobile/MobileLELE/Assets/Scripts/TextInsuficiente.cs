using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInsuficiente : MonoBehaviour
{
    public static GameObject TextSemRecursos;
    public static GameObject TextYanosBaixo;

    public static bool semRecursos;
    public static bool semNivel;
    void Start()
    {
        TextSemRecursos = GameObject.Find("RecursosInsuficientesText");
        TextYanosBaixo = GameObject.Find("NivelErradoYanosText");
        TextSemRecursos.SetActive(false);
        TextYanosBaixo.SetActive(false);
    }

    void Update()
    {

    }



    public static IEnumerator TextOFF()
    {
        TextSemRecursos.SetActive(true);
        yield return new WaitForSeconds(1);
        TextSemRecursos.SetActive(false);
    }

    public static IEnumerator TextYanosOFF()
    {
        //TextYanosBaixo.SetActive(true);
        yield return new WaitForSeconds(1);
        //TextYanosBaixo.SetActive(false);
    }
}
