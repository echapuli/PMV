using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class ControllerPlayer : MonoBehaviour
{
    public int speedCorrer;
    public int speedSaltar;
    private Rigidbody2D rigidbody2D;
    private float horizontal;
    private float vertical;

    public float jumpForce = 10f; // Fuerza de salto
    private bool isGrounded = true; // Verifica si está en el suelo

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
        {
            if (horizontal < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
            else transform.rotation = Quaternion.Euler(0, 0, 0);
            rigidbody2D.velocity = new Vector2(horizontal * speedCorrer, rigidbody2D.velocity.y);
        }

        if ((vertical != 0) && isGrounded)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Aplica la fuerza de salto
            isGrounded = false; // Evita saltos en el aire
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Detecta si el jugador toca el suelo
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = true; // Permite saltar de nuevo
        }
    }
}
