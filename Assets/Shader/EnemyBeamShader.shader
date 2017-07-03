Shader "Custom/EnemyBeamShader" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_SubTex("サブ",Rect)="none"{}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		Blend SrcAlpha One
		ZWrite off
		Lighting off

		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		sampler2D _SubTex;

					float3 Hue(float H)
			{
			float R = abs(H * 6.0 - 3.0) - 1.0;
			float G = 2.0 - abs(H * 6.0 - 2.0);
			float B = 2.0 - abs(H * 6.0 - 4.0);
			return saturate(float3(R, G, B));
			}
		
		float4 HSVtoRGB(float3 HSV)
		{
			return float4(((Hue(HSV.x) - 1.0) * HSV.y + 1.0) * HSV.z, 1.0);
		}

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			float2 mainUv=IN.uv_MainTex;
			mainUv.y*=1.2-0.1;
			half4 c = tex2D (_MainTex, mainUv);
			half4 s = tex2D (_SubTex, IN.uv_MainTex);
			o.Emission =HSVtoRGB(float3(length(s.rgb),0.5,1)).rgb*c.rgb;
			o.Alpha = length(s.rgb)/1.732;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
