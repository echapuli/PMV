using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ControladorPlayer : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public float jumpForce;
    private bool isSuelo=false;
    private Renderer render;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        render= rb.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 origen=new Vector3(transform.position.x, transform.position.y - render.bounds.size.y / 2.0f,0);
        
        //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0); // Mueve el objeto a la derecha o izquierda
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0));
        //if (Input.GetKeyDown(KeyCode.Space) && isSuelo)
        //{
        //    rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        //    isSuelo = false;
        //}
        if (Input.GetKey(KeyCode.Space))
        {
            
            RaycastHit2D hit = Physics2D.Raycast(origen, Vector3.down, 0.01f);
    
            if (hit.collider != null && hit.collider.CompareTag("Suelo"))
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Suelo"))
        //{
        //    isSuelo = true;
        //}
    }
}
