using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;
using Unity.Netcode;

public class PlayerMove : MonoBehaviour
{
    public float movespeed = 5f;
    public Rigidbody rb;
    float x = 0f;
    float y = 0f;
   

    private Vector3 pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pos = new Vector3(x, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //自分のオブジェクトだけ入力を設定
        if (IsOwner)
        {
            // 移動入力を設定
        */

        float x = Input.GetAxisRaw("Horizontal");   //左右　移動キー
        float y = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(x, y, 0);

        rb.linearVelocity = move * movespeed;

        //SetMoveInputServerRpc(
        //        Input.GetAxisRaw("Horizontal"),
        //        Input.GetAxisRaw("Vertical"));
        /*
        }

        //ホストの場合
        if (IsHost)
        {
            HostUpdate();
        }
        */

        
    }
}
