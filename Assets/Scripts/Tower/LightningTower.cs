using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningTower : Tower
{

    [SerializeField] GameObject lightning;


    // float timer;

    protected override void Update()
    {
        base.Update();
    }
    void OnDrawGizmos()
    {

        Vector2 origin = PointAttack.position;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(origin, radius);

    }
    protected override void DetectEnemy()
    {
        raycastToHit = Physics2D.CircleCastAll(PointAttack.position, radius, Vector2.right, 0f, enemyLayer);

        if (raycastToHit.Length > 0)
        {
            enemyPos = raycastToHit[0].transform;
            // Debug.Log(enemyPos?.name);
            return;
        }
        enemyPos = null;
        return;
    }




}
