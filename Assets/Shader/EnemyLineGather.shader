Shader "Custom/EnemyLineGather" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_AddictiveColor("加算色",Color)=(1.0,1.0,1.0,1.0)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		ZWrite off
		Lighting off
		Blend SrcAlpha One
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert alpha

		sampler2D _MainTex;
		float4 _AddictiveColor;
		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			int time=_Time.y/4;
			float2 uv=IN.uv_MainTex;
			uv.y=uv.y*0.25+0.25*time;
			half4 c = tex2D (_MainTex, uv);
			o.Emission = c.rgb*_AddictiveColor.rgb;
			o.Alpha = length(c.rgb)/1.73205;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
