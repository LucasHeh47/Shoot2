using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public static PlayerHealth Instance;

    public int CurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        SetHealth(PlayerManager.Instance.MaxHealth);
    }

    public void SetHealth(int num)
    {
        CurrentHealth = num;
        HealthBarManager.Instance.SetHealthBar(num);
    }

    public void TakeDamage(int num)
    {
        SetHealth(CurrentHealth - num);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
