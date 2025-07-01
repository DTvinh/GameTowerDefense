using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarvestBar : MonoBehaviour
{

    private float timeHarvesting = 10f;
    private Slider slider;

    private float timer = 0;


    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();

    }
    void OnEnable()
    {
        timer = 0;
    }
    void Update()
    {
        timer += Time.deltaTime;
        slider.value = timer / timeHarvesting;
        if (timer >= timeHarvesting)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetTimer(float time)
    {
        timeHarvesting = time;
    }
}
