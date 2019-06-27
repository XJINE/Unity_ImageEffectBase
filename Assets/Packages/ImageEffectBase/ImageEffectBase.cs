using UnityEngine;
using System.Runtime.Serialization;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class ImageEffectBase : MonoBehaviour
{
    #region Field

    [IgnoreDataMember]
    public Material material;

    #endregion Field

    #region Method

    protected virtual void Start()
    {
        if (!this.material
         || !this.material.shader.isSupported)
        {
            base.enabled = false;
        }
    }

    protected virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, this.material);
    }

    #endregion Method
}