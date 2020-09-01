using System;
using UnityEngine;

namespace ProjectCustomer.Core
{
    [ExecuteInEditMode]
    public class ImageEffect : MonoBehaviour
    {
        public Material material;
        Camera camera;

        private void Awake()
        {
            camera = Camera.main;

            if (camera != null) camera.depthTextureMode = DepthTextureMode.Depth;
        }

        private void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            Graphics.Blit(src, dest, material);
        }
    }
}
