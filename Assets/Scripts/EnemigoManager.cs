using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoManager : MonoBehaviour
{
    public GameObject enemigo;
    public float spawnTime;
    public Transform spawnPoint;
    private VidaPlayer _vidaPlayer;
    private void Awake() {
        _vidaPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<VidaPlayer>();
    }
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);   
    }

    void Spawn()
    {
        if (_vidaPlayer.vidaActual <= 0) return;
        
        Instantiate(enemigo, spawnPoint.position, spawnPoint.rotation);
    }
    void Update()
    {
        
    }
}
