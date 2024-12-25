using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFinder : MonoBehaviour
{
    private const int MouseClickNumber = 0;
    
    [SerializeField] private CubeReplicator _replicator;
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _cubeLayerMask;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(MouseClickNumber) == false) 
            return;
        
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _cubeLayerMask))
        {
            if (hit.collider.gameObject.TryGetComponent(out Cube cube))
            {
                List<Cube> replicatedCubes = _replicator.Replicate(cube);
                
                cube.Explode(replicatedCubes);
                
                Destroy(cube.gameObject);
            }
        }
    }
}
