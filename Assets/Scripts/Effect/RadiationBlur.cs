using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class RadiationBlur : MonoBehaviour
{
    const string SHADER_NAME = "Custom/RadiationBlur";
    
    public Vector2 center = new Vector2(0.5f, 0.5f);

    [Range(0, 100)]
    public float power = 0f;

    [SerializeField]
    private Shader _shader;

    public Shader shader {
        get 
        {
            if (_shader == null) {
                _shader = Shader.Find(SHADER_NAME);
            }
            return _shader;
        }
    }

    private Material _material;
    private Material material {
        get 
        {
            if (_material == null) {
                _material = new Material(shader);
                //_material.hideFlags = HideFlags.DontSave;
            }
            return _material;
        }
    }

    private void OnDisable()
    {
        if (_material != null) {
            DestroyImmediate(_material);
        }
        _material = null;
    }

    int IdBlurCenter = -1;
    int IdBlurPower = -1;

    private void Awake() 
    {   
        IdBlurCenter = Shader.PropertyToID("_BlurCenter");
        IdBlurPower = Shader.PropertyToID("_BlurPower");
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        material.SetVector(IdBlurCenter, center);
        material.SetFloat(IdBlurPower, power);
        Graphics.Blit(src, dest, material);
    }
}