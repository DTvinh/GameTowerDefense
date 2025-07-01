using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnUpgradeTower : BaseButton
{
    protected override void OnClick()
    {
        UpgradeOverlay.Instance.UpgradeTower();
    }
}
