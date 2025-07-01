using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public GameObject damagePopup;
    public GameObject bleedEffect;

    public GameObject DragBullet;
    public GameObject PoisonBullet;


    public GameObject warrior_purple;
    public GameObject warrior_blue;


    public GameObject lightning;
    public GameObject crack;
    public GameObject destroy;

    public GameObject tree;

    public GameObject treeStump;

    public GameObject goldMine_inactive;




    public GameObject pawn;


    public static GameAssets Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
