// using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerWarrior : Tower
{

    public List<GameObject> knightList;

    RaycastHit2D[] objectsToHit;
    protected override void Start()
    {
        SpawnWarrior();
        base.Start();

    }
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
        objectsToHit = Physics2D.CircleCastAll(transform.position, radius, Vector2.right, 0f, enemyLayer);

        if (objectsToHit.Length > 0)
        {
            enemyPos = objectsToHit[0].transform;

            return;
        }
        enemyPos = null;
        return;
    }

    private void SpawnWarrior()
    {

        for (int i = 0; i < 2; i++)
        {
            // GameObject knightObj = ObjectPooling.Instance.GetObject(GameAssets.Instance.warrior_blue);
            GameObject knightObj = Instantiate(GameAssets.Instance.warrior_blue, this.transform);

            // knightObj.transform.SetParent(this.transform);
            knightObj.GetComponent<Attack>().SetDamage(Damage);
            knightObj.transform.position = new Vector2(transform.position.x + Random.Range(-2, 2), transform.position.y);
            // knightObj.SetActive(true);
            knightList.Add(knightObj);
        }

    }


}
