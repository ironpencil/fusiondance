using UnityEngine;
using System.Collections;

public class TopDown2DController : BaseMovement {

    Rigidbody2D rb;
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();               
	}

    public override void Move()
    {
        if (!disabled)
        {
            Vector2 velocity = movementDirection.normalized * speed;

            rb.velocity = velocity;
        }
    }

    void FixedUpdate()
    {
        if (moveDuringUpdate)
        {
            Move();
        }
    }
}
