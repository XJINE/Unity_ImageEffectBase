using UnityEngine;

[ExecuteAlways, RequireComponent(typeof(Camera))]
public class ImageEffectBase : MonoBehaviour
{
    #region Field

    public Material material;

    #endregion Field

    #region Method

    protected virtual void Start()
    {
        enabled = material && material.shader.isSupported;
    }

    protected virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }

    #endregion Method
}