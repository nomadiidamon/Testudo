using UnityEngine;

public class Room
{
    public Rect roomRect; // Room dimensions


    public Room(Vector3 position, int width, int length, GameObject roomFloorPrefab)
    {
        if (position.HasObjectWithLayerInBox(LayerMask.NameToLayer("PG_Floor"), new Vector3(width, 0, length)))
        {
            return;
        }
        GameObject roomFloor = Object.Instantiate(roomFloorPrefab, position, Quaternion.identity);
        roomFloor.transform.localScale = new Vector3(width, roomFloor.transform.localScale.y, length);
        roomRect = new Rect(position.x, position.z, width, length); // Set room area

        roomFloor.layer = LayerMask.NameToLayer("PG_Floor");


    }


}
