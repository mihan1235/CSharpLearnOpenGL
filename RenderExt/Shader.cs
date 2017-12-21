using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using SharpGL;
using static SharpGL.OpenGL;
using GlmSharp;


namespace RenderExt
{
    public class Shader
    {
        public uint ID;
        OpenGL gl;
        String vertexShaderSource;
        String fragmentShaderSource;
        String geometryShaderSource;

        String vertexPath, fragmentPath, geometryPath;

        uint vertex, fragment;
        uint geometry;

        // constructor generates the shader on the fly
        // ------------------------------------------------------------------------
        public Shader(String vertexPath, String fragmentPath, OpenGL gl, String 
                      geometryPath = null)
        {
            this.gl = gl;
            this.vertexPath = vertexPath;
            this.geometryPath = geometryPath;
            this.fragmentPath = fragmentPath;
            ReadSources();
            CompileShaders();
            CreateProgram();
            DeleteShaders();
        }

        public void Use()
        {
            gl.UseProgram(ID);
        }

        void ReadSources()
        {
            try
            {
                vertexShaderSource = File.ReadAllText(vertexPath);
                fragmentShaderSource = File.ReadAllText(fragmentPath);
                if (geometryPath != null)
                {
                    geometryShaderSource = File.ReadAllText(geometryPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR::SHADER::FILE_NOT_SUCCESFULLY_READ");
                Console.WriteLine("Message: {0}", ex.Message);
            }
        }

        void CompileShaders()
        {
            // 2. Compile shaders
            // Vertex Shader
            vertex = gl.CreateShader(GL_VERTEX_SHADER);
            gl.ShaderSource(vertex, vertexShaderSource);
            gl.CompileShader(vertex);
            CheckCompileErrors(vertex, "VERTEX");
            // Fragment Shader
            fragment = gl.CreateShader(GL_FRAGMENT_SHADER);
            gl.ShaderSource(fragment,fragmentShaderSource);
            gl.CompileShader(fragment);
            CheckCompileErrors(fragment, "FRAGMENT");
            // If geometry shader is given, compile geometry shader
            if (geometryPath != null)
            {
                geometry = gl.CreateShader(GL_GEOMETRY_SHADER);
                gl.ShaderSource(geometry,geometryShaderSource);
                gl.CompileShader(geometry);
                CheckCompileErrors(geometry, "GEOMETRY");
            }
        }

        void CheckCompileErrors(uint shader, String type)
        {
            int[] success = new int[1];
            StringBuilder infoLog = new StringBuilder(512);
            if (type != "PROGRAM")
            {
                gl.GetShader(shader, GL_COMPILE_STATUS, success);
                if (success[0] != 1)
                {
                    gl.GetShaderInfoLog(shader, 1024, IntPtr.Zero, infoLog);
                    Console.WriteLine("ERROR::SHADER_COMPILATION_ERROR of type: {0}", type);
                    Console.WriteLine("{0}", infoLog);
                    Console.WriteLine(" -- --------------------------------------------------- -- ");
                }
            }
            else
            {
                gl.GetProgram(shader, GL_LINK_STATUS, success);
                if (success[0] != 1)
                {
                    gl.GetProgramInfoLog(shader, 1024, IntPtr.Zero, infoLog);
                    Console.WriteLine("ERROR::PROGRAM_LINKING_ERROR of type: {0}", type);
                    Console.WriteLine("{0}", infoLog);
                    Console.WriteLine(" -- --------------------------------------------------- -- ");
                }
            }
        }

        void CreateProgram()
        {
            // Shader Program
            ID = gl.CreateProgram();
            gl.AttachShader(ID, vertex);
            gl.AttachShader(ID, fragment);
            if (geometryPath != null)
            {
                gl.AttachShader(ID, geometry);
            }
            gl.LinkProgram(ID);
            CheckCompileErrors(ID, "PROGRAM");
        }

        void DeleteShaders()
        {
            // Delete the shaders as they're linked into our program now and no longer necessery
            gl.DeleteShader(vertex);
            gl.DeleteShader(fragment);
            if (geometryPath != null)
            {
                gl.DeleteShader(geometry);
            }
        }

        // utility uniform functions
        // ------------------------------------------------------------------------
        public void SetBool(String name, bool value)
        {
            switch (value){
                case true:
                    gl.Uniform1(gl.GetUniformLocation(ID, name),1);
                    break;
                case false:
                    gl.Uniform1(gl.GetUniformLocation(ID, name), 0);
                    break;
            }
        }
        // ------------------------------------------------------------------------
        public void SetInt(String name, int value)
        { 
            gl.Uniform1(gl.GetUniformLocation(ID, name), value); 
        }
        // ------------------------------------------------------------------------
        public void SetFloat(String name, float value)
        { 
            gl.Uniform1(gl.GetUniformLocation(ID, name), value);
        }

        public void SetMat4(String name, mat4 obj)
        {
            int transformLoc = gl.GetUniformLocation(ID, name);
            gl.UniformMatrix4(transformLoc, 1, false, obj.Values1D);
        }
    }
}

