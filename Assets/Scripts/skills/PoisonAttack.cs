using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonAttack : SupportSkills
{
    public GameObject Explosion_poison;
    public GameObject poison;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, 6f) * Time.deltaTime;
        if (transform.position.y <= positionTarget.y)
        {
            GameObject obj = ObjectPooling.Instance.GetObject(Explosion_poison);
            GameObject obj1 = ObjectPooling.Instance.GetObject(poison);
            obj.transform.position = this.transform.position;
            obj.SetActive(true);
            obj1.transform.position = this.transform.position;
            obj1.SetActive(true);
            Destroy(gameObject);
        }
    }


    public override void SpawnPrefabs(Vector3 PoinSpawn)
    {
        GameObject obj = Instantiate(GameAssets.Instance.PoisonBullet, new Vector2(PoinSpawn.x, PoinSpawn.y + 3f), Quaternion.identity);
        obj.GetComponent<SupportSkills>().SetPositionTarget(PoinSpawn);
    }

}
