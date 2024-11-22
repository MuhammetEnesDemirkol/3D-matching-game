using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMatching : MonoBehaviour
{
    private GameObject firstObject = null; // �lk obje referans�


    private void OnTriggerEnter(Collider other)
    {
        // TypeController kontrol�
        TypeController typeController = other.GetComponent<TypeController>();
        if (typeController == null) return;

        // �lk obje hen�z atanmad�ysa
        if (firstObject == null)
        {
            firstObject = other.gameObject;
            AlignObject(firstObject); // �ekli d�zelt
        }
        else
        {
            // Ayn� t�rdeki iki obje mi?
            TypeController firstType = firstObject.GetComponent<TypeController>();
            if (firstType != null && firstType.objectType == typeController.objectType)
            {
                Destroy(firstObject);
                Destroy(other.gameObject);


                firstObject = null;
            }
            else
            {
                LaunchObject(other.gameObject);
            }
        }
    }

    private void AlignObject(GameObject obj)
    {
        // D�n��� s�f�rla ve dik hale getir
        obj.transform.rotation = Quaternion.Euler(0, 0, 0);

        // Y�kseklik ayar�
        Vector3 adjustedPosition = obj.transform.position;
        adjustedPosition.y = this.transform.position.y + obj.GetComponent<Renderer>().bounds.extents.y;
        obj.transform.position = adjustedPosition;

        // Rigidbody ayarlar�
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = obj.AddComponent<Rigidbody>();
        }

        rb.velocity = Vector3.zero; // Mevcut h�z�n� s�f�rla
        rb.angularVelocity = Vector3.zero; // A��sal h�z�n� s�f�rla
        rb.isKinematic = false; // Fizik motoru nesneyi alg�lamaya devam etsin
    }

    private void LaunchObject(GameObject obj)
    {
        // Oyun alan�n�n ortas� (�rne�in X: 0, Z: 0 gibi)
        Vector3 centerPosition = new Vector3(0, obj.transform.position.y, 0);

        // F�rlat�lacak nesnenin pozisyonu ile ortas� aras�ndaki fark
        Vector3 direction = (centerPosition - obj.transform.position).normalized;

        // F�rlatma g�c� (bu de�eri artt�rarak nesnenin h�z�n� art�rabilirsiniz)
        float launchForce = 1000f; // G�c� artt�rabilirsiniz

        // Nesnenin Rigidbody bile�enini al�yoruz
        Rigidbody rb = obj.GetComponent<Rigidbody>();

        // E�er Rigidbody yoksa ekleyelim
        if (rb == null)
        {
            rb = obj.AddComponent<Rigidbody>();
        }

        // F�rlatmay� ger�ekle�tiriyoruz
        rb.velocity = Vector3.zero; // Mevcut h�z� s�f�rl�yoruz
        rb.angularVelocity = Vector3.zero; // Mevcut a��sal h�z�n� s�f�rl�yoruz
        rb.AddForce(direction * launchForce); // F�rlatma kuvveti ekliyoruz
    }


    private void OnTriggerExit(Collider other)
    {
        // Yerle�tirme alan�ndan ��karsa ilk objeyi s�f�rla
        if (firstObject == other.gameObject)
        {
            firstObject = null;
        }
    }
}
