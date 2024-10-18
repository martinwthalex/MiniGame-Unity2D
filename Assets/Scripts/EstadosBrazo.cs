using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EstadosBrazo : MonoBehaviour
{
    int estados;// estado del brazo
    Vector3 movimiento;//direccion del brazo
    int monedas = 0;
    float velocidad = 12;// velocidad del brazo
    public TMP_Text textoMonedas;
    public TMP_Text textoVictoria;
    // Start is called before the first frame update
    void Start()
    {
        estados = 0;
        textoVictoria.text = "";// el texto de victoria tiene que estar vacío hasta que se termine el juego
    }

    // Update is called once per frame
    void Update()
    {
        Estados();// comprobar constantemente en que estado está el brazo
        TextoMonedas();// mantener el HUD actualizado
    }
    void Estados()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estados == 0)
        {
            estados = 1;
        }
        if(estados == 1)// el brazo se mueve hacia delante
        {
            movimiento = new Vector3(1, 0, 0);// dirección derecha
            movimiento.Normalize();
            transform.position += movimiento * velocidad * Time.deltaTime;// el brazo se mueve a velocidad indicada
            if (transform.position.x >= transform.parent.position.x + 6f)// si se pasa 6f del objeto parent entra en el estado 2
            {
                estados = 2;
            }
        }
        if(estados == 2)// el brazo vuelve hacia atrás
        {
            movimiento = new Vector3(-1, 0, 0);// dirección izquierda
            movimiento.Normalize();
            transform.position += movimiento * velocidad * Time.deltaTime;
            if (transform.position.x <= transform.parent.position.x - 0.5f)// si se pasa 0.5f del objeto parent vuelve a la posicion del objeto parent
            {
                transform.position = transform.parent.position;
                estados = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Poro"))// si el brazo colisiona con el poro
        {
            Destroy(collision.gameObject);// destruye ese poro
            monedas += 25;
            if(monedas >= 200)// si las monedas superan 200 
            {
                monedas = 200;// las monedas no pueden ser más de 200, para que deja de sumar
                FinDelJuego();// se  llama a la función fin del juego
            }
        }
    }
    void TextoMonedas()
    {
        textoMonedas.text = "MONEDAS: " + monedas.ToString();
    }
    public void FinDelJuego()
    {
        
        Time.timeScale = 0;// se para el juego
        if(monedas == 200) textoVictoria.text = "¡VICTORIA!";// si las monedas son 200 victoria
        else textoVictoria.text = "DERROTA";// sino derrota
        
    }// función que se llama cuando las monedas son 200 desde este script (ontrigger) y desde el script de vida cuando la vida es 0
}
