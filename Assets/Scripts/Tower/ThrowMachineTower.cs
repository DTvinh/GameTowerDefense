using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowMachimeTower : Tower
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


        Gizmos.DrawWireSphere(origin, radius);



        if (enemyPos == null) return;


        Vector3 startPosition = transform.position;
        Vector3 targetPosition = enemyPos.position;
        Vector3 direction = targetPosition - startPosition;

        float horizontalDistance = new Vector2(direction.x, direction.z).magnitude;
        float verticalDistance = direction.y;

        float hmax = Mathf.Max(targetPosition.y + 2f, startPosition.y + 2f);

        float timeToPeak = Mathf.Sqrt(2 * (hmax - startPosition.y) / 9.8f);
        float timeFromPeak = Mathf.Sqrt(2 * (hmax - targetPosition.y) / 9.8f);
        float totalTime = timeToPeak + timeFromPeak;

        float initialVelocityY = Mathf.Sqrt(2 * 9.8f * (hmax - startPosition.y));
        float initialVelocityX = horizontalDistance / totalTime;

        Vector3 horizontalDirection = new Vector3(direction.x, 0, direction.z).normalized;
        Vector3 velocityForGizmos = horizontalDirection * initialVelocityX;
        velocityForGizmos.y = initialVelocityY;


        Gizmos.color = Color.green;
        Vector3 previousPoint = startPosition;

        for (int i = 1; i <= 40; i++)
        {
            float t = totalTime * i / 40;
            Vector3 point = startPosition + velocityForGizmos * t + 0.5f * Physics.gravity * t * t;
            Gizmos.DrawLine(previousPoint, point);
            previousPoint = point;
        }
    }

    protected override void DetectEnemy()
    {

        raycastToHit = Physics2D.CircleCastAll(transform.position, radius, direction, 0f, enemyLayer);
        if (raycastToHit.Length > 0)
        {
            enemyPos = raycastToHit[0].transform;
            // Debug.Log(enemyPos?.name);
            // Hit();
            return;
        }
        enemyPos = null;
        return;
    }

}
