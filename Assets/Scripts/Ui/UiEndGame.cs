using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiEndGame : MonoBehaviour
{
    public GameObject UiYouLose;
    public GameObject UiYouWin;
    public Star starWin;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActiveUiYouLose()
    {
        UiYouLose.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ActiveUiYouWin(int star)
    {
        UiYouWin.SetActive(true);
        UiYouWin.GetComponentInChildren<TextMeshProUGUI>().text = "Level " + GameManager.Instance.currenLevel;
        Time.timeScale = 0f;

        if (star == 3)
        {
            starWin.star3.gameObject.SetActive(true);
        }
        if (star == 2)
        {
            starWin.star2.gameObject.SetActive(true);
        }
        if (star == 1)
        {
            starWin.star1.gameObject.SetActive(true);
        }
    }

    [System.Serializable]
    public class Star
    {
        public Transform star1;
        public Transform star2;

        public Transform star3;

    }



}
