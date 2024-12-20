using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField, Range(5, 30)] private float _radius;
    [SerializeField, Range(100, 500)] private float _explosionForce;
    
    public void Explode(Vector3 explosionCenter, List<Rigidbody> explosiveObjects)
    {
        foreach (Rigidbody explosiveObject in explosiveObjects)
        {
            explosiveObject.AddExplosionForce(_explosionForce, explosionCenter, _radius);
        }
    }
}
