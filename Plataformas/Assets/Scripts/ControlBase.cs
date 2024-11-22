using UnityEngine;

public class ControlBase : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Comprueba si el objeto que entra es el que debe adherirse
        if (collision.gameObject.CompareTag("Player")) // Comprueba que el tag es "Player" 
        {
            // Haz que el objeto que entra sea hijo de este objeto
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Cuando el objeto salga del área, elimina la relación de padre-hijo
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
