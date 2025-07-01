using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnNextLv : BaseButton
{
    public string leveNext;
    protected override void OnClick()
    {
        if (leveNext == "")
        {
            return;
        }
        SceneManager.LoadScene(leveNext);
    }
}
