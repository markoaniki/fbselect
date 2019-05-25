Shader "Unlit/Floor"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Lightmap ("Lightmap", 2D) = "white" {}
		_Color1 ("Cor01", Color) = (0.5, 0.5, 0.5, 1)
		_Color2 ("Cor02", Color) = (0.75, 0.75, 0.75, 1)
		_Lightcolor("Cor Da Luz", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			sampler2D _Lightmap;
			float4 _Color1;
			float4 _Color2;
			float4 _Lightcolor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
				fixed4 col1 = col * _Color1;
				fixed4 col2 = (1 - col) * _Color2;
				col = col1 + col2;

				fixed4 lightmap = tex2D(_Lightmap, i.uv);
				col1 = lightmap * _Lightcolor;
				col2 = (1 - lightmap) * col;
				col = col1 + col2;
				
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
