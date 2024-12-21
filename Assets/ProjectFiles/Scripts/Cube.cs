using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private CubeReplicator _replicator;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private ColorChanger _colorChanger;
    
    private Rigidbody _rigidbody;
    
    public float MultiplyChance { get; private set; }
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
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

    public void Replicate()
    {
        if (MultiplyChance >= UnityEngine.Random.value)
        {
            List<Cube> replicatedCubes = _replicator.Replicate(this);
            
            Explode(replicatedCubes);

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Explode(List<Cube> replicatedCubes)
    {
        List<Rigidbody> explosiveObjects = replicatedCubes.Select(cube => cube._rigidbody).ToList();
        Vector3 explosionCenter = transform.position;
        
        _exploder.Explode(explosionCenter, explosiveObjects);
    }
}
