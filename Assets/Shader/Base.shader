Shader "Custom/Base"
{
    Properties
    {
        _Darkness("Darkness", Range(0, 0.1)) = 0.04
        _Strength("Strength", Range(0.05, 0.15)) = 0.05
        _MainTex("Texture", 2D) = ""{}
    }
    SubShader
    {
        Pass 
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            half _Darkness;
            half _Strength;

            fixed4 frag(v2f_img i) : COLOR 
            {
                fixed4 c = tex2D(_MainTex, i.uv);
                float gray = c.r * 0.5 + c.g * 0.5 + c.b * 0.5;
                c.rgb = fixed3(gray, gray, gray);
                return c;
            }
            ENDCG
        }
    }

}
