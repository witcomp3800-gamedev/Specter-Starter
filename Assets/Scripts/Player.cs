using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveAmount;
    private int health;
    public int MAX_HEALTH;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = MAX_HEALTH;
    }

    public void getMovement()
    {
        // set move amount array (get user input)
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = input.normalized * speed;
    }

    public void move()
    {
        // moves the rigid body
        getMovement();
        rb.MovePosition(rb.position + moveAmount * Time.deltaTime);
    }

    public void takeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            print("GameOver");
        }
    }


}
