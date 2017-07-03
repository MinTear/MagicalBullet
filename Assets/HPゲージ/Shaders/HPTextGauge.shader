Shader "Custom/HPTextGauge" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_OverlayTex("オーバーレイ",2D)="white"{}
		_BarColor("ゲージ色",Color)=(1.0,1.0,1.0,1.0)
		_AccentColor("アクセントカラー",Color)=(1.0,1.0,1.0,1.0)
		_AccentWidthCoefficient("アクセントの広さ",Float)=1
	}		
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert alpha
		float4 _BarColor;
		float4 _AccentColor;
		float _AccentWidthCoefficient;
		sampler2D _MainTex;
		sampler2D _OverlayTex;
		struct Input {
			float2 uv_MainTex;
			float2 uv_OverlayTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			half4 a=tex2D(_OverlayTex,IN.uv_OverlayTex+float2(_SinTime.y,_CosTime.y));
			o.Emission = c.a*_BarColor.rgb;
			o.Alpha = a.a*c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
