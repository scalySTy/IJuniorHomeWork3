using System;
using System.Collections.Generic;
using UnityEngine;

public class Replicator : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    
    public List<Cube> Replicate(Cube cube)
    {
        List<Cube> replicatedCubes = new List<Cube>();

        if (cube.MultiplyChance >= UnityEngine.Random.value)
        {
            int minCubes = 2;
            int maxCubes = 6;
            
            int numberOfCubes = UnityEngine.Random.Range(minCubes, maxCubes + 1);
            
            float spawnRadius = 2f;
            
            Vector3 originalPosition = cube.transform.position;
            
            for (int i = 0; i < numberOfCubes; i++)
            {
                float reduceScaleCoefficient = 2f;
                
                Vector3 randomDirection = UnityEngine.Random.onUnitSphere;
                Vector3 spawnPosition = originalPosition + randomDirection * spawnRadius;
                
                Vector3 newScale = cube.transform.localScale / reduceScaleCoefficient;
                
                Cube newCube = Instantiate(_cubePrefab, spawnPosition, Quaternion.identity);
                newCube.transform.localScale = newScale;
                newCube.Init(cube.MultiplyChance);
                
                replicatedCubes.Add(newCube);
            }
        }   
        
        return replicatedCubes;
    }
}
