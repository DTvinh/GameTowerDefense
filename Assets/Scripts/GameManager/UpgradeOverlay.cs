using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeOverlay : MonoBehaviour
{
    public static UpgradeOverlay Instance;
    private Tower tower;


    public BuildingTypeSO buildingTypeSO;
    public int levelTower;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void Show_static(Tower tower)
    {
        Instance.Show(tower);
    }
    private void Show(Tower tower)
    {
        this.tower = tower;
        gameObject.SetActive(true);
        transform.position = tower.transform.position;
        buildingTypeSO = tower.TowerUpgrade.BuildingType;
        levelTower = tower.TowerUpgrade.Level;
        Debug.Log(levelTower);
        RefreshRangeVisual();

        // txtLevel.text = "LV." + tower.Level;
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    private void RefreshRangeVisual()
    {
        transform.Find("Range").localScale = Vector3.one * tower.Range * 0.39f;
        Observer.Notify(CONSTANT.UPDATE_RESOURCE_UPGRADE);
    }


    public void DestroyTower()
    {
        if (tower == null)
        {
            return;
        }
        Destroy(tower.gameObject);
        BuildingManager.Instance.countTower--;
        Observer.Notify(CONSTANT.UPDATE_LIMIT_TOWER);
        Hide();
    }
    public void UpgradeTower()
    {
        if (tower == null)
        {
            return;
        }
        tower.Upgrade();
        // txtLevel.text = "LV." + tower.Level;
        Hide();
        Debug.Log("hello");

    }

}
