using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [Header("Dikey Offset")]
    [Tooltip("Nesnenin fare imlecinin biraz yukarýsýnda durmasýný saðlar.")]
    public float verticalOffset = 2.0f;

    // Nesnenin kamerayla olan Z uzaklýðýný hatýrlamak için
    private float zCoord;

    // Fare ile nesne arasýndaki konum farký
    private Vector3 offset;

    void OnMouseDown()
    {
        // Nesnenin ekrandaki z mesafesini al
        zCoord = Camera.main.WorldToScreenPoint(transform.position).z;

        // Fare noktasýný dünya koordinatýna çevir
        Vector3 mouseWorldPos = GetMouseAsWorldPoint();

        // Nesneyle fare arasýnda o anki farký al
        offset = transform.position - mouseWorldPos;
    }

    void OnMouseDrag()
    {
        // Fareyi takip eden dünya pozisyonu
        Vector3 mouseWorldPos = GetMouseAsWorldPoint();

        // Yeni hedef konum = fare konumu + offset
        Vector3 desiredPos = mouseWorldPos + offset;

        // Nesneyi dikeyde biraz yukarýda göstermek için verticalOffset
        desiredPos.y += verticalOffset;

        // Nesneyi doðrudan bu konuma yerleþtir
        transform.position = desiredPos;
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Fare ekran pozisyonu
        Vector3 mousePoint = Input.mousePosition;

        // Z deðeri, nesnenin kamera ile olan mevcut mesafesidir
        mousePoint.z = zCoord;

        // Kamera üzerinden 3D dünya konumuna çevir
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
