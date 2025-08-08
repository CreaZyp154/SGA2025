using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FullscreenEffect : ScriptableRendererFeature
{
    class FullscreenPass : ScriptableRenderPass
    {
        private Material material;

        public FullscreenPass(Material mat)
        {
            material = mat;
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            CommandBuffer cmd = CommandBufferPool.Get("Fullscreen Effect");
            cmd.Blit(null, BuiltinRenderTextureType.CameraTarget, material);
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }

    [SerializeField] private Material fullscreenMaterial;
    private FullscreenPass fullscreenPass;

    public override void Create()
    {
        fullscreenPass = new FullscreenPass(fullscreenMaterial);
        fullscreenPass.renderPassEvent = RenderPassEvent.AfterRenderingPostProcessing;
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(fullscreenPass);
    }
}
