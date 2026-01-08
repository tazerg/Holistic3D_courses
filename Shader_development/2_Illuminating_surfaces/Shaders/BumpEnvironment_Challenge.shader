Shader "ShaderDevelopmentCourse/BumpEnvironment_Challenge"
{
    Properties
    {
        _NormalMap("NormalMap", 2D) = "bump" { }
        _CubeMap("CubeMap", Cube) = "white" { }
        
    }
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _NormalMap;
        samplerCUBE _CubeMap;

        struct Input
        {
            float2 uv_NormalMap;
            float3 worldRefl; INTERNAL_DATA
        };

        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap)) * 0.3;
            o.Albedo = texCUBE(_CubeMap, WorldReflectionVector(IN, o.Normal)).rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}