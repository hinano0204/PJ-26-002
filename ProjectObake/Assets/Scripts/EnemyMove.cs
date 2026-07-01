using Unity.Netcode;
using UnityEngine;

public class EnemyMove : NetworkBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float attackRange = 2f;
    [SerializeField] float attackCooldown = 1f;

    Transform target;
    float cooldownTimer;

    void Update()
    {
        // ServerだけがAIを動かす
        if (!IsServer) return;

        // ターゲット探し
        FindNearestPlayer();

        if (target == null) return;

        float distance =
            Vector3.Distance(transform.position, target.position);

        // クールタイム中
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            return;
        }

        // 攻撃範囲内
        if (distance <= attackRange)
        {
            Attack();
        }
        else
        {
            ChaseTarget();
        }
    }

    void FindNearestPlayer()
    {
        GameObject[] players =
            GameObject.FindGameObjectsWithTag("Player");

        float nearestDistance = Mathf.Infinity;
        target = null;

        foreach (GameObject player in players)
        {
            float distance =
                Vector3.Distance(
                    transform.position,
                    player.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                target = player.transform;
            }
        }
    }

    void ChaseTarget()
    {
        transform.position =
            Vector3.MoveTowards(
                transform.position,
                target.position,
                moveSpeed * Time.deltaTime);
    }

    void Attack()
    {
        Debug.Log("攻撃");

        // ダメージ処理など

        cooldownTimer = attackCooldown;
    }
}