using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseBuilding : BaseButton
{
    protected override void OnClick()
    {
        BuildingManager.Instance.SetEmptySelected();
    }

    // // Start is called before the first frame update
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {

    // }
}
