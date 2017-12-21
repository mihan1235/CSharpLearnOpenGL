using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloTriangleExercise2
{
    using glfw3;
    using static glfw3.glfw3;
    using static glfw3.KeyMacros;
    using static glfw3.State;
    using SharpGL;
    using static SharpGL.OpenGL;
    using System.Runtime.InteropServices;
    //Now create the same 2 triangles using two different VAOs and VBOs for their data
    class Program
    {
        static int width = 1366;
        static int hight = 768;
        static OpenGL gl = new OpenGL();

        static String vertexShaderSource = "#version 330 core\n" +
             "layout (location = 0) in vec3 aPos;\n" +
             "void main()\n" +
             "{\n" +
             "   gl_Position = vec4(aPos.x, aPos.y, aPos.z, 1.0);\n" +
             "}\0";
        static String fragmentShaderSource = "#version 330 core\n" +
            "out vec4 FragColor;\n" +
            "void main()\n" +
            "{\n" +
            "   FragColor = vec4(1.0f, 0.5f, 0.2f, 1.0f);\n" +
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
            StringBuilder infoLog = new StringBuilder();
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
            float[] firstTriangle = {
                 -0.9f, -0.5f, 0.0f,  // left 
                 -0.0f, -0.5f, 0.0f,  // right
                 -0.45f, 0.5f, 0.0f,  // top 
            };
            float[] secondTriangle = {
                0.0f, -0.5f, 0.0f,  // left
                0.9f, -0.5f, 0.0f,  // right
                0.45f, 0.5f, 0.0f   // top 
             };

            uint[] VBO, VAO;
            VBO = new uint[2];
            VAO = new uint[2];
            gl.GenVertexArrays(2, VAO);
            gl.GenBuffers(2, VBO);
            // first triangle setup
            // --------------------
            gl.BindVertexArray(VAO[0]);
            gl.BindBuffer(GL_ARRAY_BUFFER, VBO[0]);
            gl.BufferData(GL_ARRAY_BUFFER, firstTriangle, GL_STATIC_DRAW);
            gl.VertexAttribPointer(0, 3, GL_FLOAT, false, 3 * sizeof(float), IntPtr.Zero);   // Vertex attributes stay the same
            gl.EnableVertexAttribArray(0);
            // glBindVertexArray(0); // no need to unbind at all as we directly bind a different VAO the next few lines
            // second triangle setup
            // ---------------------
            gl.BindVertexArray(VAO[1]); // note that we bind to a different VAO now
            gl.BindBuffer(GL_ARRAY_BUFFER, VBO[1]); // and a different VBO
            gl.BufferData(GL_ARRAY_BUFFER, secondTriangle, GL_STATIC_DRAW);
            gl.VertexAttribPointer(0, 3, GL_FLOAT, false, 0, IntPtr.Zero); // because the vertex data is tightly packed we can also specify 0 as the vertex attribute's stride to let OpenGL figure it out
            gl.EnableVertexAttribArray(0);
            // glBindVertexArray(0); // not really necessary as well, but beware of calls that could affect VAOs while this one is bound (like binding element buffer objects, or enabling/disabling vertex attributes)



            // You can unbind the VAO afterwards so other VAO calls won't accidentally modify this VAO, but this rarely happens. Modifying other
            // VAOs requires a call to glBindVertexArray anyways so we generally don't unbind VAOs (nor VBOs) when it's not directly necessary.
            // gl.BindVertexArray(0);


            // uncomment this call to draw in wireframe polygons.
            //gl.PolygonMode(GL_FRONT_AND_BACK, GL_LINE);

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
                // draw first triangle using the data from the first VAO
                gl.BindVertexArray(VAO[0]);
                gl.DrawArrays(GL_TRIANGLES, 0, 3);
                // then we draw the second triangle using the data from the second VAO
                gl.BindVertexArray(VAO[1]);
                gl.DrawArrays(GL_TRIANGLES, 0, 3);


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
