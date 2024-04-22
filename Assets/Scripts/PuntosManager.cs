using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntosManager : MonoBehaviour
{
    public TextMeshProUGUI puntosText;
    public static int puntos;
    private void Awake() {
        puntos = 0;
        puntosText.text = "Score: " + puntos;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puntosText.text = "Score: " + puntos;
    }
}
