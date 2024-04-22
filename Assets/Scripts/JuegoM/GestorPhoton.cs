using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GestorPhoton : MonoBehaviour
{
    public void InvokePlayer()
    {
        PhotonNetwork.Instantiate("Personaje", new Vector3(Random.Range(-7,7), 1.14f, 0), Quaternion.identity);
    }
}
