Shader "Custom/MakotoNoMegane"
{
	Properties
	{
		_LensColor("Color", Color) = (0, 0, 0, 0.1)
	}

		SubShader
	{
		Tags
		{
			"RenderType" = "Transparent"
			"Queue" = "Geometry+1"
		}
		LOD 100
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			fixed4 _LensColor;

			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				return _LensColor;
			}
			ENDCG
		}
	}
}