using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BaseHSV : MonoBehaviour
{
    const string SHADER_NAME = "Custom/BaseHSV";

    [Range(0, 360)]
    public float hue = 0;

    [Range(0, 1)]
    public float sat = 1;

    [Range(0, 1)]
    public float val = 1;

    int idHue = -1;
    int idSat = -1;
    int idVal = -1;

    [SerializeField]
    private Shader _shader;
    public Shader shader
    {
        get
        {
            if (this._shader == null)
            {
                this._shader = Shader.Find(SHADER_NAME);
            }
            return this._shader;
        }
    }

    private Material _material;
    private Material material
    {
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
        this.idHue = Shader.PropertyToID("_Hue");
        this.idSat = Shader.PropertyToID("_Sat");
        this.idVal = Shader.PropertyToID("_Val");
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        material.SetFloat(this.idHue, this.hue);
        material.SetFloat(this.idSat, this.sat);
        material.SetFloat(this.idVal, this.val);
        Graphics.Blit(src, dest, material);
    }
}
