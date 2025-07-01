using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : MonoBehaviour
{
    private static IventoryResource resource = new IventoryResource();
    public static IventoryResource Resource => resource;

    private void Start()
    {
        resource.coin = 500;
        resource.meat = 500;
        resource.wood = 500;

    }

    public static void addItem(ItemSO itemSO, int amount)
    {
        switch (itemSO.typeItem)
        {
            case TypeItem.coin:
                resource.coin += amount;
                break;
            case TypeItem.meat:
                resource.meat += amount;
                break;
            case TypeItem.wood:
                resource.wood += amount;
                break;
        }
    }
    public static bool HasEnoughResources(BuildingTypeSO buildingTypeSO)
    {
        foreach (TowerPrice towerPrice in buildingTypeSO.towerPrice)
        {
            if (!CheckResource(towerPrice.amount, towerPrice.typeItem))
            {
                return false;
            }
        }
        return true;
    }
    public static bool CheckResource(int amount, TypeItem type)
    {
        switch (type)
        {
            case TypeItem.coin:
                if (amount > resource.coin)
                {
                    return false;
                }
                break;
            case TypeItem.meat:
                if (amount > resource.meat)
                {
                    return false;
                }
                break;
            case TypeItem.wood:
                if (amount > resource.wood)
                {
                    return false;
                }
                break;
        }
        return true;
    }

    public static void SpendResources(BuildingTypeSO buildingTypeSO)
    {
        foreach (TowerPrice towerPrice in buildingTypeSO.towerPrice)
        {
            switch (towerPrice.typeItem)
            {
                case TypeItem.coin:
                    resource.coin -= towerPrice.amount;
                    break;
                case TypeItem.meat:
                    resource.meat -= towerPrice.amount;
                    break;
                case TypeItem.wood:
                    resource.wood -= towerPrice.amount;
                    break;
            }
        }
    }

    public static void PaymantByType(int amount, TypeItem type)
    {
        switch (type)
        {
            case TypeItem.coin:
                resource.coin -= amount;
                break;
            case TypeItem.meat:
                resource.meat -= amount;
                break;
            case TypeItem.wood:
                resource.wood -= amount;
                break;
        }

    }

}
public struct IventoryResource
{
    public int coin;
    public int meat;
    public int wood;

}

