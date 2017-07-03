Shader "Custom/HpBarShader" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_OverlayTex("オーバーレイ",2D)="white"{}
		_BarColor("バーの色",Color)=(1.0,1.0,1.0,1.0)
		_MaxTheta("最大角度",Float)=0
		_RadiansOffset("オフセット角度",Float)=0.0
		_Percentage("HPパーセンテージ",Range(0,1))=0.5
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert alpha
		float minusOffset=0.78539;//1/4Pi
		sampler2D _MainTex;
		sampler2D _OverlayTex;
		float4 _BarColor;
		float _MaxTheta;
		float _RadiansOffset;
		float _Percentage;
		struct Input {
			float2 uv_MainTex;
			float2 uv_OverlayTex;
		};
				
		float2 rotate(float2 source,float angle)
		{
			return float2(source.x*cos(angle)+source.y*sin(angle),-source.x*sin(angle)+source.y*cos(angle));
		}
		
		//x=rcosθ
		//y=rsinθ
		float calcAngle(float2 uvPos)
		{
			float2 centerizedPosition=uvPos-float2(0.5,0.5);
			centerizedPosition=rotate(centerizedPosition,_RadiansOffset);
			float radius=length(centerizedPosition);
			if(radius==0)return 0;
			float sinTheta=centerizedPosition.y/radius;
			float cosTheta=centerizedPosition.x/radius;
			float stheta=asin(sinTheta);
			float ctheta=acos(cosTheta);
			if(sinTheta<0)
			{
				return -ctheta+6.2830;
			}else
			{
				return ctheta;
			}
		}

		float adjustRadians(float radian)
		{
		return radian;
			if(abs(radian)>3.1415)
			{
				if(radian>0){
					return -radian+3.1415;
				}else{
					return-radian-3.1415;
				}
			}else{
				return radian;
			}
		}
		
		bool isInnerRange(float2 uv)
		{
			float radian=6.2830-calcAngle(uv);
			radian=adjustRadians(radian);
			return radian<_MaxTheta*_Percentage;
		}

		void surf (Input IN, inout SurfaceOutput o) {
			half4 a=tex2D(_OverlayTex,IN.uv_OverlayTex+float2(_SinTime.y,_CosTime.y));
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			if(isInnerRange(IN.uv_MainTex))
			{
				o.Emission = c.a*_BarColor.rgb;
			}else{
				o.Alpha=0;
				return;
			}
			o.Alpha = c.a*a.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
