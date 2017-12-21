using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textures
{
    using glfw3;
    using static glfw3.glfw3;
    using static glfw3.KeyMacros;
    using static glfw3.State;
    using SharpGL;
    using static SharpGL.OpenGL;
    using System.Runtime.InteropServices;
    using RenderExt;
    //Adjust the vertex shader so that the triangle is upside down
    class Program
    {
        static int width = 1366;
        static int hight = 768;
        static OpenGL gl = new OpenGL();

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
            Shader shader = new Shader("texture.vert", "texture.frag", gl);
            // set up vertex data (and buffer(s)) and configure vertex attributes
            // ------------------------------------------------------------------
            float[] vertices = {
                // positions          // colors           // texture coords
                  0.5f,  0.5f, 0.0f,   1.0f, 0.0f, 0.0f,   1.0f, 1.0f, // top right
                  0.5f, -0.5f, 0.0f,   0.0f, 1.0f, 0.0f,   1.0f, 0.0f, // bottom right
                 -0.5f, -0.5f, 0.0f,   0.0f, 0.0f, 1.0f,   0.0f, 0.0f, // bottom left
                 -0.5f,  0.5f, 0.0f,   1.0f, 1.0f, 0.0f,   0.0f, 1.0f  // top left 
            };
            int[] indices = {
                 0, 1, 3, // first triangle
                 1, 2, 3  // second triangle
            };


            uint[] VBO, VAO, EBO;
            VBO = new uint[1];
            VAO = new uint[1];
            EBO = new uint[1];
            gl.GenVertexArrays(1, VAO);
            gl.GenBuffers(1, VBO);
            gl.GenBuffers(1, EBO);

            // bind the Vertex Array Object first, then bind and set vertex buffer(s), and then configure vertex attributes(s).
            gl.BindVertexArray(VAO[0]);

            gl.BindBuffer(GL_ARRAY_BUFFER, VBO[0]);
            gl.BufferData(GL_ARRAY_BUFFER, vertices, GL_STATIC_DRAW);

            gl.BindBuffer(GL_ELEMENT_ARRAY_BUFFER, EBO[0]);
            //////////////////////////Marshaling///////////////////////////////////////////
            IntPtr p = Marshal.AllocHGlobal(indices.Length * sizeof(int));
            Marshal.Copy(indices, 0, p, indices.Length);
            gl.BufferData(GL_ELEMENT_ARRAY_BUFFER, indices.Length * sizeof(float), p, GL_STATIC_DRAW);
            Marshal.FreeHGlobal(p);
            //////////////////////////////////////////////////////////////////////////////

            // position attribute
            gl.VertexAttribPointer(0, 3, GL_FLOAT,false, 8 * sizeof(float), IntPtr.Zero);
            gl.EnableVertexAttribArray(0);
            // color attribute
            gl.VertexAttribPointer(1, 3, GL_FLOAT, false, 8 * sizeof(float),new IntPtr(3 * sizeof(float)));
            gl.EnableVertexAttribArray(1);
            // texture coord attribute
            gl.VertexAttribPointer(2, 2, GL_FLOAT, false, 8 * sizeof(float), new IntPtr(6 * sizeof(float)));
            gl.EnableVertexAttribArray(2);



            // note that this is allowed, the call to glVertexAttribPointer registered VBO
            //as the vertex attribute's bound vertex buffer object so afterwards we can safely unbind
            gl.BindBuffer(GL_ARRAY_BUFFER, 0);

            // You can unbind the VAO afterwards so other VAO calls won't accidentally modify this VAO, but this 
            //rarely happens. Modifying other
            // VAOs requires a call to glBindVertexArray anyways so we generally don't unbind VAOs (nor VBOs)
            //when it's not directly necessary.
            gl.BindVertexArray(0);


            // uncomment this call to draw in wireframe polygons.
            //glPolygonMode(GL_FRONT_AND_BACK, GL_LINE);

            // load and create a texture 
            // -------------------------
            uint texture = Texture.LoadTexture("wall_orange_01.dds", gl);

            while (GlfwWindowShouldClose(window) != GLFW_TRUE)
            {
                // input
                // -----
                processInput(window);

                // render
                // ------
                gl.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
                gl.Clear(GL_COLOR_BUFFER_BIT);

                // bind Texture
                gl.BindTexture(GL_TEXTURE_2D, texture);

                // draw our first triangle
                shader.Use();
                gl.BindVertexArray(VAO[0]); // seeing as we only have a single VAO there's no need to bind it every time, but we'll do so to keep things a bit more organized
                gl.DrawElements(GL_TRIANGLES, 6, GL_UNSIGNED_INT, IntPtr.Zero);
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
