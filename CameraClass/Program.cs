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
        static Camera camera= new Camera(new vec3(0.0f, 0.0f, 3.0f),new vec3(0.0f, 0.0f, -1.0f));
        static float lastX = width / 2.0f;
        static float lastY = hight / 2.0f;
        static bool firstMouse = true;

        // timing
        static float deltaTime = 0.0f; // time between current frame and last frame
        static float lastFrame = 0.0f;

        
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

            GlfwSetFramebufferSizeCallback(window, framebuffer_size_callback);
            GlfwSetCursorPosCallback(window, mouse_callback);
            GlfwSetScrollCallback(window, scroll_callback);
            // tell GLFW to capture our mouse
            GlfwSetInputMode(window, GLFW_CURSOR, GLFW_CURSOR_DISABLED);


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

           
            // world space positions of our cubes
            vec3[] cubePositions = {
                 new vec3( 0.0f,  0.0f,  0.0f),
                 new vec3( 2.0f,  5.0f, -15.0f),
                 new vec3(-1.5f, -2.2f, -2.5f),
                 new vec3(-3.8f, -2.0f, -12.3f),
                 new vec3( 2.4f, -0.4f, -3.5f),
                 new vec3(-1.7f,  3.0f, -7.5f),
                 new vec3( 1.3f, -2.0f, -2.5f),
                 new vec3( 1.5f,  2.0f, -2.5f),
                 new vec3( 1.5f,  0.2f, -1.5f),
                 new vec3(-1.3f,  1.0f, -1.5f)
            };

            while (GlfwWindowShouldClose(window) != GLFW_TRUE)
            {
                // per-frame time logic
                // --------------------
                float currentFrame =(float) GlfwGetTime();
                deltaTime = currentFrame - lastFrame;
                lastFrame = currentFrame;

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

                shader.Use();
                mat4 view = camera.GetViewMatrix();
                mat4 projection = mat4.Perspective(glm.Radians(camera.Zoom), (float)width / (float)hight, 0.1f, 100.0f);
                mat4 model = mat4.Identity;

                // retrieve the matrix uniform locations
                shader.SetMat4("view", view);
                shader.SetMat4("projection", projection);


                // render boxes
                gl.BindVertexArray(VAO[0]);
                for (uint i = 0; i < cubePositions.Length; i++)
                {
                    // calculate the model matrix for each object and pass it to shader before drawing
                    model = mat4.Translate(cubePositions[i]);
                    float angle = 20.0f * i;
                    model *= mat4.Rotate(glm.Radians(angle), new vec3(1.0f, 0.3f, 0.5f));
                    shader.SetMat4("model", model);

                    gl.DrawArrays(GL_TRIANGLES, 0, 36);
                }


                // Glfw.: swap buffers and poll IO events (keys pressed/released, mouse moved etc.)
                // -------------------------------------------------------------------------------
                GlfwSwapBuffers(window);
                GlfwPollEvents();
                show_fps(window);

            }

            // optional: de-allocate all resources once they've outlived their purpose:
            // ------------------------------------------------------------------------
            gl.DeleteVertexArrays(1, VAO);
            gl.DeleteBuffers(1, VBO);
            // Glfw.: terminate, clearing all previously allocated Glfw. resources.
            // ------------------------------------------------------------------
            GlfwTerminate();
            return 0;
        }

        static int num_frames = 0;
        static int last_time = 0;

        static void show_fps(GLFWwindow window)
        {
            // Measure speed
            double current_time = GlfwGetTime();
            double delta = current_time - last_time;
            num_frames++;
            if (delta >= 1.0)
            { // If last cout was more than 1 sec ago
              //cout<< "num_frames: "<<num_frames<<endl;
              //cout << 1000.0/double(num_frames) << endl;
                double fps = num_frames / delta;
                String ss = "GLFW Proba" + " [" + fps + " FPS]";
                GlfwSetWindowTitle(window, ss);
                num_frames = 0;
                last_time = (int)current_time;
            }
        }

        // process all input: query Glfw. whether relevant keys are pressed/released this frame and react accordingly
        // ---------------------------------------------------------------------------------------------------------
        static void processInput(GLFWwindow window)
        {
            if (GlfwGetKey(window, GLFW_KEY_ESCAPE) == GLFW_PRESS)
                GlfwSetWindowShouldClose(window, GLFW_TRUE);

            if (GlfwGetKey(window, GLFW_KEY_W) == GLFW_PRESS)
                camera.ProcessKeyboard(Movement.FORWARD, deltaTime);
            if (GlfwGetKey(window, GLFW_KEY_S) == GLFW_PRESS)
                camera.ProcessKeyboard(Movement.BACKWARD, deltaTime);
            if (GlfwGetKey(window, GLFW_KEY_A) == GLFW_PRESS)
                camera.ProcessKeyboard(Movement.LEFT, deltaTime);
            if (GlfwGetKey(window, GLFW_KEY_D) == GLFW_PRESS)
                camera.ProcessKeyboard(Movement.RIGHT, deltaTime);

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

        // glfw: whenever the mouse moves, this callback is called
        // -------------------------------------------------------
        static void mouse_callback(IntPtr window, double xpos, double ypos)
        {

            
            if (firstMouse)
            {
                lastX = (float) xpos;
                lastY = (float) ypos;
                firstMouse = false;
            }

            float xoffset = (float) xpos - lastX;
            float yoffset = lastY - (float)ypos; // reversed since y-coordinates go from bottom to top

            lastX = (float)xpos;
            lastY = (float)ypos;

            camera.ProcessMouseMovement(xoffset, yoffset);
        }

        // glfw: whenever the mouse scroll wheel scrolls, this callback is called
        // ----------------------------------------------------------------------
        static void scroll_callback(IntPtr window, double xoffset, double yoffset)
        {
            camera.ProcessMouseScroll((float)yoffset);
        }
    }
}
