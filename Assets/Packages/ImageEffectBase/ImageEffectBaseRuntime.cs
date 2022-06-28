using UnityEngine;

[ExecuteAlways, RequireComponent(typeof(Camera))]
public abstract class ImageEffectBaseRuntime : MonoBehaviour
{
    // WARNING:
    // Shader file must be put in a "Resources" folder.
    // Or, Shader must be set into "Edit/Project Settings/Graphics/GraphicsSettings/Always Included Shaders".
    // If do not, the shader will not be found in build app.

    #region Property

    public Material Material { get; private set; }

    protected abstract string ShaderName { get; }

    #endregion Property

    #region Method

    protected virtual void Awake()
    {
        Material = new Material(Shader.Find(ShaderName));
        enabled = Material && Material.shader.isSupported;
    }

    protected virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, Material);
    }

    #endregion Method
}