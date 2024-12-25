using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Exploder _exploder;
    [SerializeField] private ColorChanger _colorChanger;
    
    public Rigidbody Rigidbody { get; private set; }
    public float MultiplyChance { get; private set; }
    
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        MultiplyChance = 1f;
        
        _colorChanger.ChangeMeshColor();
    }
    
    public void Init(float parentCubeMultiplyChance, Vector3 parentCubeLocalScale)
    {
        float reduceCoefficient = 2f;
        
        MultiplyChance = parentCubeMultiplyChance / reduceCoefficient;
        
        Vector3 newScale = parentCubeLocalScale / reduceCoefficient;
        transform.localScale = newScale;
    }

    public bool CanReplicate()
    {
        return MultiplyChance >= UnityEngine.Random.value;
    }
    
    public void Explode(List<Cube> replicatedCubes)
    {
        List<Rigidbody> explosiveObjects = replicatedCubes.Select(cube => cube.Rigidbody).ToList();
        Vector3 explosionCenter = transform.position;
        
        _exploder.Explode(explosionCenter, explosiveObjects);
    }
}
