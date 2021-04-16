using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public GameObject gun;
    public GameObject renderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 diff = mousePos - (Vector2)transform.position;

        transform.right = diff;

        if (diff.x <= 0)
        {
            gun.GetComponent<SpriteRenderer>().flipY = true;
            renderer.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            gun.GetComponent<SpriteRenderer>().flipY = false;
            renderer.GetComponent<SpriteRenderer>().flipY = false;
        }
    }
}
