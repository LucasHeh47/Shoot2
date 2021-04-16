using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public Enemy enemy;

    public GameObject HealthBarObj;
    private Slider HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = HealthBarObj.GetComponent<Slider>();
        HealthBar.maxValue = enemy.MaxHealth;
        HealthBar.value = enemy.MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBarObj.transform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z));
    }

    public void TakeDamage(float dmg)
    {
        HealthBar.value -= dmg;
        if(HealthBar.value <= 0)
        {
            Die();
        }
    }

    public void IncreaseMaxHealth()
    {
        enemy.MaxHealth *= enemy.MaxHealthIncrease;
    }

    public void Die()
    {
        PlayParticles();
        PlayerScore.Instance.AddScore(enemy.PointsPerKill);
        Destroy(gameObject);
        EnemyManager.Instance.Kills++;
        CameraEffects.ShakeOnce();
        EnemyManager.Instance.Kills++;
        EnemyManager.Instance.enemiesLeft--;
        EnemyManager.Instance.enemiesOnMap--;
        EnemyManager.Instance.enemiesLeftText.SetText(EnemyManager.Instance.enemiesLeft.ToString());
    }

    public void PlayParticles()
    {
        GetComponent<ParticleSystem>().Play();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(PlayerCombat.Instance.GetDamage(PlayerCombat.Instance.SelectedWeapon));
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("player"))
        {
            PlayParticles();
            PlayerHealth.Instance.TakeDamage(enemy.PhysicalDamage);
            EnemyManager.Instance.enemiesLeft--;
            EnemyManager.Instance.enemiesOnMap--;
            EnemyManager.Instance.enemiesLeftText.SetText(EnemyManager.Instance.enemiesLeft.ToString());
            Destroy(gameObject);
        }

    }

}
