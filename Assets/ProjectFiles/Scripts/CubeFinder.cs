using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFinder : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _cubeLayerMask;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == false) return;
        
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _cubeLayerMask))
        {
            if (hit.collider.gameObject.TryGetComponent(out Cube cube))
            {
                cube.ReplicateAndExplode();
            }
        }
    }
}
