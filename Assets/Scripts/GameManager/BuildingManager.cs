using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BuildingManager : MonoBehaviour
{

    // [SerializeField] Camera cam;
    public LayerMask layerMask;
    BuildingTypeSO buildingType;
    Transform PointerCurrent;

    public int limitQuantity;
    public int countTower;

    // Vector2 PointMouse;

    public static BuildingManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        DragPoint();
        Building();

    }

    void Building()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (buildingType != null && CanSpawnBuilding())
            {

                InventoryObject.SpendResources(buildingType);
                Observer.Notify(CONSTANT.UPDATE_QUANTITY);


                Vector2 Point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Transform towerObj = Instantiate(buildingType.perfab, Point, Quaternion.identity);
                towerObj.GetComponent<TowerUpgrade>().SetBuilding(buildingType);
                countTower++;
                buildingType = null;

                Observer.Notify(CONSTANT.UPDATE_LIMIT_TOWER);

                Destroy(PointerCurrent.gameObject);
                PointerCurrent = null;
                Observer.Notify(CONSTANT.UPDATE_SELECTED_BUILDING);
            }
        }
    }

    void DragPoint()
    {
        if (PointerCurrent == null)
        {
            return;
        }
        Vector2 PointMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        PointerCurrent.position = PointMouse;

    }
    public void SetBuildingType(BuildingTypeSO buildingTypeSO)
    {
        if (PointerCurrent != null) Destroy(PointerCurrent.gameObject);

        buildingType = buildingTypeSO;
        PointerCurrent = Instantiate(buildingType.pointerConstruction, Vector3.zero, Quaternion.identity);
    }
    private bool CanSpawnBuilding()
    {
        if (PointerCurrent == null || countTower >= limitQuantity)
        {
            return false;
        }
        bool isAreaClea = PointerCurrent.GetComponent<PointerConstruction>().canBuilding;
        return isAreaClea;

    }

    public BuildingTypeSO GetActiveBuildingType() => buildingType;


    public void SetEmptySelected()
    {
        buildingType = null;
        Destroy(PointerCurrent.gameObject);
        PointerCurrent = null;
        Observer.Notify(CONSTANT.UPDATE_SELECTED_BUILDING);
    }




}
