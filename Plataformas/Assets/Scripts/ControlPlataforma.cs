using Unity.VisualScripting;
using UnityEngine;

public class ControlPlataformama : MonoBehaviour
{
    public float velocidadP;  //velocidad de la plataforma
    public float desplazamientoP;  //desplazamiento a cada lado de la plataforma
    private float posicionInicial; //posicion inicial plataforma

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionInicial = transform.position.x;
    }

    private void FixedUpdate()
    {
        // Calcula el nuevo desplazamiento
        float desplazamiento = Mathf.PingPong(Time.time * velocidadP, desplazamientoP);

        // Actualiza la posición del objeto
        transform.position = new Vector3(posicionInicial + desplazamiento, transform.position.y, 0);
    }

}

