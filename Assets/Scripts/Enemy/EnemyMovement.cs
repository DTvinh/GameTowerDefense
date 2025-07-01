using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    int pathIndex = 0;
    [SerializeField] float speed;
    Transform pointTarget;
    Animator animator;
    public List<Transform> listPoints;
    Attack enemyAttack;
    bool canMovement = true;

    void Awake()
    {
        animator = GetComponent<Animator>();

    }
    void OnEnable()
    {
        pathIndex = 0;
        animator.SetBool("IsRuning", true);
        if (listPoints.Count > 0)
            pointTarget = listPoints[pathIndex];
        //     transform.position = listPoints[pathIndex].position;
    }

    void Start()
    {

        pointTarget = listPoints[pathIndex];
        // transform.position = listPoints[pathIndex].position;
        enemyAttack = GetComponent<Attack>();
        // pointTarget = PathManager.instance.listPoint[pathIndex];
        animator.SetBool("IsRuning", true);
    }
    void Update()
    {
        Move();
        TargetPos();
    }

    private void Move()
    {
        if (enemyAttack != null)
        {
            if (enemyAttack.attackTarget != null) { return; }
        }
        transform.position = Vector2.MoveTowards(transform.position, pointTarget.position, speed * Time.deltaTime);

        if (pointTarget.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 0);

        }
        else
        {
            transform.localScale = new Vector3(1, 1, 0);

        }
    }
    void TargetPos()
    {
        if (Vector2.Distance(transform.position, pointTarget.position) > 0.5f) { return; }
        pathIndex++;
        if (pathIndex >= listPoints.Count)
        {
            gameObject.SetActive(false);
            return;
        }
        pointTarget = listPoints[pathIndex];
    }

    public void SetMovement(bool movement)
    {
        canMovement = movement;
    }

    public void SetPath(List<Transform> _listPoint)
    {
        listPoints = _listPoint;
    }

}
