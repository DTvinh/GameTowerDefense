using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPlayGame : BaseButton
{
    public Transform screenSelect;
    protected override void OnClick()
    {
        screenSelect.gameObject.SetActive(true);
    }


}
