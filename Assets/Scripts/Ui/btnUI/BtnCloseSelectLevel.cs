using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BtnCloseSelectLevel : BaseButton
{
    protected override void OnClick()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
