using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float suavisado = 5f;
    [SerializeField] private Transform target; // personaje
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate() // para fisicas (rb, transform, vectors) y buenas practicas
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, suavisado * Time.deltaTime);   
    }
}
