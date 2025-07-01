using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] protected float radius;
    protected Camera currentCamera; // Thêm biến lưu trữ camera
    [SerializeField] private LayerMask clickableLayer;


    public float Range => radius;
    [SerializeField] float damage;
    public float Damage => damage;

    [SerializeField] protected Transform PointAttack;
    protected RaycastHit2D[] raycastToHit;
    public LayerMask enemyLayer;
    public Transform enemyPos;

    private TowerUpgrade towerUpgrade;
    public TowerUpgrade TowerUpgrade => towerUpgrade;


    protected virtual void Start()
    {
        towerUpgrade = GetComponentInParent<TowerUpgrade>();
        currentCamera = Camera.main;
    }
    protected virtual void Update()
    {
        DetectClick();
        DetectEnemy();
    }

    protected virtual void DetectEnemy() { }


    // protected void OnMouseEnter()
    // {
    //     UpgradeOverlay.Show_static(this);
    // }

    protected void DetectClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Vector2 mousePos = currentCamera.ScreenToWorldPoint(Input.mousePosition);
            // RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, clickableLayer);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {


                UpgradeOverlay.Show_static(this);

            }

        }
    }


    public virtual void Upgrade()
    {
        if (towerUpgrade)
        {
            towerUpgrade.Upgrade();
        }
    }

}