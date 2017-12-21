using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformations
{
    using glfw3;
    using static glfw3.glfw3;
    using static glfw3.KeyMacros;
    using static glfw3.State;
    using SharpGL;
    using static SharpGL.OpenGL;
    using System.Runtime.InteropServices;
    using RenderExt;
    using GlmSharp;

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

            // configure global opengl state
            // -----------------------------
            gl.Enable(GL_DEPTH_TEST);

            // render loop
            // -----------
            Shader shader = new Shader("6.2.coordinate_systems.vert", "6.2.coordinate_systems.frag", gl);
            // set up vertex data (and buffer(s)) and configure vertex attributes
            // ------------------------------------------------------------------
            float[] vertices = {
                // positions            // texture coords
                  -0.5f, -0.5f, -0.5f,  0.0f, 0.0f,
                   0.5f, -0.5f, -0.5f,  1.0f, 0.0f,
                   0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
                   0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
                  -0.5f,  0.5f, -0.5f,  0.0f, 1.0f,
                  -0.5f, -0.5f, -0.5f,  0.0f, 0.0f,

                  -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,
                   0.5f, -0.5f,  0.5f,  1.0f, 0.0f,
                   0.5f,  0.5f,  0.5f,  1.0f, 1.0f,
                   0.5f,  0.5f,  0.5f,  1.0f, 1.0f,
                  -0.5f,  0.5f,  0.5f,  0.0f, 1.0f,
                  -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,

                  -0.5f,  0.5f,  0.5f,  1.0f, 0.0f,
                  -0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
                  -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
                  -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
                  -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,
                  -0.5f,  0.5f,  0.5f,  1.0f, 0.0f,

                   0.5f,  0.5f,  0.5f,  1.0f, 0.0f,
                   0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
                   0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
                   0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
                   0.5f, -0.5f,  0.5f,  0.0f, 0.0f,
                   0.5f,  0.5f,  0.5f,  1.0f, 0.0f,

                  -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
                   0.5f, -0.5f, -0.5f,  1.0f, 1.0f,
                   0.5f, -0.5f,  0.5f,  1.0f, 0.0f,
                   0.5f, -0.5f,  0.5f,  1.0f, 0.0f,
                  -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,
                  -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,

                  -0.5f,  0.5f, -0.5f,  0.0f, 1.0f,
                   0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
                   0.5f,  0.5f,  0.5f,  1.0f, 0.0f,
                   0.5f,  0.5f,  0.5f,  1.0f, 0.0f,
                  -0.5f,  0.5f,  0.5f,  0.0f, 0.0f,
                  -0.5f,  0.5f, -0.5f,  0.0f, 1.0f
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
            gl.VertexAttribPointer(0, 3, GL_FLOAT, false, 5 * sizeof(float), IntPtr.Zero);
            gl.EnableVertexAttribArray(0);
            // texture coord attribute
            gl.VertexAttribPointer(1, 2, GL_FLOAT, false, 5 * sizeof(float), new IntPtr(3 * sizeof(float)));
            gl.EnableVertexAttribArray(1);



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
            uint texture1 = Texture.LoadTexture("wall_orange_01.dds", gl);
            uint texture2 = Texture.LoadTexture("awesomeface.png", gl);

            mat4 view = mat4.Translate(new vec3(0.0f, 0.0f, -3.0f));
            mat4 projection = mat4.Perspective(glm.Radians(45.0f), (float)width / (float)hight, 0.1f, 100.0f);
            mat4 model = mat4.Identity;
            while (GlfwWindowShouldClose(window) != GLFW_TRUE)
            {
                // input
                // -----
                processInput(window);

                // render
                // ------
                gl.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
                gl.Clear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

                // bind textures on corresponding texture units
                gl.ActiveTexture(GL_TEXTURE0);
                gl.BindTexture(GL_TEXTURE_2D, texture1);
                gl.ActiveTexture(GL_TEXTURE1);
                gl.BindTexture(GL_TEXTURE_2D, texture2);


                // create transformations
                //model*= mat4.Rotate(glm.Radians(-55.0f), new vec3(1.0f, 0.0f, 0.0f));
                model= mat4.Rotate((float)GlfwGetTime(), new vec3(1.0f, 0.0f, 0.0f));


                // retrieve the matrix uniform locations
                shader.SetMat4("model", model);
                shader.SetMat4("view", view);
                shader.SetMat4("projection", projection);


                // draw our object
                shader.Use();
                gl.BindVertexArray(VAO[0]); // seeing as we only have a single VAO there's no need to bind it every time, but we'll do so to keep things a bit more organized
                gl.DrawArrays(GL_TRIANGLES, 0, 36);
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
