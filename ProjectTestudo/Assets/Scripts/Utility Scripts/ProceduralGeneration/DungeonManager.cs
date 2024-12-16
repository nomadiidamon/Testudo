using System;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public static DungeonManager Instance { get; private set; } // Singleton instance

    [Header("World Parameters")]
    public int minWorldWidth = 50;
    public int maxWorldWidth = 100;
    public int minWorldLength = 50;
    public int maxWorldLength = 100;
    public int minWorldHeight = 1;
    public int maxWorldHeight = 3;

    [Header("Room Parameters")]
    public int minRoomWidth = 5;
    public int maxRoomWidth = 15;
    public int minRoomHeight = 5;
    public int maxRoomHeight = 15;
    public int minRoomLength = 5;
    public int maxRoomLength = 15;
    public int minNumberOfRooms = 3;
    public int maxNumberOfRooms = 10;

    [Header("Corridor Parameters")]
    public int minCorridorWidth = 3;
    public int maxCorridorWidth = 5;
    public int minCorridorHeight = 3;
    public int maxCorridorHeight = 5;
    public int minNumberOfCorridors = 2;
    public int maxNumberOfCorridors = 5;

    [Header("Prefabs")]
    public GameObject roomPrefab; // Room floor prefab (thin cube)
    public GameObject corridorWallPrefab; // Corridor wall prefab (plane)
    public GameObject corridorFloorPrefab; // Corridor floor prefab (thin cube)

    [Header("Collections")]
    private List<Room> rooms = new List<Room>();
    private List<Corridor> corridors = new List<Corridor>();

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
    }

    public void GenerateDungeon()
    {
        int worldWidth = Random.Range(minWorldWidth, maxWorldWidth);
        int worldLength = Random.Range(minWorldLength, maxWorldLength);
        int worldHeight = Random.Range(minWorldHeight, maxWorldHeight);

        Vector3 worldSize = new Vector3(worldWidth, worldHeight, worldLength);

        int numberOfRooms = Random.Range(minNumberOfRooms, maxNumberOfRooms);
        for (int i = 0; i < numberOfRooms; i++)
        {
            GenerateRoom(worldSize);
        }

        int numberOfCorridors = Random.Range(minNumberOfCorridors, maxNumberOfCorridors);
        for (int i = 0; i < numberOfCorridors; i++)
        {
            GenerateCorridor(worldSize);
        }
    }

    void GenerateRoom(Vector3 worldSize)
    {
        Room room = RoomFactory.CreateRoom(worldSize, minRoomWidth, maxRoomWidth, minRoomHeight, maxRoomHeight, minRoomLength, maxRoomLength);
        if (room != null)
        {
            rooms.Add(room);
        }
    }

    void GenerateCorridor(Vector3 worldSize)
    {
        Corridor corridor = CorridorFactory.CreateCorridor(worldSize, minCorridorWidth, maxCorridorWidth, minCorridorHeight, maxCorridorHeight);
        if (corridor != null)
        {
            corridors.Add(corridor);
        }
    }
}

