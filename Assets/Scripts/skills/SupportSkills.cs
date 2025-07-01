using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportSkills : MonoBehaviour
{
    protected Transform prefabs;
    protected Vector3 positionTarget;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetPositionTarget(Vector3 target)
    {

        positionTarget = target;
    }


    protected virtual void Attack()
    {

    }
    public virtual void SpawnPrefabs(Vector3 pos)
    {


    }

}
