using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "BuildingTypeSO", menuName = "BuildingTypeSO")]

public class BuildingTypeSO : ScriptableObject
{
    public Transform perfab;
    public Transform pointerConstruction;
    public Sprite spriteUI;

    public TowerPrice[] towerPrice;

}


[System.Serializable]
public class TowerPrice
{
    public TypeItem typeItem;
    public int amount;
}
