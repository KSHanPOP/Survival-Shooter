using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Gun gun; // 사용할 총
    public Transform gunPivot; // 총 배치의 기준점

    private PlayerInput playerInput; // 플레이어의 입력
    private Animator playerAnimator; // 애니메이터 컴포넌트
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
