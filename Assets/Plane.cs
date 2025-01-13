using UnityEngine;

public class Plane : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Nesne bu alana girince kinematik yaparak fizik hareketini durdur
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Alandan çýkýnca yeniden fizik hareketi aktif et
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }
}
