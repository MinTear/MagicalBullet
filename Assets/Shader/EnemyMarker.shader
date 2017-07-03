Shader "Custom/EnemyMarker" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_FirstColor("初期カラー",Color)=(1,0,0,1)
		_EndColor("最終カラー",Color)=(0,1,0,1)
		_Progress("進捗度",Range(0,1))=0.5
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		ZWrite off
		Blend One One
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		float4 _FirstColor;
		float4 _EndColor;
		float _Progress;
		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Emission = length(c.rgb)/1.732*lerp(_FirstColor.rgb,_EndColor.rgb,_Progress);
			o.Alpha = length(c.rgb)/1.732;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
