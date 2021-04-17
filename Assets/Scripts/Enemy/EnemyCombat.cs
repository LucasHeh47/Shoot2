using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    public Enemy enemy;
    public GameObject bulletPrefab;

    private float nextTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTime && enemy.Shoots)
        {
            nextTime = Time.time + 1f * enemy.FireDelay / 2;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<EnemyBullet>().enemy = enemy;
            bullet.GetComponent<Rigidbody2D>().velocity = (PlayerMovement.Instance.transform.position - transform.position).normalized * (enemy.BulletSpeed*50) * Time.deltaTime;
            Destroy(bullet, enemy.ProjectileRange);
        }
    }
}
