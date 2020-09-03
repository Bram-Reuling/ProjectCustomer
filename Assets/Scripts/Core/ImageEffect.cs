using UnityEngine;

namespace ProjectCustomer.Core
{
    [ExecuteInEditMode]
    public class ImageEffect : MonoBehaviour
    {
        public Material material;
        private Camera mainCamera;

        private void Awake()
        {
            mainCamera = Camera.main;

            if (mainCamera != null) mainCamera.depthTextureMode = DepthTextureMode.Depth;
        }

        private void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            Graphics.Blit(src, dest, material);
        }
    }
}
