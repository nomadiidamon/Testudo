using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public bool isActive = true;
    public bool iAmBoundaryWall = false;
    public List<Collider> myContacts = new List<Collider>();
    public int myNumber = 0;


    public void Start()
    {
    }


    public void SetActive(bool active) { isActive = active; }

    public bool IsBoundary()
    {
        BoxCollider coll = GetComponent<BoxCollider>();
        int layer = LayerMask.NameToLayer("PG_Wall");

        if (coll != null)
        {
            Collider[] colliders = Physics.OverlapBox(coll.bounds.center, coll.bounds.extents, Quaternion.identity, 1 << layer);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != coll)
                {
                    myContacts.Add(colliders[i]);
                }
            }

            if (myContacts.Count > 6)
            {
                iAmBoundaryWall = false;
            }
            else
            {
                iAmBoundaryWall = true;
            }
        }
        return iAmBoundaryWall;
    }

    public void Destroy()
    {
        if (!iAmBoundaryWall)
        {
            GridDungeonManager.Instance.walls.Remove(this);
            if (gameObject.activeInHierarchy)
            {
                gameObject.SetActive(false);
            }
            Object.Destroy(this);
        }
    }

}
