using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerHealth : LivingEntity, IEnumerator
{
    public Slider healthSlider; // 체력을 표시할 UI 슬라이더

    public AudioClip deathClip; // 사망 소리
    public AudioClip hitClip; // 피격 소리

    public GameObject hitEffect;
    public GameObject Gameovertext;


    private AudioSource playerAudioPlayer; // 플레이어 소리 재생기
    private Animator playerAnimator; // 플레이어의 애니메이터

    private PlayerMovement playerMovement; // 플레이어 움직임 컴포넌트
    private PlayerShooter playerShooter; // 플레이어 슈터 컴포넌트

    public object Current => throw new System.NotImplementedException();

    private void Awake()
    {
        // 사용할 컴포넌트를 가져오기
        playerAudioPlayer = GetComponent<AudioSource>();
        playerAnimator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooter = GetComponent<PlayerShooter>();
    }

    protected override void OnEnable()
    {
        // LivingEntity의 OnEnable() 실행 (상태 초기화)
        base.OnEnable();
        healthSlider.gameObject.SetActive(true);
        healthSlider.value = health / health_Max;

        playerMovement.enabled = true;
        playerShooter.enabled = true;


    }

    // 데미지 처리
    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitDirection)
    {
        if (dead)
            return;

        playerAudioPlayer.PlayOneShot(hitClip);

        base.OnDamage(damage, hitPoint, hitDirection);
        hitEffect.SetActive(true);

        healthSlider.value = health / health_Max;

        StartCoroutine(Stop());


    }
    public IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.5f);
        hitEffect.SetActive(false);
    }
    public float GetHP()
    {
        return health;
    }
    // 사망 처리
    public override void Die()
    {
        // LivingEntity의 Die() 실행(사망 적용)
        base.Die();

        healthSlider.gameObject.SetActive(false);
        playerAudioPlayer.PlayOneShot(deathClip);

        playerMovement.enabled = false;
        playerShooter.enabled = false;
        playerAnimator.SetTrigger("Die");

        StartCoroutine(StopGameOver());

        // Invoke(UIManager.Instance.gameoverUI.SetActive(true),5f);

    }
    public IEnumerator StopGameOver()
    {
        yield return new WaitForSeconds(6f);
        Gameovertext.SetActive(true);
        GameManager.isGameover = false;
    }
    public bool MoveNext()
    {
        throw new System.NotImplementedException();
    }

    public void Reset()
    {
        throw new System.NotImplementedException();
    }
}