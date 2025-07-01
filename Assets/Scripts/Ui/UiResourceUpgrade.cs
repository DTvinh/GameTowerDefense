using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UiResourceUpgrade : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtMeat;
    [SerializeField] private TextMeshProUGUI txtWood;
    [SerializeField] private TextMeshProUGUI txtCoin;

    void Start()
    {
        Observer.AddListener(CONSTANT.UPDATE_RESOURCE_UPGRADE, UpdateUI);
    }


    private void UpdateUI(object[] datas)
    {
        if (UpgradeOverlay.Instance.levelTower >= 3)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            foreach (var item in UpgradeOverlay.Instance.buildingTypeSO.towerPrice)
            {
                switch (item.typeItem)
                {
                    case TypeItem.coin:
                        txtCoin.text = SetPrice(item.amount, UpgradeOverlay.Instance.levelTower) + "";
                        break;
                    case TypeItem.meat:
                        txtMeat.text = SetPrice(item.amount, UpgradeOverlay.Instance.levelTower) + "";
                        break;
                    case TypeItem.wood:
                        txtWood.text = SetPrice(item.amount, UpgradeOverlay.Instance.levelTower) + "";
                        break;
                }
            }

        }
    }

    private float SetPrice(int item, int level)
    {
        return (int)(item * 0.55f * (level + 1));
    }


}
