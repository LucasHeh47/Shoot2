using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public static PlayerHealth Instance;
    public float MaxHealth;
    public float CurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        SetHealth(MaxHealth);
    }

    public void SetHealth(float num)
    {
        CurrentHealth = num;
        HealthBarManager.Instance.SetHealthBar(num);
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
        SetHealth(CurrentHealth - num);
        if (CurrentHealth <= 0) Die();
    }

    public void Die()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
