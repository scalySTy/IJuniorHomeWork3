using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField, Range(5, 30)] private float _radius;
    [SerializeField, Range(100, 500)] private float _explosionForce;
    
    public void Explode(Cube parentCube, List<Cube> cubes)
    {
        Vector3 explosionCenter = parentCube.transform.position;
        
        foreach (Cube cube in cubes)
        {
            cube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, explosionCenter, _radius);
        }
    }
}
