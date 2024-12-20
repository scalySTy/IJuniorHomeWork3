using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChanger : MonoBehaviour
{
    public void ChangeColor()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        
        if (meshRenderer)
        {
            Color randomColor = Random.ColorHSV();
            meshRenderer.material.color = randomColor;
        }
    }
}
