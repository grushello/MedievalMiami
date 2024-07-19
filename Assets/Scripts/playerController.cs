using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float playerSpeed;

    public Rigidbody2D rb;
    //public Animator animator;
    public Camera cam;

    public Vector2 movement;
    public Vector2 mousePos;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //get input for moving
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //get mouse pos in relation to camera pos 
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);

        //look towards mouse
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x)* Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }
}
