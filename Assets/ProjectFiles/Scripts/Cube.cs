using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private CubeReplicator _replicator;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private ColorChanger _colorChanger;
    
    public float MultiplyChance { get; private set; }
    
    private void Awake()
    {
        MultiplyChance = 1f;
        
        _colorChanger.ChangeColor();
    }
    
    public void Init(float parentCubeMultiplyChance)
    {
        float reduceCoefficient = 2f;
        
        MultiplyChance = parentCubeMultiplyChance / reduceCoefficient;
        
        Vector3 newScale = transform.localScale / reduceCoefficient;
        transform.localScale = newScale;
    }
    
    public void ReplicateAndExplode()
    {
        if (MultiplyChance >= UnityEngine.Random.value)
        {
            List<Cube> cubes = _replicator.Replicate(this);
            List<Rigidbody> explosiveObjects = new List<Rigidbody>();

            foreach (Cube cube in cubes)
            {
                if (cube.TryGetComponent(out Rigidbody cubeRigidbody))
                {
                    explosiveObjects.Add(cubeRigidbody);
                }
            }
        
            Vector3 explosionCenter = transform.position;
            _exploder.Explode(explosionCenter, explosiveObjects);
        
            Destroy(this.gameObject);
        }
    }
}
