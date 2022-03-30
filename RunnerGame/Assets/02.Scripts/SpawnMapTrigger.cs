using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMapTrigger : MonoBehaviour
{
    [SerializeField] LayerMask mapSpawnerLayer;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == mapSpawnerLayer)
        {
            MapSpawner.RemoveFirstAndSpawnNew();
        }
    }
}
