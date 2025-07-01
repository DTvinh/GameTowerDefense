using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : SupportSkills
{
    // Start is called before the first frame update
    [SerializeField] float damage;
    BoxCollider2D boxcollider;
    void Awake()
    {
        boxcollider = GetComponent<BoxCollider2D>();
    }
    private void OnEnable()
    {

        Attack();
    }

    void Start()
    {
        boxcollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Attack()
    {
        Collider2D[] objectsToHit = Physics2D.OverlapBoxAll(boxcollider.bounds.center, boxcollider.bounds.size, 0, SkillsManager.Instance.AttackLayer);

        if (objectsToHit.Length > 0)
        {
            for (var i = 0; i < objectsToHit.Length; i++)
            {
                IDamageAble CanTakedamage = objectsToHit[i].GetComponent<IDamageAble>();
                if (CanTakedamage != null)
                {
                    CanTakedamage.TakeDamage(damage);
                }

            }
        }
    }
    public override void SpawnPrefabs(Vector3 PoinSpawn)
    {
        GameObject lightning = ObjectPooling.Instance.GetObject(GameAssets.Instance.lightning);
        lightning.transform.position = PoinSpawn;
        lightning.SetActive(true);
        GameObject crack = ObjectPooling.Instance.GetObject(GameAssets.Instance.crack);
        crack.transform.position = PoinSpawn;
        Observer.Notify(CONSTANT.CAMERA_SHAHKE);

        crack.SetActive(true);

    }


}
