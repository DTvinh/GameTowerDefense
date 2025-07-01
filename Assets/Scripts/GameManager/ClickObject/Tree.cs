using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : HarvestableObject
{
    void Start()
    {

        // Harvest();
    }

    void Update()
    {

    }

    public override void Harvest()
    {



        base.Harvest();

        // pawnObj.SetActive(false);
    }

    protected override void DropResource()
    {
        DropItemManager.Instance.DropWoodItem(transform.position * 1.05f);
        GameObject treeStumpObj = ObjectPooling.Instance.GetObject(GameAssets.Instance.treeStump);
        treeStumpObj.transform.position = transform.position;
        treeStumpObj.SetActive(true);
    }


}
