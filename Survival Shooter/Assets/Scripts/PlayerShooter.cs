using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Gun gun; // ����� ��
    public Transform gunPivot; // �� ��ġ�� ������

    private PlayerInput playerInput; // �÷��̾��� �Է�
    private Animator playerAnimator; // �ִϸ����� ������Ʈ
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();

        SoundMgr.Instance.effectAudioSources.Add(GetComponent<AudioSource>());
    }
    private void OnEnable()
    {
        gun.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        gun.gameObject.SetActive(false);
    }
    void Update()
    {
        if (playerInput.fire)
        {
            gun.Fire();
        }


    }
}
