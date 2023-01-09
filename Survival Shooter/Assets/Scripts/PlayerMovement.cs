using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 180f;

    private PlayerInput playerInput;
    private Rigidbody playerRigidbody;
    private Animator playerAnimator;


    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    //void Update()
    //{
    //    Move();
    //    Rotate();
    //}
    private void FixedUpdate()
    {
        // 물리 갱신 주기마다 움직임, 회전, 애니메이션 처리 실행
        Rotate();
        Move();

        var dir = new Vector3(playerInput.moveH, 0f, playerInput.moveV);
    }
    private void Move()
    {
        var forward = Camera.main.transform.forward;
        forward.y = 0f;
        forward.Normalize();

        var right = Camera.main.transform.right;
        right.y = 0f;
        right.Normalize();

        var dir = forward * playerInput.moveV;
        dir += right * playerInput.moveH;

        if (dir.magnitude > 1f)
        {
            dir.Normalize();
        }

        var delta = dir * moveSpeed * Time.deltaTime;

        playerRigidbody.MovePosition(playerRigidbody.position + delta);

        if (delta!=Vector3.zero)
            playerAnimator.SetBool("Move", true);
        else
            playerAnimator.SetBool("Move", false);
        //if (Input.GetAxisRaw("Vertical") != 0f || Input.GetAxisRaw("Horizontal") != 0f)
        //    playerAnimator.SetBool("Move", true);
        //else
        //    playerAnimator.SetBool("Move", false);

        //if (playerRigidbody.velocity.x == 0f && playerRigidbody.velocity.y == 0f)
        //else
        //    playerAnimator.SetFloat("Move", playerInput.moveV);

    }

    private void Rotate()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(playerInput.mousePos);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Floor")))
        {
            var forward = hit.point - transform.position;
            forward.y = 0f;
            forward.Normalize();

            transform.rotation = Quaternion.LookRotation(forward);
        }
    }
}
