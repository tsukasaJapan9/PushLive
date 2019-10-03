Shader "Custom/BaseInvert"
{
    Properties
    {
        _MainTex("Texture", 2D) = ""{}
        _Enable("Enable", int) = 0
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
            int _Enable;

            fixed4 frag(v2f_img i) : COLOR 
            {
                fixed4 c = tex2D(_MainTex, i.uv);
                if (_Enable == 1) 
                {
                    c.rgb = 1 - c.rgb;
                }
                return c;
            }
            ENDCG
        }
    }

}
