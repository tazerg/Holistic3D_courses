/*
Modify the shader from the previous lecture to use the _myColor, 
_myRange and _myTex property to add colour to the albedo.  
Hint: add _myColor to the existing albedo calculation.
*/
Shader "ShaderDevelopmentCourse/PropertiesChallenge_1"
{
    Properties
    {
        _colour("Colour", Color) = (1,1,1,1)
        _range("Range", Range(0,5)) = 1
        _texture("Texture", 2D) = "white" {}
        _cubeMap ("Cube Map", CUBE) = "" {}
    }
    
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert

        fixed4 _colour;
        half _range;
        sampler2D _texture;
        samplerCUBE _cubeMap;

        struct Input
        {
            float2 uv_texture;
            float3 worldRefl;
        };
        
        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed3 colour = tex2D(_texture, IN.uv_texture).rgb;
            colour *= _colour.rgb; //tint
            colour *= _range; //intensity
            o.Albedo = colour;
            o.Emission = texCUBE(_cubeMap, IN.worldRefl).rgb;
        }
        
        ENDCG
    }
    
    FallBack "Diffuse"
}
