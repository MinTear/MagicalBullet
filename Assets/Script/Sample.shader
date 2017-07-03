Shader "Custom/MagiccCircle" {
	Properties {
		_BaseTexture("BaseTexture",Rect)="None"{}
		_NoiseTexture("NoiseTexture",Rect)="None"{}
		_Hue("色相",Range(0,1))=0.5
		_MinHue("さりげなさ",Range(0,1))=0.5
	}
	SubShader {
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" }
		Blend Zero SrcColor
		Lighting Off
		ZWrite Off
		CGPROGRAM
		#pragma surface surf Lambert alpha

		sampler2D _BaseTexture;
		sampler2D _NoiseTexture;
		float _Hue;
		float _MinHue;

		struct Input {
			float2 uv_BaseTexture;
			float2 uv_NoiseTexture;
		};

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

		float calcAlpha(half4 col)
		{
			if(length(col)>0.2)
			{
				return 1;
			}
			return 0;
		}

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_BaseTexture, IN.uv_BaseTexture);
			half4 n= tex2D(_NoiseTexture,IN.uv_NoiseTexture+float2(_SinTime.x,_CosTime.y));
			o.Emission =c.rgb*HSVtoRGB(float3(_Hue,_MinHue+n.x*(1-_MinHue),1)).rgb;
			o.Alpha =calcAlpha(c);
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
