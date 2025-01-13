using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMatching : MonoBehaviour
{
    private GameObject firstObject = null; // �lk obje referans�

    private void OnTriggerEnter(Collider other)
    {
        // TypeController kontrol� (nesnenin objectType'�n� anlayabilmek i�in)
        TypeController typeController = other.GetComponent<TypeController>();
        if (typeController == null) return;

        // E�er ilk obje hen�z se�ilmemi�se
        if (firstObject == null)
        {
            firstObject = other.gameObject;
            AlignObject(firstObject);
        }
        else
        {
            // �kinci obje t�r�
            TypeController firstType = firstObject.GetComponent<TypeController>();
            if (firstType != null && firstType.objectType == typeController.objectType)
            {
                // Ayn� t�r => iki objeyi yok et
                Destroy(firstObject);
                Destroy(other.gameObject);

                // Toplam nesne say�s�n� 2 d���r (oyun yeniden ba�lamas� i�in)
                GameManager.Instance.OnObjectsDestroyed(2);

                // Skoru +10 art�r
                GameManager.Instance.AddScore(10);

                // E�le�tirme s�f�rlans�n
                firstObject = null;
            }
            else
            {
                // Farkl� t�r => f�rlatma
                LaunchObject(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Yerle�tirme alan�ndan ��kan obje, ilk objemiz ise s�f�rla
        if (firstObject == other.gameObject)
        {
            firstObject = null;
        }
    }

    private void AlignObject(GameObject obj)
    {
        // D�n��� s�f�rla
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

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = false;
    }

    private void LaunchObject(GameObject obj)
    {
        // Oyun alan�n�n ortas� (X=0, Z=0) olarak kabul ediliyor
        Vector3 centerPosition = new Vector3(0, obj.transform.position.y, 0);
        Vector3 direction = (centerPosition - obj.transform.position).normalized;

        float launchForce = 1000f;

        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = obj.AddComponent<Rigidbody>();
        }

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(direction * launchForce);
    }
}
