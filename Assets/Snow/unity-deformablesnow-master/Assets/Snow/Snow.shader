Shader "Custom/SnowExample" {
    Properties {
        _Tess("Tessellation", Range(1, 64)) = 4

        _MainTex("Top Tex (RGB)", 2D) = "white" {}
        _MainTex2("Bottom Tex (RGB)", 2D) = "white" {}

        _DispTex("Displacement Texture", 2D) = "white" {}
        _ImprintTex("Imprint Texture", 2D) = "white" {}

        _Displacement("Displacement", Range(0, 1.0)) = 0.3

        _TopColor("Top Color", Color) = (1, 1, 1, 0)
        _BotColor("Bottom Color", Color) = (1, 1, 1, 0)
    }

    SubShader {
        Tags { "RenderType" = "Opaque" }
        LOD 100

        Pass {
            Name "FORWARD"
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct appdata_t {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f {
                float4 vertex : SV_POSITION;
                float2 texcoord : TEXCOORD0;
            };

            float _Tess;

            TEXTURE2D(_MainTex);
            TEXTURE2D(_MainTex2);
            TEXTURE2D(_ImprintTex);
            TEXTURE2D(_DispTex);
            float _Displacement;

            SAMPLER(sampler_MainTex);
            SAMPLER(sampler_MainTex2);
            SAMPLER(sampler_ImprintTex);
            SAMPLER(sampler_DispTex);

            float3 FindNormal(sampler2D tex, float2 uv, float u) {
                // Your FindNormal function
            }

            float4 _TopColor;
            float4 _BotColor;

            v2f vert(appdata_t v) {
                v2f o;
                o.vertex = TransformObjectToHClip(v.vertex.xyz);
                o.texcoord = v.texcoord;
                return o;
            }

            float4 frag(v2f i) : SV_Target {
                float4 c = lerp(
                    SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord) * _TopColor,
                    SAMPLE_TEXTURE2D(_MainTex2, sampler_MainTex2, i.texcoord) * _BotColor,
                    1 - SAMPLE_TEXTURE2D(_ImprintTex, sampler_ImprintTex, float2(1 - i.texcoord.x, i.texcoord.y)).r);
                return c;
            }
            ENDHLSL
        }
    }

    FallBack "Diffuse"
}
