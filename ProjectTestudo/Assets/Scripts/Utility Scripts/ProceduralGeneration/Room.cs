using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Room : MonoBehaviour
{
    [SerializeField] public BoxCollider roomBounds;
    [SerializeField] public Vector3 center;
    [SerializeField] public GameObject roomFloor;
    [SerializeField] public Wall northWall, eastWall, southWall, westWall;
    public List<Wall> walls = new List<Wall>(); 
    [SerializeField] public Transform Top_Middle, Bottom_Middle, Left_Middle, Right_Middle;
    private int numOfActiveWalls = 4;
    private int numOfWalls = 4;
    public int boundaryWalls = 0;

    public bool IsBoundaryRoom { get; private set; } = false;
    public bool IsNextToBoundaryRoom { get; private set; }


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
        northWall.myNumber = 1;
        eastWall.myNumber = 2;
        southWall.myNumber = 3;
        westWall.myNumber = 4;

       

        // Assigning this room to each of the present room's walls
        // North Wall
        if (northWall != null)
        {
            northWall.myRoom = this;
            walls.Add(northWall);
        }
        else
        {
            Debug.LogError("Room is missing North Wall.");
        }
        //South Wall
        if (southWall != null)
        {

            southWall.myRoom = this;
            walls.Add(southWall);
        }
        else
        {
            Debug.LogError("Room is missing South Wall.");
        }
        //East Wall
        if (eastWall != null)
        {
            eastWall.myRoom = this;
            walls.Add(eastWall);
        }
        else
        {
            Debug.LogError("Room is missing East Wall.");
        }
        //West Wall
        if (westWall != null)
        {
            westWall.myRoom = this;
            walls.Add(westWall);
        }
        else
        {
            Debug.LogError("Room is missing West Wall.");
        }

        // Counts the number of walls that identify as boundaries
        // if that number is greater than zero the room is
        // marked as a boundary room as well
        CountBoundaryWalls();

        

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

    public void DisableWall(int wallID)
    {
        if (wallID == 0)
        {
            northWall.Destroy();
            eastWall.Destroy();
            southWall.Destroy();
            westWall.Destroy();
        }
        else if (wallID == 1)
        {
            northWall.Destroy();
        }
        else if (wallID == 2)
        {
            eastWall.Destroy();
        }
        else if (wallID == 3)
        {
            southWall.Destroy();
        }
        else if (wallID == 4)
        {
            westWall.Destroy();
        }
        else if (wallID == 5)
        {
            northWall.Destroy();
            westWall.Destroy();
        }
        else if (wallID == 6)
        {
            eastWall.Destroy();
            southWall.Destroy();
        }
        else if (wallID == 7)
        {
            southWall.Destroy();
            westWall.Destroy();
        }
        else if (wallID == 8)
        {
            northWall.Destroy();
            eastWall.Destroy();

        }
        else if (wallID == 9)
        {
            eastWall.Destroy();
            westWall.Destroy();
        }
        else if (wallID == 10)
        {
            northWall.Destroy();
            southWall.Destroy();
        }
        else if (wallID == 11)
        {
            northWall.Destroy();
            southWall.Destroy();
            eastWall.Destroy();
        }
        else if (wallID == 12)
        {
            northWall.Destroy();
            southWall.Destroy();
            westWall.Destroy();
        }
        else if (wallID == 13)
        {
            southWall.Destroy();
            eastWall.Destroy();
            westWall.Destroy();
        }
        else if (wallID == 14)
        {
            northWall.Destroy();
            westWall.Destroy();
            eastWall.Destroy();
        }
        else if (wallID == 15)
        {
            if (roomFloor != null)
            {
                roomFloor.gameObject.gameObject.SetActive(false);
            }
        }
        else { return; }
    }
	
    public void CountBoundaryWalls()
    {
        int boundaryWalls = 0;
          
        if (northWall.iAmBoundaryWall)
        {
            boundaryWalls++;
        }

        if (southWall.iAmBoundaryWall)
        {

            boundaryWalls++;

        }

        if (westWall.iAmBoundaryWall)
        {
            boundaryWalls++;
        
        }
        if (eastWall.iAmBoundaryWall)
        {
            boundaryWalls++;
        }

        if (boundaryWalls != 0)
        {
            IsBoundaryRoom = true;
        }

        

    }

    public void RemoveSharedWalls(List<Room> allRooms)
    {
        foreach (Wall wall in walls)
        {
            Collider wallCollider = wall.GetComponent<Collider>();
            if (wallCollider == null)
            {
                Debug.LogWarning($"Wall {wall.name} has no collider. Skipping.");
                continue;
            }

            // Calculate raycast length based on wall dimensions
            float rayLength = wallCollider.bounds.size.z / 2f + 0.1f; // Add a small buffer to ensure overlap detection

            RaycastHit hit;
            if (Physics.Raycast(wall.transform.position, -wall.transform.forward, out hit, rayLength))
            {
                // Check if the ray hit another room
                Room neighboringRoom = hit.transform.GetComponentInParent<Room>();
                if (neighboringRoom != null && neighboringRoom != this)
                {
                    // Remove the wall in both rooms
                    wall.gameObject.SetActive(false);
                    Wall correspondingWall = neighboringRoom.GetWallFacingPosition(wall.transform.position);
                    if (correspondingWall != null)
                    {
                        correspondingWall.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    public Wall GetWallFacingPosition(Vector3 position)
    {
        foreach (Wall wall in walls)
        {
            // Check if the wall faces the given position
            if (Vector3.Dot(wall.transform.forward, position - wall.transform.position) > 0)
            {
                return wall;
            }
        }
        return null;
    }


}
