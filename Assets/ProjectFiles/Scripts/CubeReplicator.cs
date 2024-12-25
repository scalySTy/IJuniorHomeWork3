using System.Collections.Generic;
using UnityEngine;

public class CubeReplicator : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    
    public List<Cube> Replicate(Cube cube)
    {
        List<Cube> replicatedCubes = new List<Cube>();

        if (cube.CanReplicate())
        {
            int minCubes = 2;
            int maxCubes = 6;
            int numberOfCubes = UnityEngine.Random.Range(minCubes, maxCubes + 1);
        
            Vector3 originalPosition = cube.transform.position;
        
            for (int i = 0; i < numberOfCubes; i++)
            {
                Cube newCube = Instantiate(_cubePrefab, originalPosition, Quaternion.identity);
                newCube.Init(cube.MultiplyChance, cube.transform.localScale);
            
                replicatedCubes.Add(newCube);
            }
        }
        
        return replicatedCubes;
    }
}
