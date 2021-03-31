using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "ScriptableConstruction", menuName = "Assets/ScriptableConstruction")]
public class ScriptableConstruction : ScriptableObject
{
    [Header("Settings")]
    public new string name;
    public string nameConstruction;
    public string infoConstruction;
    public Sprite artwork;
    public Sprite balao;

    [Header("Values")]
    public int maxStore;
    public int itemValue;

    public float timerValue = 10;
    public float timerInicio;

    public bool canCollect;

    [Header("Vector")]
    public int numConstructions;
    public GameObject[] vetorConstructions;

    [Header("Double itens")]
    public float checkRadius;
    public bool areaDouble;
    public LayerMask LayerDouble;



}

