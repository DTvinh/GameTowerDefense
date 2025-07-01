using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update

    private Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();

    }
    void Start()
    {
    }

    // Update is called once per frame
    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        slider.value = currentHealth / maxHealth;
    }
}
