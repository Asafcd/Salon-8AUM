using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    private VidaEnemigo _vidaEnemigo;
    private NavMeshAgent nav;
    private Transform _player;
    private VidaPlayer _vidaPlayer;
    void Start()
    {
        _vidaEnemigo = GetComponent<VidaEnemigo>();
        nav = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _vidaPlayer = _player.GetComponent<VidaPlayer>();
    }

    void Update()
    {
        if (_vidaEnemigo.vidaActual > 0 && _vidaPlayer.vidaActual > 0)
        {
            nav.SetDestination(_player.position);
        } else
        {
            nav.enabled = false;
        }
        
        
    }
}
