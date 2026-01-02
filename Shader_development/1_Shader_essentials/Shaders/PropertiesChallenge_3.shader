/*
Create a shader that has only one property which is a texture.  
This texture should colour the albedo. 
To this texture, before applying it to the albedo apply the colour green.
*/
Shader "ShaderDevelopmentCourse/PropertiesChallenge_3"
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
            colour *= fixed3(0,1,0);
            o.Albedo = colour;
        }
        
        ENDCG
    }
    
    FallBack "Diffuse"
}
