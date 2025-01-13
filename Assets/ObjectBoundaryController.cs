using UnityEngine;

public class ObjectBoundaryController : MonoBehaviour
{
    // GroundPlane s�n�rlar�n� belirlemek i�in de�i�kenler (X ve Z)
    private float minX = -9.45f;  // X y�n�ndeki minimum s�n�r
    private float maxX = 9.45f;   // X y�n�ndeki maksimum s�n�r
    private float minZ = -24f;   // Z y�n�ndeki minimum s�n�r
    private float maxZ = 4f;       // Z y�n�ndeki maksimum s�n�r


    void Update()
    {
        // Nesnenin mevcut konumunu al
        Vector3 currentPosition = transform.position;

        // X eksenindeki s�n�r kontrol�
        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);

        // Z eksenindeki s�n�r kontrol�
        currentPosition.z = Mathf.Clamp(currentPosition.z, minZ, maxZ);

        // E�er Y eksenini de s�n�rlamak isterseniz:
        // currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);

        // D�zeltilmi� pozisyonu uygula
        transform.position = currentPosition;
    }
}
