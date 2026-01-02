Shader "ShaderDevelopmentCourse/PackedPractice"
{
    Properties
    {
        _colour ("Colour", Color) = (1,1,1,1)
    }
    
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert

        struct Input
        {
            float2 uvMainTex;
        };

        fixed4 _colour;
        
        void surf(Input IN, inout SurfaceOutput o)
        {
            //o.Albedo = _colour.rgb; //use 3 values from fixed4 structure
            //o.Albedo = _colour.rbg; //swap blue and green chanel
            //o.Albedo.r = _colour.r; //use only 1 chanel
            //o.Albedo.y = _colour.y; //use y literal instead g
            //o.Albedo.z = _colour.b; //we can use different literal in different variables
            o.Albedo.rb = _colour.xz; //use 2 different chanels
        }
        ENDCG
    }

    Fallback "Mobile/Diffuse"
}