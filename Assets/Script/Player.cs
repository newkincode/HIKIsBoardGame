using System;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public Vector2 inputVec;
    public float maxSpeed;

    Rigidbody2D rigid;

    void Awake(){
        rigid = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value){
        inputVec = value.Get<Vector2>();
    }

    void Update(){
        // inputVec의 x값이 0보다 클 때만 속도를 조정합니다.
        if (Input.GetButtonUp("Horizontal")){
            // 속도를 반으로 줄입니다.
            rigid.linearVelocity = new Vector2(rigid.linearVelocity.normalized.x * 0.5f, rigid.linearVelocity.y);
            Debug.Log(rigid.linearVelocity.normalized.x * 0.5f);
        }
    }

    void FixedUpdate(){
        float h = inputVec.x;
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        
        if (rigid.linearVelocity.x > maxSpeed)
            rigid.linearVelocity = new Vector2(maxSpeed, rigid.linearVelocity.y);
        else if (rigid.linearVelocity.x > maxSpeed*(-1))
            rigid.linearVelocity = new Vector2(maxSpeed*(-1), rigid.linearVelocity.y);
    }
}
