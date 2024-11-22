using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMatching : MonoBehaviour
{
    private GameObject firstObject = null; // Ýlk obje referansý


    private void OnTriggerEnter(Collider other)
    {
        // TypeController kontrolü
        TypeController typeController = other.GetComponent<TypeController>();
        if (typeController == null) return;

        // Ýlk obje henüz atanmadýysa
        if (firstObject == null)
        {
            firstObject = other.gameObject;
            AlignObject(firstObject); // Þekli düzelt
        }
        else
        {
            // Ayný türdeki iki obje mi?
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
        // Dönüþü sýfýrla ve dik hale getir
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

        rb.velocity = Vector3.zero; // Mevcut hýzýný sýfýrla
        rb.angularVelocity = Vector3.zero; // Açýsal hýzýný sýfýrla
        rb.isKinematic = false; // Fizik motoru nesneyi algýlamaya devam etsin
    }

    private void LaunchObject(GameObject obj)
    {
        // Oyun alanýnýn ortasý (örneðin X: 0, Z: 0 gibi)
        Vector3 centerPosition = new Vector3(0, obj.transform.position.y, 0);

        // Fýrlatýlacak nesnenin pozisyonu ile ortasý arasýndaki fark
        Vector3 direction = (centerPosition - obj.transform.position).normalized;

        // Fýrlatma gücü (bu deðeri arttýrarak nesnenin hýzýný artýrabilirsiniz)
        float launchForce = 1000f; // Gücü arttýrabilirsiniz

        // Nesnenin Rigidbody bileþenini alýyoruz
        Rigidbody rb = obj.GetComponent<Rigidbody>();

        // Eðer Rigidbody yoksa ekleyelim
        if (rb == null)
        {
            rb = obj.AddComponent<Rigidbody>();
        }

        // Fýrlatmayý gerçekleþtiriyoruz
        rb.velocity = Vector3.zero; // Mevcut hýzý sýfýrlýyoruz
        rb.angularVelocity = Vector3.zero; // Mevcut açýsal hýzýný sýfýrlýyoruz
        rb.AddForce(direction * launchForce); // Fýrlatma kuvveti ekliyoruz
    }


    private void OnTriggerExit(Collider other)
    {
        // Yerleþtirme alanýndan çýkarsa ilk objeyi sýfýrla
        if (firstObject == other.gameObject)
        {
            firstObject = null;
        }
    }
}
