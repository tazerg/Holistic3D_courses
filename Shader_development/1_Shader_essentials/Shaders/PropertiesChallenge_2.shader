/*
Create a shader that takes a texture to use as the albedo colour, 
but no matter what always turns up the green channel to full
*/
Shader "ShaderDevelopmentCourse/PropertiesChallenge_2"
{
    Properties
    {
        _texture("Texture", 2D) = "white" {}
    }
    
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _texture;

        struct Input
        {
            float2 uv_texture;
        };
        
        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed3 colour = tex2D(_texture, IN.uv_texture).rgb;
            o.Albedo = fixed3(colour.r, 1, colour.b);
        }
        
        ENDCG
    }
    
    FallBack "Diffuse"
}
