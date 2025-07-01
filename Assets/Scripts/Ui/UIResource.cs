using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIResource : MonoBehaviour
{
    Transform UiCoin;
    Transform UiMeat;
    Transform UiWood;
    void Start()
    {
        UiCoin = transform.Find("Coin");
        UiMeat = transform.Find("Meat");
        UiWood = transform.Find("Wood");
        Observer.AddListener(CONSTANT.UPDATE_QUANTITY, UpdateQuantityUI);
        Observer.Notify(CONSTANT.UPDATE_QUANTITY);
    }

    void Update()
    {

    }

    public void UpdateQuantityUI(object[] datas)
    {
        // ItemSO itemSO = ItemSO(datas[0]);
        UiCoin.GetComponentInChildren<TextMeshProUGUI>().text = InventoryObject.Resource.coin.ToString();
        UiMeat.GetComponentInChildren<TextMeshProUGUI>().text = InventoryObject.Resource.meat.ToString();
        UiWood.GetComponentInChildren<TextMeshProUGUI>().text = InventoryObject.Resource.wood.ToString();



        // switch (itemSO.typeItem)
        // {
        //     case TypeItem.coin:
        //         break;
        //     case TypeItem.meat:
        //         break;
        //     case TypeItem.wood:
        //         break;
        // }

    }
}
