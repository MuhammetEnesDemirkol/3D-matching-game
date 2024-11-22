using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Nesne yerleþtirme alanýna girdiðinde Rigidbody'yi devre dýþý býrak
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true; // Fiziksel hareketi devre dýþý býrak
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false; // Fiziksel hareketi geri yükle
        }
    }

}
