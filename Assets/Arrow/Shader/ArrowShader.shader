Shader "Custom/SignShader" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_OverlayTex("オーバーレイ",2D)="white"{}
		_BarColor("バーの色",Color)=(1.0,1.0,1.0,1.0)
		_Direction("方向(1,2)/uvy:3",Vector)=(1.0,0.0,0.0,0.0)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert alpha

		sampler2D _MainTex;
		sampler2D _OverlayTex;
		float4 _BarColor;
		float4 _Direction;
		struct Input {
			float2 uv_MainTex;
			float2 uv_OverlayTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			float2 muv=IN.uv_MainTex;
			muv.y=1.0/3.0*_Direction.z+muv.y/3.0;
			half4 a=tex2D(_OverlayTex,IN.uv_OverlayTex+_Direction.xy*_Time.y);
			half4 c = tex2D (_MainTex, muv);
			o.Emission = _BarColor.rgb;
			o.Alpha = c.a*a.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
