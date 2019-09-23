Shader "Custom/RadiationBlur"
{
    Properties 
    {
        _MainTex("Texture", 2D) = "white" {}
    }

    SubShader 
    {
        Cull off ZWrite off ZTest Always

        Pass 
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float2 _BlurCenter;
            float _BlurPower;

            fixed4 frag(v2f i) : SV_TARGET
            {
                float2 dir = _BlurCenter - i.uv;
                float dist = length(dir);
                dir = normalize(dir) * _MainTex_TexelSize.xy;
                dir *= _BlurPower * dist;

                float param = 0.19f;
                float4 col = tex2D(_MainTex, i.uv) * param;
                for (int j=1; j<10; j++) 
                {
                    col += tex2D(_MainTex, i.uv + dir * j) * (param - j * 0.02);
                }
                
                return col;
            }
            ENDCG
        }
    }
}
