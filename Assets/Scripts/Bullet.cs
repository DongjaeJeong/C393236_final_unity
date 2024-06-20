using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float speed;
    Vector3 dir;
    Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 targetPos = GameManager.Instance.player.scanner.nearestTarget.position;
        dir = targetPos - transform.position;
        dir = dir.normalized;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
    }

    public void Update()
    {
        Vector2 nextVec = dir * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVec);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Area"))
        {
            Destroy(this);
        }
    }
}
