using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMatching : MonoBehaviour
{
    private GameObject firstObject = null; // Ýlk obje referansý

    private void OnTriggerEnter(Collider other)
    {
        // TypeController kontrolü (nesnenin objectType'ýný anlayabilmek için)
        TypeController typeController = other.GetComponent<TypeController>();
        if (typeController == null) return;

        // Eðer ilk obje henüz seçilmemiþse
        if (firstObject == null)
        {
            firstObject = other.gameObject;
            AlignObject(firstObject);
        }
        else
        {
            // Ýkinci obje türü
            TypeController firstType = firstObject.GetComponent<TypeController>();
            if (firstType != null && firstType.objectType == typeController.objectType)
            {
                // Ayný tür => iki objeyi yok et
                Destroy(firstObject);
                Destroy(other.gameObject);

                // Toplam nesne sayýsýný 2 düþür (oyun yeniden baþlamasý için)
                GameManager.Instance.OnObjectsDestroyed(2);

                // Skoru +10 artýr
                GameManager.Instance.AddScore(10);

                // Eþleþtirme sýfýrlansýn
                firstObject = null;
            }
            else
            {
                // Farklý tür => fýrlatma
                LaunchObject(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Yerleþtirme alanýndan çýkan obje, ilk objemiz ise sýfýrla
        if (firstObject == other.gameObject)
        {
            firstObject = null;
        }
    }

    private void AlignObject(GameObject obj)
    {
        // Dönüþü sýfýrla
        obj.transform.rotation = Quaternion.Euler(0, 0, 0);

        // Yükseklik ayarý
        Vector3 adjustedPosition = obj.transform.position;
        adjustedPosition.y = this.transform.position.y + obj.GetComponent<Renderer>().bounds.extents.y;
        obj.transform.position = adjustedPosition;

        // Rigidbody ayarlarý
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
        // Oyun alanýnýn ortasý (X=0, Z=0) olarak kabul ediliyor
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
