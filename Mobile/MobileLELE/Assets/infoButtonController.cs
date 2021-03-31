using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoButtonController : MonoBehaviour
{
    public static string valorInfo;
    public string valor;

    void Update()
    {
        valor = valorInfo;
    }
    public void BotaoInfo()
    {
        ConstructionInfo.instance.atual = valorInfo;
    }
}
