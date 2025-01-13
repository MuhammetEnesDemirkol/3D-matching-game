using UnityEngine;

public class ObjectBoundaryController : MonoBehaviour
{
    // GroundPlane sýnýrlarýný belirlemek için deðiþkenler (X ve Z)
    private float minX = -9.45f;  // X yönündeki minimum sýnýr
    private float maxX = 9.45f;   // X yönündeki maksimum sýnýr
    private float minZ = -24f;   // Z yönündeki minimum sýnýr
    private float maxZ = 4f;       // Z yönündeki maksimum sýnýr


    void Update()
    {
        // Nesnenin mevcut konumunu al
        Vector3 currentPosition = transform.position;

        // X eksenindeki sýnýr kontrolü
        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);

        // Z eksenindeki sýnýr kontrolü
        currentPosition.z = Mathf.Clamp(currentPosition.z, minZ, maxZ);

        // Eðer Y eksenini de sýnýrlamak isterseniz:
        // currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);

        // Düzeltilmiþ pozisyonu uygula
        transform.position = currentPosition;
    }
}
