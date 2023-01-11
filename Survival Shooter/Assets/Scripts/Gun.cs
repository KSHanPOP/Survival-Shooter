using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum State
    {
        Ready,
    }
    public GunData gunData;
    public State state { get; private set; } // ���� ���� ����

    public Transform fireTransform; // �Ѿ��� �߻�� ��ġ

    public ParticleSystem muzzleFlashEffect; // �ѱ� ȭ�� ȿ��

    private LineRenderer bulletLineRenderer; // �Ѿ� ������ �׸��� ���� ������

    private AudioSource gunAudioPlayer; // �� �Ҹ� �����

    private float lastFireTime; // ���� ���������� �߻��� ����

    private void Awake()
    {
        gunAudioPlayer = GetComponent<AudioSource>();

        bulletLineRenderer = GetComponentInChildren<LineRenderer>();
        bulletLineRenderer.positionCount = 2;
        bulletLineRenderer.enabled = false;

        SoundMgr.Instance.effectAudioSources.Add(GetComponent<AudioSource>());

    }

    private void OnEnable()
    {
        // �� ���� �ʱ�ȭ

        state = State.Ready;
        lastFireTime = 0f;
    }

    public void Fire()
    {
        if (state == State.Ready && Time.time - lastFireTime > gunData.timeBetFire)
        {
            lastFireTime = Time.time;
            Shot();
        }
    }

    private void Shot()
    {
        RaycastHit hit;
        var hitPos = Vector3.zero;
        var ray = new Ray(fireTransform.position, fireTransform.forward);

        if (Physics.Raycast(ray, out hit, gunData.fireDistance))
        {
            hitPos = hit.point;
            var target = hit.collider.GetComponent<IDamageable>();
            if (target != null)
            {                
                target.OnDamage(gunData.damage, hitPos, hit.normal);
            }
        }
        else
        {
            hitPos = fireTransform.position + fireTransform.forward * gunData.fireDistance;
        }
        StartCoroutine(ShotEffect(hitPos));
    }

    private IEnumerator ShotEffect(Vector3 hitPosition)
    {
        muzzleFlashEffect.Play();

        gunAudioPlayer.PlayOneShot(gunData.shotClip);

        // ���� �������� Ȱ��ȭ�Ͽ� �Ѿ� ������ �׸���
        bulletLineRenderer.SetPosition(0, fireTransform.position);
        bulletLineRenderer.SetPosition(1, hitPosition);
        bulletLineRenderer.enabled = true;

        yield return new WaitForSeconds(0.03f);
        // ���� �������� ��Ȱ��ȭ�Ͽ� �Ѿ� ������ �����
        bulletLineRenderer.enabled = false;
    }
}
