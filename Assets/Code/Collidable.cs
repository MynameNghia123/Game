using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter2D;
    public BoxCollider2D boxCollider;
    public List<Collider2D> hits = new List<Collider2D>();

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        boxCollider.OverlapCollider(filter2D, hits);
        for (int i = 0; i < hits.Count; i++)
        {
            if (hits[i] == null) continue;
            OnCollide(hits[i]);
            hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D other)
    {
        Debug.Log(other.name);
        
    }
}
