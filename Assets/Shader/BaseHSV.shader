Shader "Custom/BaseHSV"
{
    Properties
    {
        _MainTex("Texture", 2D) = ""{}
        _Hue("Hue", Range(0, 1)) = 0
        _Sat("Sat", Range(0, 1)) = 1
        _Val("Value", Range(0, 1)) = 1
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
            half _Hue, _Sat, _Val;

            // from 
            // https://kido0617.github.io/unity/2015-01-03-shader-hue-shift/
            fixed3 shift_col(fixed3 RGB, half3 shift)
            {
                fixed3 RESULT = fixed3(RGB);
                float VSU = shift.z*shift.y*cos(shift.x*3.14159265/180);
                float VSW = shift.z*shift.y*sin(shift.x*3.14159265/180);
                
                RESULT.x = (.299*shift.z+.701*VSU+.168*VSW)*RGB.x
                + (.587*shift.z-.587*VSU+.330*VSW)*RGB.y
                + (.114*shift.z-.114*VSU-.497*VSW)*RGB.z;
                
                RESULT.y = (.299*shift.z-.299*VSU-.328*VSW)*RGB.x
                + (.587*shift.z+.413*VSU+.035*VSW)*RGB.y
                + (.114*shift.z-.114*VSU+.292*VSW)*RGB.z;
                
                RESULT.z = (.299*shift.z-.3*VSU+1.25*VSW)*RGB.x
                + (.587*shift.z-.588*VSU-1.05*VSW)*RGB.y
                + (.114*shift.z+.886*VSU-.203*VSW)*RGB.z;
                
                return (RESULT);
            }

            fixed4 frag(v2f_img i) : COLOR 
            {
                fixed4 c = tex2D(_MainTex, i.uv);
                c.rgb *= c.a;
                half3 shift = half3(_Hue, _Sat, _Val);
                return fixed4(shift_col(c, shift), c.a);
            }
            ENDCG
        }
    }

}
