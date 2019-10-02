using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Base : MonoBehaviour
{
    const string SHADER_NAME = "Custom/Base";

    [SerializeField]
    private Shader _shader;
    public Shader shader 
    {
        get 
        {
            if (this._shader == null) {
                this._shader = Shader.Find(SHADER_NAME);
            }
            return this._shader;
        }
    }

    private Material _material;
    private Material material {
        get 
        {
            if (this._material == null) 
            {
                this._material = new Material(shader);
            }
            return this._material;
        }
    }

    private void OnDisable() 
    {
        if (this._material != null) 
        {
            DestroyImmediate(this._material);
        }
        this._material = null;
    }

    private void Awake() 
    {
        // set any parameter   
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, material);
    }
}
