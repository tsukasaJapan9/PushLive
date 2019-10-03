Shader "Custom/BaseThres"
{
    Properties
    {
        _MainTex("Texture", 2D) = ""{}
        _Thres("Thres", Range(0, 1)) = 0.5
    }

    SubShader
    {
        pass 
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            half _Thres;

            fixed4 frag(v2f_img i) : COLOR 
            {
                fixed4 c = tex2D(_MainTex, i.uv);
                float gray = c.r * 0.3 + c.g * 0.6 + c.b * 0.1;
                float val = 0;
                if (_Thres < gray) {
                    val = 1;
                }
                return fixed4(val, val, val, 1);
            }
            ENDCG
        }
    }

}
