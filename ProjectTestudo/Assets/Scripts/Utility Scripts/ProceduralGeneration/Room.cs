using UnityEngine;

public class Room
{
    public Rect roomRect; // Room dimensions

    public Room(Vector3 position, int width, int length, GameObject roomPrefab)
    {
        // Create the room floor (thin cube)
        GameObject roomFloor = Instantiate(roomPrefab, position, Quaternion.identity);
        roomFloor.transform.localScale = new Vector3(width, 0.1f, length); // Thin floor
        roomRect = new Rect(position.x, position.z, width, length); // Set room area
    }
}
