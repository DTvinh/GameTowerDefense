using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnDestroyTower : BaseButton
{
    protected override void OnClick()
    {
        UpgradeOverlay.Instance.DestroyTower();
    }
}
