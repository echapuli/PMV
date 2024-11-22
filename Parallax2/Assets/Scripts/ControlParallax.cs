using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlParallax : MonoBehaviour
{
    public float parallaxVelocidad;
    private Transform camaraTransform;
    private Vector3 posicionAnteriorcam;
    private float anchuraSprite;
    private float posicionInicial;

    // Start is called before the first frame update
    void Start()
    {
        camaraTransform=Camera.main.transform;
        posicionAnteriorcam=camaraTransform.position;
        anchuraSprite = GetComponent<SpriteRenderer>().bounds.size.x; //tamaño x del sprite
        posicionInicial=transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = (camaraTransform.position.x - posicionAnteriorcam.x) * parallaxVelocidad; //desplazamiento del sprite un % del desplazamiento de la camara
        float desplazamiento = camaraTransform.position.x * (1 - parallaxVelocidad); //parte del Sprite que no avanza (avance de la cámara en Sprite) 

        transform.Translate(new Vector3(deltaX, 0, 0));

        posicionAnteriorcam = Camera.main.transform.position;   

        if (desplazamiento > (posicionInicial+anchuraSprite))
        {
            transform.Translate(new Vector3(anchuraSprite,0,0));
            posicionInicial += anchuraSprite;
        }
        else if (desplazamiento < (posicionInicial - anchuraSprite))
        {
            transform.Translate(new Vector3(-anchuraSprite, 0, 0));
            posicionInicial -= anchuraSprite;
        }


    }
}
