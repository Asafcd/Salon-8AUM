using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public int vidaInicial = 100;
    public int vidaActual;
    public float velDesvanecer = 2.5f;
    private bool isDead = false;
    private bool isDesvanecido = false;
    public int puntosEnemigo;
    void Start()
    {
        vidaActual = vidaInicial;
    }

    void Update()
    {
        if (isDesvanecido)
        {
            transform.Translate(Vector3.up * velDesvanecer * Time.deltaTime);
        }
    }
    public void RecibirDmg(int dmg, Vector3 puntoImpacto)
    {
        if (isDead) {return;}

        vidaActual -= dmg;
        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    public void Morir()
    {
        isDead = true;
        isDesvanecido = true;
        PuntosManager.puntos += puntosEnemigo;
        Destroy(gameObject, 2f);
    }
    
}
