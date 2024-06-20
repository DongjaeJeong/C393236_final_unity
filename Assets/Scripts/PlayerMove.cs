using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    float timer;

    public GameObject bullet;
    public Scanner scanner;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator ani;

    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
        timer = 0;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rb.MovePosition( rb.position + nextVec );
        if(timer >= 1.0f)
        {
            timer = 0;
            fire();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            ani.SetBool("isDead", true);
        }
    }

    private void LateUpdate()
    {
        ani.SetFloat("Speed", inputVec.magnitude);

        if( inputVec.x != 0 )
        {
            sr.flipX = inputVec.x < 0;
        }
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void fire()
    {
        if (!scanner.nearestTarget) return;
        Instantiate(bullet, this.transform);
    }
}
