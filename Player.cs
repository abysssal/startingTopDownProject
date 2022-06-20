using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpTime;

    public Rigidbody2D rb;

    public Camera cam;

    public Vector2 mousePos;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Move(1, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Move(-1, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Move(0, -1);
        }

        if (Input.GetKey(KeyCode.W))
        {
            Move(0, 1);
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void Move(int amountX, int amountY)
    {
        rb.AddForce(new Vector2(speed * Time.deltaTime * amountX, speed * Time.deltaTime * amountY), ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
