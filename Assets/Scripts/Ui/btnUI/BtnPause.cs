using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPause : BaseButton
{
    [SerializeField] Transform UiPanelPause;
    protected override void OnClick()
    {
        Time.timeScale = Time.timeScale == 0 ? 1f : 0f;
        UiPanelPause.gameObject.SetActive(!UiPanelPause.gameObject.activeSelf);

    }
}
