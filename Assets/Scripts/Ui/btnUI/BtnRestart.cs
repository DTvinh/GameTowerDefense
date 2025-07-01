using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnRestart : BaseButton
{
    protected override void OnClick()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        // SceneManager.LoadScene("level_2");
        SceneManager.LoadScene(currentSceneName);
        Time.timeScale = 1f;



    }
}
