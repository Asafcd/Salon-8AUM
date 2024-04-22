using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    public float timeAttack;
    public int damage;
    private bool playerInRange;
    private float timer;
    private GameObject player;
    private VidaPlayer vidaPlayer;
    private VidaEnemigo vidaEnemigo;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        vidaPlayer = player.GetComponent<VidaPlayer>();
        vidaEnemigo = GetComponent<VidaEnemigo>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    private void Attack()
    {
        timer = 0f;
        if (vidaPlayer.vidaActual > 0)
        {
            vidaPlayer.TakeDamage(damage);
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeAttack && playerInRange && vidaEnemigo.vidaActual > 0)
        {
            Attack();
        }
    }
}
