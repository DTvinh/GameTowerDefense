using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseSkill : BaseButton
{
    protected override void OnClick()
    {
        SkillsManager.Instance.SetEmptySelected();

    }

}
