using UnityEngine;

[CreateAssetMenu(fileName = "GameData_SO", menuName = "Assets/GameData")]
public class GameData_SO : ScriptableObject
{
    public int food;
    public int foodMax;
    public int resources;
    public int resourcesMax;
    public int gems;
}

