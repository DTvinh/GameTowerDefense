using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILimitQuantityTower : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI txtlimit;

    void Start()
    {
        Observer.AddListener(CONSTANT.UPDATE_LIMIT_TOWER, SetTXT);

        Observer.Notify(CONSTANT.UPDATE_LIMIT_TOWER);
    }


    public void SetTXT(object[] datas)
    {
        txtlimit.text = BuildingManager.Instance.countTower + "/" + BuildingManager.Instance.limitQuantity;
    }


}
