using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : SupportSkills
{
    public override void SpawnPrefabs(Vector3 pos)
    {
        float space = 0.5f;
        for (int i = 0; i < 2; i++)
        {
            Vector2 location = new Vector2(pos.x + space, pos.y);
            GameObject KnightObj = ObjectPooling.Instance.GetObject(GameAssets.Instance.warrior_purple);
            KnightObj.transform.position = location;
            KnightObj.SetActive(true);
            space *= -1;

        }
    }


}
