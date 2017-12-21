#version 420 core
out vec4 FragColor;

in vec2 TexCoord;

// texture samplers
layout (binding=0) uniform sampler2D texture1;
layout (binding=1) uniform sampler2D texture2;

void main()
{
	// linearly interpolate between both textures (80% container, 20% awesomeface)
	FragColor = mix(texture(texture1, TexCoord), texture(texture2, TexCoord), 0.2);
}