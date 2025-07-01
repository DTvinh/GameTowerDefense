using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnResume : BaseButton
{

    [SerializeField] Transform PausePanel;
    protected override void OnClick()
    {
        Time.timeScale = 1f;
        SaveSystem.SaveSettingSound();
        PausePanel.gameObject.SetActive(false);
        Debug.Log("saveSetting");
    }
}
