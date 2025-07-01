using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePupop : MonoBehaviour
{
    TextMeshPro textDamage;
    private void Awake()
    {
        textDamage = GetComponent<TextMeshPro>();
    }

    public void setUp(float damageAmount)
    {
        textDamage.text = damageAmount.ToString();
    }

    private void Update()
    {
        transform.position += new Vector3(0, 2f) * Time.deltaTime;
    }


}
