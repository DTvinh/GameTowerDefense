
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ArcherTower : Tower
{

    Vector2 direction = Vector2.right;


    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    void OnDrawGizmos()
    {

        Vector2 origin = transform.position;


        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(origin, radius);
        // Gizmos.color = Color.red;
        // Vector2 endPoint = origin + direction.normalized * 5;
        // Gizmos.DrawWireSphere(endPoint, 2);
    }

    protected override void DetectEnemy()
    {
        raycastToHit = Physics2D.CircleCastAll(transform.position, radius, direction, 0f, enemyLayer);
        if (raycastToHit.Length > 0)
        {
            // if (enemyPos == null || !enemyPos.gameObject.activeSelf)
            // {}
            enemyPos = raycastToHit[0].transform;


            return;
        }


        enemyPos = null;
        return;
    }
}
