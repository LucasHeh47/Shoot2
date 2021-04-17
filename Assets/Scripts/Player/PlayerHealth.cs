using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public static PlayerHealth Instance;
    public float MaxHealth;
    public float MaxShield;
    public float CurrentHealth;
    public float CurrentShield;

    public HealthBarManager bar;

    private float regenDelay = 1;
    private float regenedHealth;
    private float healthRegenRate = 10;
    private float lastDmgTime;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        SetHealth(MaxHealth);
        bar.shieldBar.maxValue = MaxShield;
        bar.SetShieldBar(MaxShield / 2);
    }

    public void SetHealth(float num)
    {
        CurrentHealth = num;
        bar.SetHealthBar(num);
    }

    public void RegenHealth()
    {
        regenedHealth += healthRegenRate * Time.deltaTime;
        int flooredRegenedHealth = Mathf.FloorToInt(regenedHealth);
        regenedHealth -= flooredRegenedHealth;
        Heal(flooredRegenedHealth);
    }

    public void Heal(float num)
    {
        if(CurrentHealth + num >= MaxHealth)
        {
            SetHealth(MaxHealth);
        }
        else
        {
            SetHealth(CurrentHealth + num);
        }
    }

    public void TakeDamage(float num)
    {
        float dmgToDo = num;
        if(bar.shieldBar.value == dmgToDo)
        {
            bar.shieldBar.value = 0;
            return;
        }
        if(bar.shieldBar.value > 0)
        {
            if(dmgToDo > bar.shieldBar.value)
            {
                dmgToDo -= bar.shieldBar.value;
                bar.shieldBar.value = 0;
            }
            else
            {
                bar.shieldBar.value -= dmgToDo;
                return;
            }
        }
        SetHealth(CurrentHealth - dmgToDo);
        regenedHealth = 0;
        lastDmgTime = Time.time;
        if (CurrentHealth <= 0) Die();
    }

    public void Die()
    {
        GlobalManager.Instance.recentScore = PlayerScore.Instance.score;
        if (GlobalManager.Instance.recentScore > GlobalManager.Instance.highScore) GlobalManager.Instance.highScore = GlobalManager.Instance.recentScore;
        GlobalManager.Instance.Currency += PlayerScore.Instance.score / 10;
        GlobalManager.Instance.DownMusic();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (lastDmgTime >= 0 && Time.time - lastDmgTime >= regenDelay)
        {
            RegenHealth();
        }
    }
}
