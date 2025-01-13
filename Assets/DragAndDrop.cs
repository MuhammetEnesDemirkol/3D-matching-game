using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [Header("Dikey Offset")]
    [Tooltip("Nesnenin fare imlecinin biraz yukar�s�nda durmas�n� sa�lar.")]
    public float verticalOffset = 2.0f;

    // Nesnenin kamerayla olan Z uzakl���n� hat�rlamak i�in
    private float zCoord;

    // Fare ile nesne aras�ndaki konum fark�
    private Vector3 offset;

    void OnMouseDown()
    {
        // Nesnenin ekrandaki z mesafesini al
        zCoord = Camera.main.WorldToScreenPoint(transform.position).z;

        // Fare noktas�n� d�nya koordinat�na �evir
        Vector3 mouseWorldPos = GetMouseAsWorldPoint();

        // Nesneyle fare aras�nda o anki fark� al
        offset = transform.position - mouseWorldPos;
    }

    void OnMouseDrag()
    {
        // Fareyi takip eden d�nya pozisyonu
        Vector3 mouseWorldPos = GetMouseAsWorldPoint();

        // Yeni hedef konum = fare konumu + offset
        Vector3 desiredPos = mouseWorldPos + offset;

        // Nesneyi dikeyde biraz yukar�da g�stermek i�in verticalOffset
        desiredPos.y += verticalOffset;

        // Nesneyi do�rudan bu konuma yerle�tir
        transform.position = desiredPos;
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Fare ekran pozisyonu
        Vector3 mousePoint = Input.mousePosition;

        // Z de�eri, nesnenin kamera ile olan mevcut mesafesidir
        mousePoint.z = zCoord;

        // Kamera �zerinden 3D d�nya konumuna �evir
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
