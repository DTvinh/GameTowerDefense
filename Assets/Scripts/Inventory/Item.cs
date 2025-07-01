using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSO itemSO;

    private void OnEnable()
    {
        Invoke("DesActive", 5f);
    }
    private void DesActive()
    {
        // Destroy(gameObject);
        InventoryObject.addItem(itemSO, Random.Range(10, 30));
        Observer.Notify(CONSTANT.UPDATE_QUANTITY);
        gameObject.SetActive(false);
    }
}
