using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/GunData", fileName = "GunData")]
public class GunData : ScriptableObject
{
    public AudioClip shotClip; // 발사 소리
    public float damage = 25; // 공격력
    public float fireDistance = 70f; // 사정거리
    public float timeBetFire = 0.04f; // 총알 발사 간격
}

