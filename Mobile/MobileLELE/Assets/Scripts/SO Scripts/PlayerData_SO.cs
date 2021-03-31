using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData_SO", menuName = "Assets/PlayerData")]
public class PlayerData_SO : ScriptableObject
{
    public string playerName;
    public int playerLevel;
    public int[] playerItems;
}

