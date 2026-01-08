Shader "ShaderDevelopmentCourse/BumpEnvironment"
{
    Properties
    {
        _DiffuseTexture("DiffuseTexture", 2D) = "white" { }
        _BumpTexture("BumpTexture", 2D) = "bump" { }
        _BumpAmount("BumpAmount", Range(0,5)) = 1
        _Brightness("Brightness", Range(0,10)) = 1
        _CubeMap("CubeMap", Cube) = "white" { }
    }
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _DiffuseTexture;
        sampler2D _BumpTexture;
        half _BumpAmount;
        half _Brightness;
        samplerCUBE _CubeMap;

        struct Input
        {
            float2 uv_DiffuseTexture;
            float2 uv_BumpTexture;
            float3 worldRefl; INTERNAL_DATA
        };

        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = tex2D(_DiffuseTexture, IN.uv_DiffuseTexture).rgb;
            o.Normal = UnpackNormal(tex2D(_BumpTexture, IN.uv_BumpTexture)) * _Brightness;
            o.Normal *= float3(_BumpAmount, _BumpAmount, 1);
            o.Emission = texCUBE(_CubeMap, WorldReflectionVector(IN, o.Normal)).rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}