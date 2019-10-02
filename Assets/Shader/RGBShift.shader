Shader "Custom/RGBShift"
{
    Properties
    {
        _Maintex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Pass 
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.gcinc"
        }
    }
}
