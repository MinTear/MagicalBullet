Shader "Custom/HPTextChar" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_OverlayTex("オーバーレイ",2D)="white"{}
		_BarColor("ゲージ色",Color)=(1.0,1.0,1.0,1.0)
		_ColumnCount("列数",Float)=11.0
		_CurrentColumn("現在の列",Float)=1.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert alpha

		sampler2D _MainTex;
		float4 _BarColor;
		float _ColumnCount;
		float _CurrentColumn;
		sampler2D _OverlayTex;
		struct Input {
			float2 uv_MainTex;
			float2 uv_OverlayTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 a=tex2D(_OverlayTex,IN.uv_OverlayTex+float2(_SinTime.y,_CosTime.y));
			float2 uvTex=IN.uv_MainTex;
			uvTex.x=IN.uv_MainTex.x/_ColumnCount+1.0/_ColumnCount*_CurrentColumn;
			half4 c = tex2D (_MainTex,uvTex);
			o.Emission = c.rgb*_BarColor;
			o.Alpha = c.a*a.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
