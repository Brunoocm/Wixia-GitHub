using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterData_SO", menuName = "Assets/CharacterData")]
public class CharacterData_SO : ScriptableObject
{
    public Sprite sprite;
    public string name = "Undefined";
    [TextArea(3, 10)]
    public string fala = "Speech Undefined";

}

