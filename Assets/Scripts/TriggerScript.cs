using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            // Destroy(other.gameObject, 3f);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
           // other.transform.position = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            other.transform.localScale = Vector3.Lerp( other.transform.localScale, new Vector3(0.1f, 0.1f, 0.1f), 2* Time.deltaTime);
        }
    }
}
