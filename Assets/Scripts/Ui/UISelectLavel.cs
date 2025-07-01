using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UISelectLavel : MonoBehaviour
{
    [SerializeField] List<LevelSO> listLevelSO;

    [SerializeField] Transform btnLevelPrefabs;
    void Start()
    {
        InitLevel();


    }
    private void InitLevel()
    {
        foreach (LevelSO levelSO in listLevelSO)
        {
            Transform newBtn = Instantiate(btnLevelPrefabs, this.transform);
            LevelData levelData = SaveSystem.GetLevelData(levelSO.levelNumber);
            UiInforLevel uiInfor = newBtn.GetComponentInChildren<UiInforLevel>();
            if (levelData.unLock)
            {
                uiInfor.ShowStar(levelData.levelNumber, levelData.starsEarned);
                newBtn.GetComponent<Button>().onClick.AddListener(() =>
                {
                    HendleSeclect(levelSO);
                });
                // // newBtn.Find("Infor").Find("star1").gameObject.SetActive(true);
                // // Debug.Log(levelData.starsEarned);
                // newBtn.GetComponentInChildren<TextMeshProUGUI>().text = levelSO.levelNumber.ToString();
                // newBtn.GetComponent<Button>().onClick.AddListener(() =>
                // {
                //     HendleSeclect(levelSO);
                // });

            }
            else
            {
                uiInfor.ShowLock();

            }

        }
    }
    private void HendleSeclect(LevelSO levelSO)
    {
        SceneManager.LoadScene(levelSO.sceneLevel);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
