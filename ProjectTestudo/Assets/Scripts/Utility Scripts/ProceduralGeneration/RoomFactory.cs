using UnityEngine;

public static class RoomFactory
{
    public static Room CreateRoom(Vector3 worldSize, int minWidth, int maxWidth, int minHeight, int maxHeight, int minLength, int maxLength)
    {
        int width = Random.Range(minWidth, maxWidth);
        int length = Random.Range(minLength, maxLength);
        int height = Random.Range(minHeight, maxHeight);

        // Calculate a random position within the world size
        int xPos = Random.Range(0, (int)(worldSize.x - width));
        int zPos = Random.Range(0, (int)(worldSize.z - length));
        Vector3 position = new Vector3(xPos, 0, zPos);

        // Create the room and return it
        return new Room(position, width, length, DungeonManager.Instance.roomPrefab);
    }
}

