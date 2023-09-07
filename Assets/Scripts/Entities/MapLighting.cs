using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapLighting : MonoBehaviour
{
    private Tilemap tm;

    private void Start()
    {
        tm = GetComponent<Tilemap>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        tm.color = new Color32(147, 147, 147, 0);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        tm.color = new Color32(147, 147, 147, 255);
    }
}
