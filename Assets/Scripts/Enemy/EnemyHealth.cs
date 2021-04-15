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
        HealthBar.maxValue = enemy.Health;
        HealthBar.value = enemy.Health;
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

    public void Die()
    {
        Destroy(gameObject);
        PlayerHealth.Instance.Heal(enemy.Health / 20);
    }

}
