using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Room : MonoBehaviour
{
    [SerializeField] public BoxCollider roomBounds;
    [SerializeField] public Vector3 center;
    [SerializeField] public GameObject roomFloor;
    [SerializeField] public Wall northWall, southWall, eastWall, westWall;
    [SerializeField] public Transform Top_Middle, Bottom_Middle, Left_Middle, Right_Middle;
    [SerializeField] public float wallRayDistance = 5f; // Adjustable raycast distance

    public bool IsBoundaryRoom { get; private set; } = false;


    public void Start()
    {
        if (roomFloor == null)
        {
            Debug.LogError("Room floor prefab is null. Cannot create room.");
            return;
        }
        
        roomBounds = GetComponent<BoxCollider>();
        if (roomBounds == null)
        {
            Debug.LogError("BoxCollider is missing on the Room GameObject.");
            return;
        }
        center = roomBounds.center;
        //CheckBoundaryWalls();
    }

    public Room(Vector3 position, int width, int height, int length, GameObject roomPrefab)
    {
        GameObject roomObject = Object.Instantiate(roomPrefab, position, Quaternion.identity);
        Room room = roomObject.GetComponent<Room>();
        room.roomBounds.size = new Vector3(width, height, length);
    }



    /// <summary>
    /// Sets up the room dimensions and other properties.
    /// </summary>
    /// <param name="size">The size of the room.</param>
    public void InitializeRoom(Vector3 size, bool isBoundaryRoom)
    {
        if (roomBounds == null)
        {
            Debug.LogError("BoxCollider is missing on the Room GameObject.");
            return;
        }

        roomBounds.size = size;
        center = roomBounds.center;
        IsBoundaryRoom = isBoundaryRoom;
    }



    /// <summary>
    /// Factory method to create a Room instance.
    /// </summary>
    /// <param name="position">The position of the room.</param>
    /// <param name="size">The size of the room.</param>
    /// <param name="roomPrefab">The room prefab.</param>
    /// <param name="isBoundaryRoom">Indicates if this room is a boundary room.</param>
    /// <returns>A new Room instance.</returns>
    public static Room CreateRoom(Vector3 position, Vector3 size, GameObject roomPrefab, bool isBoundaryRoom)
    {
        if (roomPrefab == null)
        {
            Debug.LogError("Room prefab is null.");
            return null;
        }

        GameObject roomObject = Instantiate(roomPrefab, position, Quaternion.identity);
        Room room = roomObject.GetComponent<Room>();

        if (room == null)
        {
            Debug.LogError("The provided prefab does not have a Room component.");
            Destroy(roomObject);
            return null;
        }

        room.InitializeRoom(size, isBoundaryRoom);
        return room;
    }



    ///// <summary>
    ///// Checks each wall to determine if it is a boundary wall.
    ///// </summary>
    //public void CheckBoundaryWalls()
    //{
    //    if (northWall != null) CheckBoundaryWall(northWall);
    //    if (southWall != null) CheckBoundaryWall(southWall);
    //    if (eastWall != null) CheckBoundaryWall(eastWall);
    //    if (westWall != null) CheckBoundaryWall(westWall);
    //}



    ///// <summary>
    ///// Checks if a specific wall is a boundary wall by performing a raycast.
    ///// </summary>
    ///// <param name="wall">The wall to check.</param>
    //private void CheckBoundaryWall(Wall wall)
    //{

    //    //Use the wall's transform.forward to determine the outward direction
    //    Vector3 rayOrigin = wall.transform.position;
    //    Vector3 rayDirection = Vector3.zero;

    //    if (wall == northWall)
    //    {
    //        rayDirection = wall.transform.forward; // Outward from the north wall
    //    }
    //    else if (wall == southWall)
    //    {
    //        rayDirection = -wall.transform.forward; // Outward from the south wall
    //    }
    //    else if (wall == eastWall)
    //    {
    //        rayDirection = wall.transform.right; // Outward from the east wall
    //    }
    //    else if (wall == westWall)
    //    {
    //        rayDirection = -wall.transform.right; // Outward from the west wall
    //    }
    //    else
    //    {
    //        Debug.LogWarning("Wall is not assigned to any expected variable. Skipping.");
    //        return;
    //    }


    //    // Perform the raycast in the outward direction
    //    if (Physics.Raycast(rayOrigin, rayDirection, out RaycastHit hit, wallRayDistance))
    //    {
    //        Debug.Log($"{wall.name} has a neighbor detected by raycast.");
    //        wall.iAmBoundaryWall = false;
    //    }
    //    else
    //    {
    //        Debug.Log($"{wall.name} does not have a neighbor and is marked as a boundary wall.");
    //        wall.iAmBoundaryWall = true;
    //    }

    //    // Debug ray for visualization in the scene view
    //    Debug.DrawLine(rayOrigin, rayDirection * wallRayDistance, Color.red, 100);


    //}

}
