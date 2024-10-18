using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float velocidad = 2;
    Vector3 movimiento;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }
    void Movimiento()
    {
        movimiento = new Vector3(-1,0,0);// dirección del movimiento hacia la izq
        movimiento.Normalize();//normalizamos el vector
        transform.position += movimiento * velocidad * Time.deltaTime;// movemos al enemigo usando un vector por la velocidad y por la escala de tiempo ya que no es un movimiento por físicas
    }
}
