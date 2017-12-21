using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWindow
{
    using glfw3;
    using static glfw3.glfw3;
    using static glfw3.KeyMacros;
    using static glfw3.State;
    using SharpGL;
    using static SharpGL.OpenGL;

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
            while (GlfwWindowShouldClose(window) != GLFW_TRUE)
            {
                // input
                // -----
                processInput(window);

                // glfw: swap buffers and poll IO events (keys pressed/released, mouse moved etc.)
                // -------------------------------------------------------------------------------
                GlfwSwapBuffers(window);
                GlfwPollEvents();
            }

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
            //Console.WriteLine("glViewport(0, 0, width, height);");
        }
    }
}
