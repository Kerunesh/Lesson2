using System.Collections;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    [Header("��������� ������")]
    [SerializeField] private GameObject[] _stonePrefabs;
    [SerializeField] private float _spawnInterval = 2f;

    // ������ �� ���������, ������� ���������� ���� ���� ������.
    private BoxCollider _spawnArea;

    void Start()
    {
        // ��� ������ �� ������� ��������� BoxCollider �� ���� �� �������.
        _spawnArea = GetComponent<BoxCollider>();

        StartCoroutine(SpawnStonesRoutine());
    }

    private IEnumerator SpawnStonesRoutine()
    {
        while (true)
        {
            
            var bounds = _spawnArea.bounds;
            float minX = bounds.min.x; 
            float maxX = bounds.max.x; 

            
            float randomX = Random.Range(minX, maxX);

            
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);

            

            
            int randomIndex = Random.Range(0, _stonePrefabs.Length);
            GameObject randomStonePrefab = _stonePrefabs[randomIndex];

            
            Instantiate(randomStonePrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}