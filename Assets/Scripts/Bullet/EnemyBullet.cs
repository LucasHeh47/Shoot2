using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Platform"))
        {
            Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("Bullet"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("player"))
        {
            PlayerHealth.Instance.TakeDamage(enemy.ProjectileDamage);
            Destroy(gameObject);
        }
    }
}
