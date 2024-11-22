using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class ParallaxTransform : MonoBehaviour
{
    public float parallaxVelocidad;
    private Transform camaraTransform;
    private Vector3 posicionPreviaCam;
    private float posicionInicial;
    private float spriteAnchura;
    // Start is called before the first frame update
    void Start()
    {
        camaraTransform = Camera.main.transform;
        posicionPreviaCam = camaraTransform.position;
        posicionInicial = transform.position.x;
        spriteAnchura = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX= (camaraTransform.position.x-posicionPreviaCam.x)* parallaxVelocidad;
        float desplazamiento=camaraTransform.position.x * (1-parallaxVelocidad);
        transform.Translate(new Vector3(deltaX, 0, 0));

        posicionPreviaCam = Camera.main.transform.position;

        if (desplazamiento > posicionInicial + spriteAnchura)
        {
            transform.Translate(new Vector3(spriteAnchura, 0, 0));
            posicionInicial += spriteAnchura;
        }
        if (desplazamiento < posicionInicial - spriteAnchura) {
            transform.Translate(new Vector3(-spriteAnchura, 0, 0));
            posicionInicial -= spriteAnchura;
        }
    }
}
