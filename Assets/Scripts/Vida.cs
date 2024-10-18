using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Vida : MonoBehaviour
{
    int vida = 5;
    public GameObject poro;
    public TMP_Text textoVida;
    public GameObject estadosBrazo;// para poder llamar a la funcion fin del juego del script EstadosBrazo
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextoVida();// mantener el HUD actualizado siempre 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Poro"))// comprobamos si lo que colisiona es el poro
        {
            vida--;
            if(vida <= 0)// condición de que la vida llegue a 0
            {
                vida = 0;// no puede bajar más de 0
                estadosBrazo.GetComponent<EstadosBrazo>().FinDelJuego();// llamamos a la función pública del script EstadosBrazo, por eso hemos creado un objeto del tipo que lo contiene
            }
            Destroy(collision.gameObject);// destruimos el objeto con el que ha colisonado
        }
    }
    void TextoVida()
    {
        textoVida.text = "VIDA: " + vida;
    }
}
