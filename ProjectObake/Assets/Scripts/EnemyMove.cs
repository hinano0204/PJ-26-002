using Unity.Netcode;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class EnemyMove : NetworkBehaviour
{

    //[SerializeField] private PlayerController _playerController;
    public Transform player;
    public float speed = 5f;
    public GameObject Enemy;
    private int count;

    private void Start()
    {
      // Enemy.SetActive(false);
        Invoke(nameof(Update), 5f);
        Enemy.SetActive(false);
    }
    void Update()
    {
        //count += 1;
        //Debug.Log("ÉJÉEÉìÉg" + count);
        //if(count < 5)
        //{
        //    Enemy.SetActive(true);
        //}
        Enemy.SetActive(true);
        Vector3 pos = transform.position;

        if (player.position.x > pos.x)
        {
            pos.x += speed * Time.deltaTime;
        }
        else
        {
            pos.x -= speed * Time.deltaTime;
        }

        transform.position = pos;

        RaycastHit hit;

        if (Physics.Raycast(transform.position,
            transform.right,
            out hit,
            1f))
        {
            // è·äQï®î≠å©
        }

    }

}