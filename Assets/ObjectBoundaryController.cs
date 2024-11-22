using UnityEngine;

public class ObjectBoundaryController : MonoBehaviour
{
    // GroundPlane sýnýrlarýný belirlemek için deðiþkenler
    private float minX = -12.45f; // X yönündeki minimum sýnýr
    private float maxX = 12.45f;  // X yönündeki maksimum sýnýr
    private float minZ = -24.2f; // Z yönündeki minimum sýnýr
    private float maxZ = 4f;    // Z yönündeki maksimum sýnýr


    void Update()
    {
        // Nesnenin mevcut konumunu
        Vector3 currentPosition = transform.position;

        // X eksenindeki sýnýr kontrolü
        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);

        // Z eksenindeki sýnýr kontrolü
        currentPosition.z = Mathf.Clamp(currentPosition.z, minZ, maxZ);



        // Düzeltilmiþ pozisyonu uygula
        transform.position = currentPosition;
    }
}
