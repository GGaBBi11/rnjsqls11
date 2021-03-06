using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class MapSpawner : MonoBehaviour
{
    public static MapSpawner instance;
    public float mapMoveSpeed = 7f;  // 맵의 이동속도
    
    [SerializeField] List<Transform> mapTiles;  // 생성할 맵타일 프리팹 목록
    [SerializeField] Transform map;             // 맵타일의 부모 Transform
    // Linked List : List 의 요소가 다른 요소를 멤버로 가지는 형태의 리스트
    [SerializeField] LinkedList<Transform> spawnedMapTiles = new LinkedList<Transform>(); // 생성된 맵타일 목록
    

    // 첫번째 맵타일을 삭제하고
    // Linked List 의 가장 마지막에 새로 맵타일을 생성한다.
    public static void RemoveFirstAndSpawnNew()
    {
        Destroy(instance.spawnedMapTiles.First().gameObject); // 첫번째 맵타일 GameObject 파괴
        instance.spawnedMapTiles.RemoveFirst(); // 첫번째 맵타일을 리스트에 제거
        instance.SpawnRandomMapTile();  // 랜덤 맵타일 제일 마지막에 생성
    }

    // 싱글톤 + 생성된 맵 리스트에 미리생성된 맵타일들을 추가.
    private void Awake()
    {
        instance = this;
        for (int i = 0; i < map.childCount; i++)
            spawnedMapTiles.AddLast(map.GetChild(i));
    }

    private void FixedUpdate()
    {
        MoveMapTiles();
    }
    
    /// <summary>
    /// 모든 맵타일 이동
    /// </summary>
    private void MoveMapTiles()
    {
        foreach (var maptile in spawnedMapTiles)
            maptile.position += Vector3.back * mapMoveSpeed * Time.fixedDeltaTime;
    }

    /// <summary>
    /// 랜덤한 맵타일을 
    /// 현재 존재하는 맵타일중에 가장 마지막 맵타일의 다음 위치에 생성한다.
    /// 다음 위치 = 가장 마지막 맵타일 위치 + (가장 마지막 맵타일 길이 / 2) + (새로 생성한 맵타일 길이 /2)
    /// </summary>
    private void SpawnRandomMapTile()
    {
        int randomIndex = Random.Range(0, mapTiles.Count);
        Transform lastMapTile = spawnedMapTiles.Last(); // 마지막 맵타일
        float lastMapTileLength = lastMapTile.GetComponent<BoxCollider>().size.z; // 마지막 맵타일 길이
        float currentMapTileLength = mapTiles[randomIndex].GetComponent<BoxCollider>().size.z; // 새로 생성할 맵타일 길이
        Vector3 spawnPos = lastMapTile.position + Vector3.forward * ((lastMapTileLength + currentMapTileLength) / 2);  // 새로 생성할 위치
        Transform spawnedMapTile = Instantiate(mapTiles[randomIndex], 
                                               spawnPos,
                                               Quaternion.identity);
        spawnedMapTiles.AddLast(spawnedMapTile); // 새로 생성한 Linked List 에 등록
    }
}