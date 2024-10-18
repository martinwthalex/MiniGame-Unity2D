using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public GameObject poros;
    Vector3 posicion;
    float timer = 1;
    bool pausa = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnearPoros();
        ComprobraPausa();
    }
    void SpawnearPoros()
    {
        timer -= Time.deltaTime;// comienza cuanta atr�s
        if(timer <= 0)// llega a 0
        {
            float posY = Random.Range(-0.5f, 3.51f);// calculamos una posicion aleatoria y 
            posicion = new Vector3(11.2f, posY, 0);// la posicion x de momento es fija
            Quaternion rot = Quaternion.Euler(0, 0, 0);// la rotaci�n del Poro es nula
            Instantiate(poros, posicion, rot);// creamos un Poro 
            Instantiate(poros, posicion + new Vector3(1, 0, 0), rot);//creamos otro Poro pero la coordenada x es 1 m�s
            timer = Random.Range(1, 4);// el temporizador se reinicia de forma aleatoria
        }
    }
    void Pausa()
    {
        Time.timeScale = 0f;// se para el juego
    }
    void Reanudar()
    {
        Time.timeScale = 1;// se reanuda el juego
    }
    void ComprobraPausa()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BotonPausa();
        }
    }// si le das al escape se pone la pausa y si le vuelves a dar se reanuda el juego
    // Tambi�n se puede pausar el juego clickeando en el objeto pausa que tiene un bot�n invisible debajo
    public void BotonPausa()
    {
        pausa = !pausa;
        if (pausa) Pausa();
        else if (!pausa) Reanudar();
    }
}
