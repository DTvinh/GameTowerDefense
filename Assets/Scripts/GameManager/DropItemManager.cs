using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemManager : MonoBehaviour
{
    // public List<Transform> listItem;

    public Transform coin;
    public Transform meat;
    public Transform wood;

    public static DropItemManager Instance;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void DropCoinItem(Vector3 pos)
    {
        GameObject itemObj = ObjectPooling.Instance.GetObject(coin.gameObject);
        itemObj.transform.position = pos;
        itemObj.SetActive(true);

    }
    public void DropMeatItem(Vector3 pos)
    {
        GameObject itemObj = ObjectPooling.Instance.GetObject(meat.gameObject);
        itemObj.transform.position = pos;
        itemObj.SetActive(true);
    }
    public void DropWoodItem(Vector3 pos)
    {
        GameObject itemObj = ObjectPooling.Instance.GetObject(wood.gameObject);
        itemObj.transform.position = pos;
        itemObj.SetActive(true);
    }

    public void DropRandomItem(Vector3 pos)
    {
        Transform itemTarget = null;
        int rate = Random.Range(1, 100);
        if (rate >= 30)
        {
            if (rate >= 30 && rate < 80)
            {
                itemTarget = coin;
            }
            else if (rate >=80)
            {
                itemTarget = meat;
            }

            if (itemTarget != null)
            {
                GameObject itemObj = ObjectPooling.Instance.GetObject(itemTarget.gameObject);
                itemObj.transform.position = new Vector2(pos.x + Random.Range(-1, 1), pos.y);
                itemObj.SetActive(true);
            }


        }


    }
}
