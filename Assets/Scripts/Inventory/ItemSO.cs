using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "ItemSO", menuName = "Inventory/newItemSO")]
public class ItemSO : ScriptableObject
{
    public int itemID;
    public Sprite sprite;
    public TypeItem typeItem;
    [TextArea(10, 15)]
    public string description;

}

public enum TypeItem
{
    coin,
    wood,
    meat



}