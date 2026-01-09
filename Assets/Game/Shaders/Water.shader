Shader "Custom/WaterMetaball"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _WaterColor ("Water Color", Color) = (0.2, 0.6, 1, 0.8)
        _SurfaceColor ("Surface Color", Color) = (0.3, 0.7, 1, 1)
        _EdgeColor ("Edge Color", Color) = (1, 1, 1, 0.9)
        _BlendStrength ("Blend Strength", Range(0.1, 5)) = 1.0
        _IsoSurface ("Iso Surface", Range(0.1, 0.9)) = 0.5
        _Smoothness ("Smoothness", Range(0, 1)) = 0.8
        _FoamIntensity ("Foam Intensity", Range(0, 1)) = 0.3
        _LightDirection ("Light Direction", Vector) = (0.5, 0.5, 0, 0)
    }
    
    SubShader
    {
        Tags { 
            "Queue"="Transparent" 
            "RenderType"="Transparent" 
            "IgnoreProjector"="True"
        }
        
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
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
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD1;
            };
            
            // Данные частиц
            uniform float4 _ParticleData[100]; // x,y,z,radius
            uniform int _ParticleCount;
            uniform float _BlendStrength;
            uniform float _IsoSurface;
            
            // Цвета и параметры
            uniform float4 _WaterColor;
            uniform float4 _SurfaceColor;
            uniform float4 _EdgeColor;
            uniform float _Smoothness;
            uniform float _FoamIntensity;
            uniform float2 _LightDirection;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }
            
            // Функция для метаболов (полиномиальное слияние)
            float metaball(float2 p, float2 center, float radius)
            {
                float d = distance(p, center);
                return radius * radius / (d * d + 0.0001);
            }
            
            // Функция для плавного шага
            float smoothstep(float edge0, float edge1, float x)
            {
                float t = clamp((x - edge0) / (edge1 - edge0), 0.0, 1.0);
                return t * t * (3.0 - 2.0 * t);
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                float2 pixelPos = i.worldPos.xy;
                float fieldValue = 0.0;
                
                // Суммируем влияние всех частиц
                for (int idx = 0; idx < _ParticleCount; idx++)
                {
                    float2 particlePos = _ParticleData[idx].xy;
                    float radius = _ParticleData[idx].w;
                    
                    // Используем обратное квадратичное расстояние для плавного смешивания
                    float dist = distance(pixelPos, particlePos);
                    float influence = radius / (dist * dist * _BlendStrength + 0.1);
                    fieldValue += influence;
                }
                
                // Нормализуем значение поля
                fieldValue = saturate(fieldValue);
                
                // Определяем, находится ли пиксель внутри поверхности
                float surface = smoothstep(_IsoSurface - 0.1, _IsoSurface + 0.1, fieldValue);
                
                // Если пиксель снаружи - отбрасываем
                if (surface < 0.01)
                    discard;
                
                // Вычисляем нормаль через градиент
                float eps = 0.01;
                float dx = 0.0;
                float dy = 0.0;
                
                for (int idx = 0; idx < _ParticleCount; idx++)
                {
                    float2 particlePos = _ParticleData[idx].xy;
                    float radius = _ParticleData[idx].w;
                    
                    float distX1 = distance(pixelPos + float2(eps, 0), particlePos);
                    float distX2 = distance(pixelPos - float2(eps, 0), particlePos);
                    float influenceX1 = radius / (distX1 * distX1 * _BlendStrength + 0.1);
                    float influenceX2 = radius / (distX2 * distX2 * _BlendStrength + 0.1);
                    dx += (influenceX1 - influenceX2) / (2.0 * eps);
                    
                    float distY1 = distance(pixelPos + float2(0, eps), particlePos);
                    float distY2 = distance(pixelPos - float2(0, eps), particlePos);
                    float influenceY1 = radius / (distY1 * distY1 * _BlendStrength + 0.1);
                    float influenceY2 = radius / (distY2 * distY2 * _BlendStrength + 0.1);
                    dy += (influenceY1 - influenceY2) / (2.0 * eps);
                }
                
                // Нормализуем нормаль
                float2 normal = normalize(float2(-dx, -dy));
                
                // Освещение
                float lightDot = dot(normal, normalize(_LightDirection));
                lightDot = lightDot * 0.5 + 0.5; // Переводим в диапазон 0-1
                
                // Цвет в зависимости от глубины (значения поля)
                float depth = fieldValue;
                float4 color = lerp(_WaterColor, _SurfaceColor, depth);
                
                // Добавляем освещение
                color.rgb *= (0.7 + 0.3 * lightDot);
                
                // Эффект пены на краях
                float edgeFactor = 1.0 - saturate(abs(dx * 10.0) + abs(dy * 10.0));
                float foam = smoothstep(0.3, 0.7, edgeFactor) * _FoamIntensity;
                
                // Добавляем белую пену
                color.rgb = lerp(color.rgb, _EdgeColor.rgb, foam);
                
                // Альфа канал в зависимости от близости к поверхности
                float alpha = smoothstep(0.0, 0.2, surface);
                alpha *= _WaterColor.a;
                
                // Добавляем блик на поверхности
                float specular = pow(saturate(dot(reflect(normalize(float2(0, -1)), normal), 
                                                 normalize(_LightDirection))), 32.0);
                color.rgb += specular * _Smoothness;
                
                // Легкое искажение по нормалям для эффекта воды
                float2 distortion = normal * 0.01 * sin(_Time.y * 2.0 + pixelPos.x * 5.0);
                color.rgb *= (0.95 + 0.05 * sin(_Time.y * 3.0 + pixelPos.x * 8.0 + pixelPos.y * 6.0));
                
                return fixed4(color.rgb, alpha);
            }
            ENDCG
        }
    }
    
    FallBack "Transparent/VertexLit"
}