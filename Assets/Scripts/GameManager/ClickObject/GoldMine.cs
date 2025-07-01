using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMine : HarvestableObject
{

    float timeSpawnItem = 5;
    void Start()
    {

        // Harvest();
    }
    void Update()
    {

        if (canHarvest == false)
        {
            timeSpawnItem -= Time.deltaTime;
            if (timeSpawnItem <= 0)
            {
                timeSpawnItem = 5f;
                DropResource();
            }
        }
    }



    public override void Harvest()
    {

        // GameObject pawnObj = SpawnPawn.Instance.GetPawn();
        // if (pawnObj != null)
        // {
        //     pawnObj.transform.position = transform.position - new Vector3(0.5f, 0, 0);
        //     pawnObj.transform.SetParent(transform);
        //     pawnObj.SetActive(true);
        //     // DropItemManager.Instance.DropWoodItem(transform.position);
        //     base.Harvest();
        // }

        base.Harvest();

        // pawnObj.SetActive(false);
    }

    protected override void DropResource()
    {
        DropItemManager.Instance.DropCoinItem(new Vector3(transform.position.x - Random.Range(-1f, 1f), transform.position.y - 1f));
        GameObject treeStumpObj = ObjectPooling.Instance.GetObject(GameAssets.Instance.goldMine_inactive);
        treeStumpObj.transform.position = transform.position;
        treeStumpObj.SetActive(true);
    }

}
