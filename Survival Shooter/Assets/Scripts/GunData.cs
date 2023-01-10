using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/GunData", fileName = "GunData")]
public class GunData : ScriptableObject
{
    public AudioClip shotClip; // �߻� �Ҹ�
    public float damage = 25; // ���ݷ�
    public float fireDistance = 70f; // �����Ÿ�
    public float timeBetFire = 0.04f; // �Ѿ� �߻� ����
}

