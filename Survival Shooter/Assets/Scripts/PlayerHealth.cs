using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : LivingEntity
{
    public Slider healthSlider; // ü���� ǥ���� UI �����̴�

    public AudioClip deathClip; // ��� �Ҹ�
    public AudioClip hitClip; // �ǰ� �Ҹ�

    private AudioSource playerAudioPlayer; // �÷��̾� �Ҹ� �����
    private Animator playerAnimator; // �÷��̾��� �ִϸ�����

    private PlayerMovement playerMovement; // �÷��̾� ������ ������Ʈ
    private PlayerShooter playerShooter; // �÷��̾� ���� ������Ʈ
    
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
        healthSlider.value = health / health_Max;
        Debug.Log(health);
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

       // Invoke(UIManager.Instance.gameoverUI.SetActive(true),5f);
        
    }
}