/*
1. Write a shader that has two properties; one for a diffuse texture and one for a emissive texture. 
2. Use the attached images to test with Zombunny. There is one for diffuse and one for emissive. 
3. Apply the diffuse to the model's albedo and the emissive to the emission. 
*/
Shader "ShaderDevelopmentCourse/PropertiesChallenge_4"
{
    Properties
    {
        _textureDiffuse("Diffuse Texture", 2D) = "white" {}
        //set this texture to black to stop the white
        //overwhelming the effect if no emission texture
        //is present
        _textureEmissive("Emissive Texture", 2D) = "black" {}
    }
    
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _textureDiffuse;
        sampler2D _textureEmissive;

        struct Input
        {
            float2 uv_textureDiffuse;
            float2 uv_textureEmissive;
        };
        
        void surf (Input IN, inout SurfaceOutput o)
        {
            o.Albedo = tex2D(_textureDiffuse, IN.uv_textureDiffuse).rgb;
            o.Emission = tex2D(_textureEmissive, IN.uv_textureEmissive).rgb;
        }
        
        ENDCG
    }
    
    FallBack "Diffuse"
}
