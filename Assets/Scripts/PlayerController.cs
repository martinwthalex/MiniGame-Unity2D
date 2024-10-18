using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float velocidad = 8;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }
    void Movimiento() //el personaje se mueve usando rb
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);// en el eje x siempre tiene que ser el del personaje
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity += new Vector2(0, velocidad);// aplicamos velocidad al movimiento
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity += new Vector2(0, -velocidad);// negativa porque es hacia abajo
        }
    }
}
