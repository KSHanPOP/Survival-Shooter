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
    public State state { get; private set; } // 현재 총의 상태

    public Transform fireTransform; // 총알이 발사될 위치

    public ParticleSystem muzzleFlashEffect; // 총구 화염 효과

    private LineRenderer bulletLineRenderer; // 총알 궤적을 그리기 위한 렌더러

    private AudioSource gunAudioPlayer; // 총 소리 재생기

    private float lastFireTime; // 총을 마지막으로 발사한 시점

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
        // 총 상태 초기화

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

        // 라인 렌더러를 활성화하여 총알 궤적을 그린다
        bulletLineRenderer.SetPosition(0, fireTransform.position);
        bulletLineRenderer.SetPosition(1, hitPosition);
        bulletLineRenderer.enabled = true;

        yield return new WaitForSeconds(0.03f);
        // 라인 렌더러를 비활성화하여 총알 궤적을 지운다
        bulletLineRenderer.enabled = false;
    }
}
