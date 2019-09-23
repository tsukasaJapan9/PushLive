Shader "Custom/wipe"
{
    Properties
    {
        _Radius("Radius", Range(0, 2)) = 2
        _MainTex("MainTex", 2D) = ""
    }
    SubShader
    {
        Pass 
        {
            CGPROGRAM

            #include "UnityCG.cginc"
            #pragma vertex vert_img
            #pragma fragment frag

            sampler2D _MainTex;

            float _Radius;
            fixed4 frag(v2f_img i) : COLOR {
                i.uv -= fixed2(0.5, 0.5);
                i.uv.x *= 16.0 / 9.0;
                if (distance(i.uv, fixed2(0, 0)) < _Radius) {
                    return tex2D(_MainTex, i.uv);
                }
                return fixed4(0.0, 0.0, 0.0, 1.0);

                // float4 color = tex2D(_MainTex, i.uv);
                // float gray = (color.r + color.g + color.b) / 3;
                // color.rgb = float3(gray, gray, gray);

                // return color;
            }
            ENDCG
        }
    }
}
