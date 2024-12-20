using System.Collections.Generic;
using UnityEngine;

public class CubeReplicator : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    
    public List<Cube> Replicate(Cube cube)
    {
        List<Cube> replicatedCubes = new List<Cube>();
    
        int minCubes = 2;
        int maxCubes = 6;
        int numberOfCubes = UnityEngine.Random.Range(minCubes, maxCubes + 1);
        
        float spawnRadius = 2f;
        Vector3 originalPosition = cube.transform.position;
        
        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 randomDirection = UnityEngine.Random.onUnitSphere;
            Vector3 spawnPosition = originalPosition + randomDirection * spawnRadius;
            
            Cube newCube = Instantiate(_cubePrefab, spawnPosition, Quaternion.identity);
            newCube.Init(cube.MultiplyChance);
            
            replicatedCubes.Add(newCube);
        }
        
        return replicatedCubes;
    }
}
