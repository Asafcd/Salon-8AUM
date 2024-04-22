using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaPlayer : MonoBehaviour
{
    public int vidaInicial = 100;
    public int vidaActual;
    public Slider vidaSlider;
    public GameObject gameOver;
    private PlayerController player;
    private Shoot shoot;
    private bool isDead;
    // private bool dañando;


    void Awake()
    {
        vidaActual = vidaInicial;
        vidaSlider.maxValue = vidaInicial;
        vidaSlider.value = vidaInicial;
        player = GetComponent<PlayerController>();
        shoot = GetComponent<Shoot>();
    }
    void Update()
    {
        
    }
    public void TakeDamage(int dmg)
    {
        // dañando = true;
        vidaActual -= dmg;
        vidaSlider.value = vidaActual;
        if (vidaActual <= 0 && !isDead)
        {
            Death();
        }
    }
    public void Death()
    {
        isDead = true;
        gameOver.SetActive(true);
        player.enabled = false;
        shoot.enabled = false;
        StartCoroutine(ReiniciarNivel());
    }

    IEnumerator ReiniciarNivel()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("SampleScene");
    }
}
