using UnityEngine;

public class Corridor
{
    public Vector3 startPosition;
    public int width, height, length;

    public Corridor(Vector3 position, int corridorWidth, int corridorHeight, int corridorLength, GameObject corridorWallPrefab, GameObject corridorFloorPrefab)
    {
        startPosition = position;
        width = corridorWidth;
        height = corridorHeight;
        length = corridorLength;

        // Create the corridor floor (thin cube)
        GameObject corridorFloor = Instantiate(corridorFloorPrefab, startPosition, Quaternion.identity);
        corridorFloor.transform.localScale = new Vector3(width, 0.1f, length); // Thin floor

        // Create the walls of the corridor
        CreateCorridorWall(new Vector3(startPosition.x, 0, startPosition.z), width, height, length, "north", corridorWallPrefab);
        CreateCorridorWall(new Vector3(startPosition.x, 0, startPosition.z + length), width, height, length, "south", corridorWallPrefab);
        CreateCorridorWall(new Vector3(startPosition.x, 0, startPosition.z), height, width, length, "west", corridorWallPrefab);
        CreateCorridorWall(new Vector3(startPosition.x + width, 0, startPosition.z), height, width, length, "east", corridorWallPrefab);
    }

    void CreateCorridorWall(Vector3 position, int wallHeight, int wallWidth, int wallLength, string direction, GameObject wallPrefab)
    {
        GameObject wall = Instantiate(wallPrefab, position, Quaternion.identity);
        wall.transform.localScale = new Vector3(wallWidth, wallHeight, wallLength);

        // Rotate wall based on direction
        if (direction == "north" || direction == "south")
        {
            wall.transform.rotation = Quaternion.Euler(0, 0, 0); // Upright position
        }
        else if (direction == "east" || direction == "west")
        {
            wall.transform.rotation = Quaternion.Euler(0, 90, 0); // Rotate for horizontal walls
        }

        // Add a mesh collider for the wall
        MeshCollider collider = wall.AddComponent<MeshCollider>();
        collider.convex = true; // For interaction with other objects
    }
}
