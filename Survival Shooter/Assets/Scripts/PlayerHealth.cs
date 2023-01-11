using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerHealth : LivingEntity, IEnumerator
{
    public Slider healthSlider; // ü���� ǥ���� UI �����̴�

    public AudioClip deathClip; // ��� �Ҹ�
    public AudioClip hitClip; // �ǰ� �Ҹ�

    public GameObject hitEffect;
    public GameObject Gameovertext;


    private AudioSource playerAudioPlayer; // �÷��̾� �Ҹ� �����
    private Animator playerAnimator; // �÷��̾��� �ִϸ�����

    private PlayerMovement playerMovement; // �÷��̾� ������ ������Ʈ
    private PlayerShooter playerShooter; // �÷��̾� ���� ������Ʈ

    public object Current => throw new System.NotImplementedException();

    private void Awake()
    {
        // ����� ������Ʈ�� ��������
        playerAudioPlayer = GetComponent<AudioSource>();
        playerAnimator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooter = GetComponent<PlayerShooter>();
    }

    protected override void OnEnable()
    {
        // LivingEntity�� OnEnable() ���� (���� �ʱ�ȭ)
        base.OnEnable();
        healthSlider.gameObject.SetActive(true);
        healthSlider.value = health / health_Max;

        playerMovement.enabled = true;
        playerShooter.enabled = true;


    }

    // ������ ó��
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
    // ��� ó��
    public override void Die()
    {
        // LivingEntity�� Die() ����(��� ����)
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