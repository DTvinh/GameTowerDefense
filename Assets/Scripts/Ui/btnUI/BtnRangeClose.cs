using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnRangeClose : BaseButton
{
    protected override void OnClick()
    {
        UpgradeOverlay.Instance.Hide();
    }
}
