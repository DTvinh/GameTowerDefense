using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerUpgrade : MonoBehaviour
{
    [SerializeField] Transform towerLevel1;
    [SerializeField] Transform towerLevel2;
    [SerializeField] Transform towerLevel3;
    BuildingTypeSO buildingTypeSO;
    public BuildingTypeSO BuildingType => buildingTypeSO;
    int level;
    public int Level => level;


    void Start()
    {
        level = 1;
        ChangeTower(level);
    }


    void Update()
    {

    }

    public void Upgrade()
    {
        if (level < 3 && CheckResourceUpgrade())
        {

            foreach (var item in buildingTypeSO.towerPrice)
            {
                InventoryObject.PaymantByType(CalculatePrice(item.amount, level), item.typeItem);
            }
            level += 1;
            Observer.Notify(CONSTANT.UPDATE_QUANTITY);
            ChangeTower(level);



        }
    }

    private bool CheckResourceUpgrade()
    {
        foreach (var item in buildingTypeSO.towerPrice)
        {

            if (!InventoryObject.CheckResource(CalculatePrice(item.amount, level), item.typeItem))
            {
                return false;
            }
        }
        return true;


    }

    private int CalculatePrice(int item, int level)
    {
        return (int)(item * 0.55f * (level + 1));
    }


    public void SetBuilding(BuildingTypeSO buildingTypeSO)
    {
        this.buildingTypeSO = buildingTypeSO;
    }

    private void ChangeTower(int _level)
    {
        if (_level == 1)
        {
            towerLevel1.gameObject.SetActive(true);
            towerLevel2.gameObject.SetActive(false);
            towerLevel3.gameObject.SetActive(false);
        }
        else if (_level == 2)
        {
            towerLevel1.gameObject.SetActive(false);
            towerLevel2.gameObject.SetActive(true);
            towerLevel3.gameObject.SetActive(false);
        }
        else if (_level == 3)
        {
            towerLevel1.gameObject.SetActive(false);
            towerLevel2.gameObject.SetActive(false);
            towerLevel3.gameObject.SetActive(true);
        }

    }
}
