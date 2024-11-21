using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMatching : MonoBehaviour
{
    private GameObject firstObject = null; // �lk obje tan�mlamas�

    private void OnTriggerEnter(Collider other)
    {
        // E�er ilk obje tan�ml� de�ilse, objeyi kaydet
        if (firstObject == null)
        {
            firstObject = other.gameObject;
        }
        else
        {
            // Ayn� t�rdeki iki obje �st �ste b�rak�ld�ysa
            if (firstObject.tag == other.tag)
            {
                // Objeleri yok et ve ilk objeyi s�f�rla
                Destroy(firstObject);
                Destroy(other.gameObject);
                firstObject = null;
            }
            else
            {
                // Farkl� t�rde bir obje b�rak�ld�ysa, sonradan b�rak�lan objeyi f�rlat
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                if (rb == null)
                {
                    rb = other.gameObject.AddComponent<Rigidbody>();
                }
                rb.AddForce(new Vector3(Random.Range(-2, 2), 1, Random.Range(-2, 2)) * 200);

                // �lk objeyi s�f�rlam�yoruz ki di�er objeyi yok edebilirim
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // E�er obje kapaktan ayr�ld�ysa ilk objeyi s�f�rla
        if (firstObject == other.gameObject)
        {
            firstObject = null;
        }
    }
}