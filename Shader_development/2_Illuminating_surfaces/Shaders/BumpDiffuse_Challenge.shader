Shader "ShaderDevelopmentCourse/BumpDiffuse_Challenge"
{
    Properties
    {
        _diffuse("Diffuse", 2D) = "white"{}
        _bump("Bump", 2D) = "bump"{}
        _bumpAmount("Bump Amount", Range(0,10)) = 1
        _textureScale("Texture Scale", Range(0,2)) = 1
    }
    
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _diffuse;
        sampler2D _bump;
        half _bumpAmount;
        half _textureScale;

        struct Input
        {
            float2 uv_diffuse;
            float2 uv_bump;
        };

        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = tex2D(_diffuse, IN.uv_diffuse * _textureScale).rgb;
            o.Normal = UnpackNormal(tex2D(_bump, IN.uv_bump * _textureScale));
            o.Normal *= float3(_bumpAmount, _bumpAmount, 1); //Add more intensity for more shadow effect
        }
        
        ENDCG
    }
    FallBack "Diffuse"
}