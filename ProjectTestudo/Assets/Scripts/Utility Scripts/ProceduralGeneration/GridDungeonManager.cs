using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridDungeonManager : MonoBehaviour
{
    public static GridDungeonManager Instance { get; private set; } // Singleton instance
    public bool generate = false;
    public bool isFinished = false;


    [Header("Prefabs")]
    public GameObject roomFloorPrefab; 
    [Space(10)]

    [Header("World Parameters")]
    [Range(5, 500)] public int WorldWidth = 100;
    [Space(3)]
    [Range(1, 500)] public int WorldHeight = 5;
    [Space(3)]
    [Range(5, 500)] public int WorldLength = 100;
    [Space(3)]
    public int NumOfRooms = 0;
    [Space(10)]

    [Header("Room Parameters")]
    [Range(1, 50)] public int RoomWidth = 15;
    [Space(3)]
    [Range(1, 50)] public int RoomHeight = 15;
    [Space(3)]
    [Range(1, 50)] public int RoomLength = 15;
    [Space(3)]

    [Header("Room Distance")]
    [Range(0, 5)] public float distanceFactor = 0.5f;

    [Header("Collections")]
    public List<Room> rooms = new List<Room>();
    public List<Corridor> corridors = new List<Corridor>();

    private Vector3 currentWorldSize = Vector3.zero;




    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        NumOfRooms = WorldWidth * WorldLength;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFinished)
        {
            if (rooms.Count >= NumOfRooms)
            {
                isFinished = true;
                return;
            }
            GenerateGridDungeon();

        }
        else
        {
            // 
        }
    }


    public void GenerateGridDungeon()
    {
        GenerateGridOfRooms();
    }

    void GenerateGridRoom(Vector3 worldSize, int width, int height, int length)
    {
        Room room = new Room(worldSize, width, height, length, roomFloorPrefab);
        if (room != null)
        {
            rooms.Add(room);
        }
    }

    void GenerateGridOfRooms()
    {
        currentWorldSize = transform.position;

        for (int h = 0; h < WorldHeight + 1; h++)
        {

            for (int i = 0; i < WorldWidth + 1; i++)
            {

                for (int j = 0; j < WorldLength + 1; j++)
                {
                    GenerateGridRoom(currentWorldSize, RoomWidth, RoomHeight, RoomLength);
                    currentWorldSize = currentWorldSize.Add(z: 1 * distanceFactor);
                }
                currentWorldSize = currentWorldSize.WithZ(transform.position.z);
                currentWorldSize = currentWorldSize.Add(x: 1 * distanceFactor);
            }
            currentWorldSize = currentWorldSize.WithX(transform.position.x);
            currentWorldSize = currentWorldSize.Add(y: 1 * distanceFactor);

        }

        foreach (Room room in rooms)
        {
            if (room.roomFloor != null)
                room.roomFloor.transform.position.Add(y: RoomHeight / 2);
        }
    }
}
