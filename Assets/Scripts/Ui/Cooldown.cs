using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    private float cooldown;
    private bool isCooldown;
    public bool IsCooldown => isCooldown;


    [SerializeField] Image image;

    // Update is called once per frame
    void Update()
    {
        Cooldowning();
    }
    public void SetCooldown(float time)
    {
        cooldown = time;
        image.fillAmount = 1;
        isCooldown = true;

    }
    private void Cooldowning()
    {
        if (isCooldown)
        {
            image.fillAmount -= 1 / cooldown * Time.deltaTime;

            if (image.fillAmount <= 0)
            {

                image.fillAmount = 0;
                isCooldown = false;

            }


        }
    }




}
