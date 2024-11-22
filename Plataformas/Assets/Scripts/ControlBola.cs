using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float velocidad,fuerzaSalto;
    private Rigidbody2D rb;
    private bool estaSuelo=false;
    private Transform movimientoPlataforma;
    private Vector3 offset; // Diferencia entre el objeto y la plataforma

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //// Si el objeto está sobre la plataforma, actualiza su posición relativa
        //if (movimientoPlataforma != null)
        //{
        //    // Calcula la nueva posición manteniendo la distancia inicial
        //    transform.position = movimientoPlataforma.position + offset;
        //}

        if (Input.GetAxis("Horizontal") != 0)
        {
            movimientoPlataforma = null;
            transform.Translate(new Vector3(Input.GetAxis("Horizontal") * velocidad * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.Space)&&estaSuelo)
        {
            movimientoPlataforma = null;
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            estaSuelo = false;
        }
 

    }
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Plataforms"))
    //    {
    //        movimientoPlataforma = collision.gameObject.transform;
    //        offset = transform.position - movimientoPlataforma.position; // Calcula la diferencia inicial
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo")|| collision.gameObject.CompareTag("Plataforms"))
            estaSuelo = true;

    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    movimientoPlataforma = null;
    //}

}
