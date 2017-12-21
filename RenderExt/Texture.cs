using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpGL;
using static SharpGL.OpenGL;

using FreeImageAPI;
//using static FreeImageAPI.FreeImage;

namespace RenderExt
{
    

    public class Texture
    {
        // This function loads a texture from file. Note: texture loading functions like these are usually 
        // managed by a 'Resource Manager' that manages all resources (like textures, models, audio). 
        // For learning purposes we'll just define it as a utility function.
        public static uint LoadTexture(String name, OpenGL gl) {
            // Load image, create texture and generate mipmaps
            FREE_IMAGE_FORMAT format = FreeImage.GetFileType(name, 0);
            FIBITMAP image = FreeImage.Load(format, name,FREE_IMAGE_LOAD_FLAGS.DEFAULT);
            FIBITMAP temp = image;
            image = FreeImage.ConvertTo32Bits(image);
            FreeImage.Unload(temp);
            uint width_tex = FreeImage.GetWidth(image);
            uint height_tex = FreeImage.GetHeight(image);
            IntPtr bits = FreeImage.GetBits(image);
            ///////////////////////////////////////////////////
            uint[] texture=new uint[1];
            gl.GenTextures(1, texture);
            gl.BindTexture(GL_TEXTURE_2D, texture[0]);
            // All upcoming GL_TEXTURE_2D operations now have effect on
            // this texture object
            // Set the texture wrapping parameters
            gl.TexParameter(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
            // Set texture wrapping to GL_REPEAT (usually basic wrapping method)
            gl.TexParameter(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
            // Set texture filtering parameters
            gl.TexParameter(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_LINEAR);

            gl.TexParameter(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
            //glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
            //glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
            gl.TexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, (int)width_tex,(int) height_tex, 0, GL_BGRA, GL_UNSIGNED_BYTE, bits);
            gl.GenerateMipmapEXT(GL_TEXTURE_2D);

            FreeImage.Unload(image);

            gl.BindTexture(GL_TEXTURE_2D, 0);
            return texture[0];
        }
    }
}
