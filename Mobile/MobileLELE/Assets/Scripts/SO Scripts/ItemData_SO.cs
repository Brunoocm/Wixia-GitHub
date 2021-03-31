using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemData_SO", menuName = "Assets/ItemData")]
public class ItemData_SO : ScriptableObject
{
    public Sprite itemImage;
    public int itemTotal = 0;
    public int itemMax = 1;

    ItemData_SO(Sprite _itemImage, int _itemTotal, int _itemMax)
    {
        itemImage = _itemImage;
        itemTotal = _itemTotal;
        itemMax = _itemMax;
    }

}

