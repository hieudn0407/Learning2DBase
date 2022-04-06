using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class HeavyScript : MonoBehaviour
{
    private float speed = 4.0f;
    private Animator am;
    private Rigidbody2D body_2d;
    private bool isJump = false;

    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        body_2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var inputX = Input.GetAxis("Horizontal");

        Walk(inputX);

        if (Input.GetKeyDown("f"))
        {
            am.SetTrigger("Attack");
        }
        else if (Input.GetKeyDown("space") && !isJump)
        {
            isJump = true;
            am.SetBool("Jump", true);
            body_2d.velocity = new Vector2(body_2d.velocity.x, 7.5f);
        }
        else if (body_2d.velocity.y == 0 && isJump)
        {
            isJump = false;
            am.SetBool("Jump", false);
        }
        else if (body_2d.velocity.y > 0 && !isJump)
        {
            isJump = true;
            am.SetBool("Jump", true);
        }
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
        {
            am.SetInteger("Action", (int)Aciton.Walk);
        }
        else
        {
            am.SetInteger("Action", (int)Aciton.Idle);
        }
    }

    private void Walk(float inputX)
    {
        body_2d.velocity = new Vector2(inputX * speed, body_2d.velocity.y);

        if (inputX > 0)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (inputX < 0)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    private enum Aciton
    {
        Idle = 0,
        Walk = 1
    }
}
