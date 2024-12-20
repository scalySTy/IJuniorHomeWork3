using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChanger : MonoBehaviour
{
    public void ChangeColor()
    {
        if (TryGetComponent(out MeshRenderer meshRenderer))
        {
            Color randomColor = Random.ColorHSV();
            meshRenderer.material.color = randomColor;
        }
    }
}
