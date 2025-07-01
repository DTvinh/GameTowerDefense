using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : HarvestableObject
{


    void Start()
    {

        // Harvest();
    }
    // Update is called once per frame
    void Update()
    {
    }

    public override void Harvest()
    {


        base.Harvest();


    }

    protected override void DropResource()
    {
        DropItemManager.Instance.DropMeatItem(transform.position * 1f);

    }






}
