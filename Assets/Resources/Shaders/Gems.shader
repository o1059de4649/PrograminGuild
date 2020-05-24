Shader "Custom/Gems"
{
	Properties{
			_Color("Color", Color) = (1,1,1,1)
			_MainTex("Albedo (RGB)", 2D) = "white" {}
			_Metallic ("Metallic", Range(0,1)) = 0.0
			_Smooth ("Smooth", Range(0,1)) = 0.0
	}

	SubShader
	{
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent"}
		LOD 200

		Pass{
			ZWrite ON
			ColorMask 0
		}

		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows alpha:fade
		#pragma target 3.0

		sampler2D _MainTex;
			half _Metallic;
			half _Smooth;

		struct Input {
			float2 uv_MainTex;
		};

		fixed4 _Color;

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Metallic = _Metallic;
			o.Smoothness = _Smooth;
			o.Alpha = c.a;
		}
		ENDCG
}
	FallBack "Diffuse"
}

