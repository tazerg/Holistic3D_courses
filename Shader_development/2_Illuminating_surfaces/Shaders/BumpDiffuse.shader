Shader "ShaderDevelopmentCourse/BumpDiffuse"
{
    Properties
    {
        _diffuse("Diffuse", 2D) = "white"{}
        _bump("Bump", 2D) = "bump"{}
        _bumpAmount("Bump Amount", Range(0,10)) = 1
    }
    
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _diffuse;
        sampler2D _bump;
        half _bumpAmount;

        struct Input
        {
            float2 uv_diffuse;
            float2 uv_bump;
        };

        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = tex2D(_diffuse, IN.uv_diffuse).rgb;
            o.Normal = UnpackNormal(tex2D(_bump, IN.uv_bump));
            o.Normal *= float3(_bumpAmount, _bumpAmount, 1); //Add more intensity for more shadow effect
        }
        
        ENDCG
    }
    FallBack "Diffuse"
}