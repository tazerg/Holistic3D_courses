Shader "ShaderDevelopmentCourse/FirstShader" // Shader name
{
    Properties // Shader properties
    {
        _colour ("Colour", Color) = (1,1,1,1)
        _emission ("Emission", Color) = (1,1,1,1)
        _normal ("Normal", Color) = (1,1,1,1)
    }
    
    SubShader // Shader code
    {
        CGPROGRAM
            #pragma surface surf Lambert // it is surface shader

            struct Input // input data from model (verticies, normals etc)
            {
                float2 uvMainText; // uv texture
            };

            fixed4 _colour; // acces _colour from Properties block
            fixed4 _emission;
            fixed4 _normal;

            void surf(Input IN, inout SurfaceOutput o)
            {
                o.Albedo = _colour.rgb;
                o.Emission = _emission.rgb;
                o.Normal = _normal.rgb;
            }
        ENDCG
    }

    Fallback "Mobile/Diffuse" // fallback shader
}