using System.Globalization;
using Unity.Netcode;
using UnityEngine;

public class TestotinoPL : MonoBehaviour
{
   

    public float m_moveSpeed = 1;

    private Rigidbody m_rigidBody;

    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
    }

    // ï®óùââéZÇ»ÇÃÇ≈ FixedUpdate Çégóp
    private void FixedUpdate()
    {
       
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            var velocity = Vector3.zero;
            velocity.x = m_moveSpeed * x;
            velocity.y = m_moveSpeed * y;

      
    }
}