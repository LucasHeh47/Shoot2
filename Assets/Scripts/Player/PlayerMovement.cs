using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement Instance;

    private int JumpCount;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            transform.position = new Vector3(transform.position.x - PlayerManager.Instance.MovementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (Input.GetKey("d"))
        {
            transform.position = new Vector3(transform.position.x + PlayerManager.Instance.MovementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Space) && JumpCount > 0)
        {
            rb.velocity = new Vector2(0, 0);
            rb.velocity = Vector2.up * PlayerManager.Instance.JumpForce;
            JumpCount--;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Platform")) JumpCount = PlayerManager.Instance.MaxJumpCount;
    }

}
