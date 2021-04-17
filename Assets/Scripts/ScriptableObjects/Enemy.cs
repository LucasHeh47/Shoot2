using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public string EnemyName;
    public float Health;
    public float MaxHealth;
    public float DefaultMaxHealth;
    public float MaxHealthIncrease;
    public float MovementSpeed;
    public AudioClip ShootSound;
    public float FireDelay;
    public Sprite ProjectileImage;
    public bool Shoots;
    public float BulletSpeed;
    public float ProjectileDamage;
    public float PhysicalDamage;
    public float ProjectileRange;
    public int StartSpawningRound;
    public int PointsPerKill;
}
