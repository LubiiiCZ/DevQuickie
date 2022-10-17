#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

Texture2D SpriteTexture;
float amount;

sampler2D SpriteTextureSampler = sampler_state
{
	Texture = <SpriteTexture>;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
};

float4 MainPS(VertexShaderOutput input) : COLOR
{
	float4 col = tex2D(SpriteTextureSampler, input.TextureCoordinates) * input.Color;

    if (input.TextureCoordinates.y <= amount)
    {
        col.rgba = 0;
    }
    else if (col.a > 0 && input.TextureCoordinates.y > amount && input.TextureCoordinates.y < amount + 0.1f)
    {
        col.rg = (col.r + col.g) / 2.0f;
        col.b = 1;
    }

    return col;
}

technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};
