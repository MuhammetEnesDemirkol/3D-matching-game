using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Nesne yerle�tirme alan�na girdi�inde Rigidbody'yi devre d��� b�rak
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true; // Fiziksel hareketi devre d��� b�rak
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false; // Fiziksel hareketi geri y�kle
        }
    }

}
