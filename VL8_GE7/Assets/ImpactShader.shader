Shader "Custom/ImpactShader" {
	Properties {
		_Color ("Base (RGB)", Color) = (1,1,1,1)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		fixed4 _Color;
		float _Radius;
		float _Brightening;
		float3 _BrighteningPos;

		struct Input 
		{
			float2 uv_MainTex;
			float3 worldPos;
		};

		void surf (Input IN, inout SurfaceOutput o)
		{
			// Get color data
			o.Albedo = _Color.rgb;
			o.Alpha = _Color.a;
			
			// Check for distance from world origin
			if(length(IN.worldPos - _BrighteningPos) <= 0.5)
			{
				o.Albedo += 0.5;
			}
		}
		ENDCG
	} 
	FallBack "Diffuse"

}
