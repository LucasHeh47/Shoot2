using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Transform player;

    public Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = PlayerMovement.Instance.transform;

        transform.position += (player.position - transform.position).normalized * enemy.MovementSpeed * Time.deltaTime;
    }
}
