using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM : MonoBehaviour
{
    public float Ps = 5;
    private float hDir;
    [SerializeField] private LayerMask Base;
    public float jumpVelocity = 9f;
    private Rigidbody2D _rigidBody2D;
    private CapsuleCollider2D circleC2D;
    void Awake()
    {
        _rigidBody2D = transform.GetComponent<Rigidbody2D>();
        circleC2D = transform.GetComponent<CapsuleCollider2D>();
    }
    void Update()
    {
        hDir = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(hDir, 0, 0) * Time.deltaTime * Ps;

        Vector3 chScale = transform.localScale;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            chScale.x = -1f;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            chScale.x = 1f;
        }
        transform.localScale = chScale;

        if (isGround() && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody2D.velocity = Vector2.up * jumpVelocity;
        }
    }
    private bool isGround()
    {
        RaycastHit2D rayC2D = Physics2D.BoxCast(circleC2D.bounds.center, circleC2D.bounds.size, 0f, Vector2.down, .1f, Base);

        return rayC2D.collider != null;
    }
}