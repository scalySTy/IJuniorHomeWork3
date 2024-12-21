using UnityEngine;


public class ColorChanger : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    
    public void ChangeColor()
    {
        Color randomColor = Random.ColorHSV();
        _meshRenderer.material.color = randomColor;
    }
}
