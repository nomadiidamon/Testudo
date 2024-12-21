using UnityEngine;
using System.Collections.Generic;

public class Room
{
    public Vector3 north, south, east, west;
    public float raycastLength = 75f;

    public Room(Vector3 position, int width, int length, GameObject roomFloorPrefab)
    {
        if (position.HasObjectWithLayerInBox(LayerMask.NameToLayer("PG_Floor"), new Vector3(width, 0, length)))
        {
            return;
        }

        if (roomFloorPrefab == null)
        {
            Debug.LogError("Room floor prefab is null. Cannot create room.");
            return;
        }
        GameObject roomFloor = Object.Instantiate(roomFloorPrefab, position, Quaternion.identity);
        roomFloor.transform.localScale = new Vector3(width, roomFloor.transform.localScale.y, length);

        roomFloor.layer = LayerMask.NameToLayer("PG_Floor");

        List<Vector3> edges = new List<Vector3>();
        west = new Vector3(position.x - width / 2, 1, position.z); // Left side
        edges.Add(west);
        east = new Vector3(position.x + width / 2, 1, position.z); // Right side
        edges.Add(east);
        north = new Vector3(position.x, 1, position.z + length / 2); // Top side
        edges.Add(north);
        south = new Vector3(position.x, 1, position.z - length / 2); // Bottom side
        edges.Add(south);

        for (int i = 0; i < edges.Count; i++)
        {
            Vector3 direction = (edges[i] - position).normalized;

            if (Physics.Raycast(edges[i], direction, out RaycastHit hit, raycastLength))
            {
                UnityEngine.Debug.Log(hit.collider.gameObject.name);
                return;
            }
        }

    }




}
