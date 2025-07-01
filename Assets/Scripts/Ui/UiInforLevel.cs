using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiInforLevel : MonoBehaviour
{
    [SerializeField] Sprite[] spritesStar;
    [SerializeField] Transform txtLevel;
    [SerializeField] Transform image;


    [SerializeField] Transform TrlLock;

    public void ShowStar(int levelNumber, int starNumber)
    {
        txtLevel.GetComponent<TextMeshProUGUI>().text = levelNumber.ToString();
        txtLevel.gameObject.SetActive(true);
        image.GetComponent<Image>().sprite = spritesStar[starNumber];
        image.gameObject.SetActive(true);
    }
    public void ShowLock()
    {
        TrlLock.gameObject.SetActive(true);
    }
}
