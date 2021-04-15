using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public string EnemyName;
    public float Health;
    public float MovementSpeed;
    public AudioClip ShootSound;
    public float FireDelay;
    public Sprite ProjectileImage;
    public float BulletSpeed;
    public float ProjectileDamage;
    public float PhysicalDamage;
}
