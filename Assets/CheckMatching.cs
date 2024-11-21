using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMatching : MonoBehaviour
{
    private GameObject firstObject = null; // Ýlk obje tanýmlamasý

    private void OnTriggerEnter(Collider other)
    {
        // Eðer ilk obje tanýmlý deðilse, objeyi kaydet
        if (firstObject == null)
        {
            firstObject = other.gameObject;
        }
        else
        {
            // Ayný türdeki iki obje üst üste býrakýldýysa
            if (firstObject.tag == other.tag)
            {
                // Objeleri yok et ve ilk objeyi sýfýrla
                Destroy(firstObject);
                Destroy(other.gameObject);
                firstObject = null;
            }
            else
            {
                // Farklý türde bir obje býrakýldýysa, sonradan býrakýlan objeyi fýrlat
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                if (rb == null)
                {
                    rb = other.gameObject.AddComponent<Rigidbody>();
                }
                rb.AddForce(new Vector3(Random.Range(-2, 2), 1, Random.Range(-2, 2)) * 200);

                // Ýlk objeyi sýfýrlamýyoruz ki diðer objeyi yok edebilirim
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Eðer obje kapaktan ayrýldýysa ilk objeyi sýfýrla
        if (firstObject == other.gameObject)
        {
            firstObject = null;
        }
    }
}