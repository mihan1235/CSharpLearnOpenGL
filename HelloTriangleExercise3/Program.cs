using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloTriangleExercise3
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
        static String fragmentShader1Source = "#version 330 core\n" +
            "out vec4 FragColor;\n" +
            "void main()\n" +
            "{\n" +
            "   FragColor = vec4(1.0f, 0.5f, 0.2f, 1.0f);\n" +
            "}\n\0";
        static String fragmentShader2Source = "#version 330 core\n"+
            "out vec4 FragColor;\n"+
            "void main()\n"+
            "{\n"+
            "   FragColor = vec4(1.0f, 1.0f, 0.0f, 1.0f);\n"+
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
            // we skipped compile log checks this time for readability (if you do encounter issues, add the compile-checks! see previous code samples)
            uint vertexShader = gl.CreateShader(GL_VERTEX_SHADER);
            uint fragmentShaderOrange = gl.CreateShader(GL_FRAGMENT_SHADER); // the first fragment shader that outputs the color orange
            uint fragmentShaderYellow = gl.CreateShader(GL_FRAGMENT_SHADER); // the second fragment shader that outputs the color yellow
            uint shaderProgramOrange = gl.CreateProgram();
            uint shaderProgramYellow = gl.CreateProgram(); // the second shader program
            gl.ShaderSource(vertexShader, vertexShaderSource);
            gl.CompileShader(vertexShader);
            gl.ShaderSource(fragmentShaderOrange, fragmentShader1Source);
            gl.CompileShader(fragmentShaderOrange);
            gl.ShaderSource(fragmentShaderYellow, fragmentShader2Source);
            gl.CompileShader(fragmentShaderYellow);
            // link the first program object
            gl.AttachShader(shaderProgramOrange, vertexShader);
            gl.AttachShader(shaderProgramOrange, fragmentShaderOrange);
            gl.LinkProgram(shaderProgramOrange);
            // then link the second program object using a different fragment shader (but same vertex shader)
            // this is perfectly allowed since the inputs and outputs of both the vertex and fragment shaders are equally matched.
            gl.AttachShader(shaderProgramYellow, vertexShader);
            gl.AttachShader(shaderProgramYellow, fragmentShaderYellow);
            gl.LinkProgram(shaderProgramYellow);


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

                // now when we draw the triangle we first use the vertex and orange fragment shader from the first program
                gl.UseProgram(shaderProgramOrange);
                // draw the first triangle using the data from our first VAO
                gl.BindVertexArray(VAO[0]);
                gl.DrawArrays(GL_TRIANGLES, 0, 3);   // this call should output an orange triangle
                                                    // then we draw the second triangle using the data from the second VAO
                                                    // when we draw the second triangle we want to use a different shader program so we switch to the shader program with our yellow fragment shader.
                gl.UseProgram(shaderProgramYellow);
                gl.BindVertexArray(VAO[1]);
                gl.DrawArrays(GL_TRIANGLES, 0, 3);	// this call should output a yellow triangle



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
