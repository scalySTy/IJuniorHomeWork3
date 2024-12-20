using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Replicator _replicator;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private ColorChanger _colorChanger;
    
    public float MultiplyChance { get; private set; }
    
    public void Init(float parentCubeMultiplyChance)
    {
        float reduceCoefficient = 2f;
        
        MultiplyChance = parentCubeMultiplyChance / reduceCoefficient;
    }
    
    public void ReplicateAndExplode()
    {
        List<Cube> cubes = _replicator.Replicate(this);
        
        _exploder.Explode(this, cubes);
        
        Destroy(this.gameObject);
    }
    
    private void Awake()
    {
        MultiplyChance = 1f;
        
        _colorChanger.ChangeColor();
    }
}
