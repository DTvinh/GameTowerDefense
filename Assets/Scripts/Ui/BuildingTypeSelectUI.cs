using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingSelectUI : MonoBehaviour
{

    [SerializeField] Transform buildingBtnTemplate;
    [SerializeField] Transform panelPrice;
    [SerializeField] List<BuildingTypeSO> ListBuildingSO;

    Dictionary<BuildingTypeSO, Transform> dictionaryBuilding;
    private TextMeshProUGUI txtPriceCoin;
    private TextMeshProUGUI txtPriceMeat;
    private TextMeshProUGUI txtPriceWood;

    private void Awake()
    {
        dictionaryBuilding = new Dictionary<BuildingTypeSO, Transform>();
        foreach (BuildingTypeSO buildingTypeSO in ListBuildingSO)
        {
            Transform BuidingBtn = Instantiate(buildingBtnTemplate, this.transform);
            BuidingBtn.Find("Image").GetComponent<Image>().sprite = buildingTypeSO.spriteUI;
            BuidingBtn.GetComponent<Button>().onClick.AddListener(() =>
            {
                HendleSelectBuilding(buildingTypeSO);
            });
            dictionaryBuilding.Add(buildingTypeSO, BuidingBtn);
            AddEventHover(BuidingBtn, buildingTypeSO);
        }
    }
    void Start()
    {
        txtPriceCoin = panelPrice.Find("PriceCoin").GetComponentInChildren<TextMeshProUGUI>();
        txtPriceWood = panelPrice.Find("PriceWood").GetComponentInChildren<TextMeshProUGUI>();
        txtPriceMeat = panelPrice.Find("PriceMeat").GetComponentInChildren<TextMeshProUGUI>();
        Observer.AddListener(CONSTANT.UPDATE_SELECTED_BUILDING, UpdateSelectedVisual);


    }

    private void HendleSelectBuilding(BuildingTypeSO buildingTypeSO)
    {
        if (InventoryObject.HasEnoughResources(buildingTypeSO))
        {
            BuildingManager.Instance.SetBuildingType(buildingTypeSO);
            Observer.Notify(CONSTANT.UPDATE_SELECTED_BUILDING);

        }
        // UpdateSelectedVisual();

    }

    private void UpdateSelectedVisual(object[] datas)
    {
        foreach (BuildingTypeSO buildingTypeSO in dictionaryBuilding.Keys)
        {
            dictionaryBuilding[buildingTypeSO].Find("Selected").gameObject.SetActive(false);
        }

        BuildingTypeSO buildingSO = BuildingManager.Instance.GetActiveBuildingType();
        if (buildingSO != null)
        {
            dictionaryBuilding[buildingSO].Find("Selected").gameObject.SetActive(true);
        }

    }

    private void AddEventHover(Transform BuidingBtn, BuildingTypeSO buildingTypeSO)
    {
        EventTrigger trigger = BuidingBtn.gameObject.GetComponent<EventTrigger>();
        if (trigger == null)
            trigger = BuidingBtn.gameObject.AddComponent<EventTrigger>();

        // Thêm sự kiện PointerEnter (hover vào)
        EventTrigger.Entry entryEnter = new EventTrigger.Entry();
        entryEnter.eventID = EventTriggerType.PointerEnter;
        entryEnter.callback.AddListener((data) => { OnHoverEnter(BuidingBtn.position, buildingTypeSO); });
        trigger.triggers.Add(entryEnter);

        // Thêm sự kiện PointerExit (hover ra)
        EventTrigger.Entry entryExit = new EventTrigger.Entry();
        entryExit.eventID = EventTriggerType.PointerExit;
        entryExit.callback.AddListener((data) => { OnHoverExit(); });
        trigger.triggers.Add(entryExit);
    }

    private void OnHoverEnter(Vector3 pos, BuildingTypeSO buildingTypeSO)
    {
        panelPrice.position = new Vector3(panelPrice.position.x, pos.y);
        panelPrice.gameObject.SetActive(true);
        foreach (TowerPrice towerPrice in buildingTypeSO.towerPrice)
        {
            if (towerPrice.typeItem == TypeItem.coin)
            {
                txtPriceCoin.text = towerPrice.amount.ToString();
                continue;
            }
            if (towerPrice.typeItem == TypeItem.wood)
            {
                txtPriceWood.text = towerPrice.amount.ToString();
                continue;
            }
            if (towerPrice.typeItem == TypeItem.meat)
            {
                txtPriceMeat.text = towerPrice.amount.ToString();
                continue;
            }

        }
    }


    private void OnHoverExit()
    {
        panelPrice.gameObject.SetActive(false);

    }





}
