using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadersInterpolation
{
    using glfw3;
    using static glfw3.glfw3;
    using static glfw3.KeyMacros;
    using static glfw3.State;
    using SharpGL;
    using static SharpGL.OpenGL;
    using System.Runtime.InteropServices;

    class Program
    {
        static int width = 1366;
        static int hight = 768;
        static OpenGL gl = new OpenGL();

        static String vertexShaderSource = "#version 330 core\n"+
            "layout (location = 0) in vec3 aPos;\n"+
            "layout (location = 1) in vec3 aColor;\n"+
            "out vec3 ourColor;\n"+
            "void main()\n"+
            "{\n"+
            "   gl_Position = vec4(aPos, 1.0);\n"+
            "   ourColor = aColor;\n"+
            "}\0";

        static String fragmentShaderSource = "#version 330 core\n"+
            "out vec4 FragColor;\n"+
            "in vec3 ourColor;\n"+
            "void main()\n"+
            "{\n"+
            "   FragColor = vec4(ourColor, 1.0f);\n"+
            "}\n\0";
        
        static int Main(string[] args)
        {
            GlfwInit();
            GlfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
            GlfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
            GlfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
            GLFWwindow window = GlfwCreateWindow(width, hight, "LearnOpenGL", null, null);
            if (window == null)
            {
                Console.WriteLine("Failed to create GLFW window");
                GlfwTerminate();
                return -1;
            }
            GlfwMakeContextCurrent(window);

            GLFWframebuffersizefun a = new GLFWframebuffersizefun(framebuffer_size_callback);
            GlfwSetFramebufferSizeCallback(window, a);
            // render loop
            // -----------

            // build and compile our shader program
            // ------------------------------------
            // vertex shader
            uint vertexShader = gl.CreateShader(GL_VERTEX_SHADER);
            gl.ShaderSource(vertexShader, vertexShaderSource);
            gl.CompileShader(vertexShader);
            // check for shader compile errors
            int[] success = new int[1];
            StringBuilder infoLog = new StringBuilder(512);
            gl.GetShader(vertexShader, GL_COMPILE_STATUS, success);
            if (success[0] != 1)
            {
                gl.GetShaderInfoLog(vertexShader, 512, IntPtr.Zero, infoLog);
                Console.WriteLine("ERROR::SHADER::VERTEX::COMPILATION_FAILED\n");
                Console.WriteLine("{0}", infoLog);
            }
            // fragment shader
            uint fragmentShader = gl.CreateShader(GL_FRAGMENT_SHADER);
            gl.ShaderSource(fragmentShader, fragmentShaderSource);
            gl.CompileShader(fragmentShader);
            // check for shader compile errors
            gl.GetShader(fragmentShader, GL_COMPILE_STATUS, success);
            if (success[0] != 1)
            {
                gl.GetShaderInfoLog(fragmentShader, 512, IntPtr.Zero, infoLog);
                Console.WriteLine("ERROR::SHADER::FRAGMENT::COMPILATION_FAILED\n");
                Console.WriteLine("{0}", infoLog);
            }
            // link shaders
            uint shaderProgram = gl.CreateProgram();
            gl.AttachShader(shaderProgram, vertexShader);
            gl.AttachShader(shaderProgram, fragmentShader);
            gl.LinkProgram(shaderProgram);
            // check for linking errors
            gl.GetProgram(shaderProgram, GL_LINK_STATUS, success);
            if (success[0] != 1)
            {
                gl.GetProgramInfoLog(shaderProgram, 512, IntPtr.Zero, infoLog);
                Console.WriteLine("ERROR::SHADER::PROGRAM::LINKING_FAILED\n");
                Console.WriteLine("{0}", infoLog);
            }
            gl.DeleteShader(vertexShader);
            gl.DeleteShader(fragmentShader);

            // set up vertex data (and buffer(s)) and configure vertex attributes
            // ------------------------------------------------------------------
            // set up vertex data (and buffer(s)) and configure vertex attributes
            // ------------------------------------------------------------------
            float[] vertices = {
                // positions         // colors
                 0.5f, -0.5f, 0.0f,  1.0f, 0.0f, 0.0f,  // bottom right
                -0.5f, -0.5f, 0.0f,  0.0f, 1.0f, 0.0f,  // bottom left
                 0.0f,  0.5f, 0.0f,  0.0f, 0.0f, 1.0f   // top 
            };

            uint[] VBO, VAO;
            VBO = new uint[1];
            VAO = new uint[1];
            gl.GenVertexArrays(1, VAO);
            gl.GenBuffers(1, VBO);
            // bind the Vertex Array Object first, then bind and set vertex buffer(s), and then configure vertex attributes(s).
            gl.BindVertexArray(VAO[0]);

            gl.BindBuffer(GL_ARRAY_BUFFER, VBO[0]);

            gl.BufferData(GL_ARRAY_BUFFER, vertices, GL_STATIC_DRAW);


            // position attribute
            gl.VertexAttribPointer(0, 3, GL_FLOAT, false, 6 * sizeof(float), IntPtr.Zero);
            gl.EnableVertexAttribArray(0);
            // color attribute
            gl.VertexAttribPointer(1, 3, GL_FLOAT, false, 6 * sizeof(float), new IntPtr(3 * sizeof(float)));
            
            gl.EnableVertexAttribArray(1);


            // note that this is allowed, the call to glVertexAttribPointer registered VBO as the vertex attribute's bound vertex buffer object so afterwards we can safely unbind
            gl.BindBuffer(GL_ARRAY_BUFFER, 0);

            // You can unbind the VAO afterwards so other VAO calls won't accidentally modify this VAO, but this rarely happens. Modifying other
            // VAOs requires a call to glBindVertexArray anyways so we generally don't unbind VAOs (nor VBOs) when it's not directly necessary.
            gl.BindVertexArray(0);


            // uncomment this call to draw in wireframe polygons.
            //glPolygonMode(GL_FRONT_AND_BACK, GL_LINE);

            while (GlfwWindowShouldClose(window) != GLFW_TRUE)
            {
                // input
                // -----
                processInput(window);

                // render
                // ------
                gl.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
                gl.Clear(GL_COLOR_BUFFER_BIT);

                // draw our first triangle
                gl.UseProgram(shaderProgram);
                gl.BindVertexArray(VAO[0]); // seeing as we only have a single VAO there's no need to bind it every time, but we'll do so to keep things a bit more organized
                gl.DrawArrays(GL_TRIANGLES, 0, 3);
                // glBindVertexArray(0); // no need to unbind it every time 

                // glfw: swap buffers and poll IO events (keys pressed/released, mouse moved etc.)
                // -------------------------------------------------------------------------------
                GlfwSwapBuffers(window);
                GlfwPollEvents();
            }

            // optional: de-allocate all resources once they've outlived their purpose:
            // ------------------------------------------------------------------------
            gl.DeleteVertexArrays(1, VAO);
            gl.DeleteBuffers(1, VBO);
            // glfw: terminate, clearing all previously allocated GLFW resources.
            // ------------------------------------------------------------------
            GlfwTerminate();
            return 0;
        }

        // process all input: query GLFW whether relevant keys are pressed/released this frame and react accordingly
        // ---------------------------------------------------------------------------------------------------------
        static void processInput(GLFWwindow window)
        {
            if (GlfwGetKey(window, GLFW_KEY_ESCAPE) == GLFW_PRESS)
                GlfwSetWindowShouldClose(window, GLFW_TRUE);
        }

        // glfw: whenever the window size changed (by OS or user resize) this callback function executes
        // ---------------------------------------------------------------------------------------------
        static void framebuffer_size_callback(IntPtr window, int width, int height)
        {
            // make sure the viewport matches the new window dimensions; note that width and 
            // height will be significantly larger than specified on retina displays.
            //glViewport(0, 0, width, height);
            gl.Viewport(0, 0, width, height);
            //Console.WriteLine("glViewport(0, 0, {0}, {1});",width,hight);
        }
    }
}
