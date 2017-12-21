using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glfw3
{
    public class State
    {
        public static int GLFW_FOCUSED
        {
            get
            {
                return 0x00020001;
            }
        }
        public static int GLFW_ICONIFIED
        {
            get
            {
                return 0x00020002;
            }
        }
        public static int GLFW_RESIZABLE
        {
            get
            {
                return 0x00020003;
            }
        }
        public static int GLFW_VISIBLE
        {
            get
            {
                return 0x00020004;
            }
        }
        public static int GLFW_DECORATED
        {
            get
            {
                return 0x00020005;
            }
        }
        public static int GLFW_AUTO_ICONIFY
        {
            get
            {
                return 0x00020006;
            }
        }
        public static int GLFW_FLOATING
        {
            get
            {
                return 0x00020007;
            }
        }
        public static int GLFW_MAXIMIZED
        {
            get
            {
                return 0x00020008;
            }
        }
        public static int GLFW_RED_BITS
        {
            get
            {
                return 0x00021001;
            }
        }
        public static int GLFW_GREEN_BITS
        {
            get
            {
                return 0x00021002;
            }
        }
        public static int GLFW_BLUE_BITS
        {
            get
            {
                return 0x00021003;
            }
        }
        public static int GLFW_ALPHA_BITS
        {
            get
            {
                return 0x00021004;
            }
        }
        public static int GLFW_DEPTH_BITS
        {
            get
            {
                return 0x00021005;
            }
        }
        public static int GLFW_STENCIL_BITS
        {
            get
            {
                return 0x00021006;
            }
        }
        public static int GLFW_ACCUM_RED_BITS
        {
            get
            {
                return 0x00021007;
            }
        }
        public static int GLFW_ACCUM_GREEN_BITS
        {
            get
            {
                return 0x00021008;
            }
        }
        public static int GLFW_ACCUM_BLUE_BITS
        {
            get
            {
                return 0x00021009;
            }
        }
        public static int GLFW_ACCUM_ALPHA_BITS
        {
            get
            {
                return 0x0002100A;
            }
        }
        public static int GLFW_AUX_BUFFERS
        {
            get
            {
                return 0x0002100B;
            }
        }
        public static int GLFW_STEREO
        {
            get
            {
                return 0x0002100C;
            }
        }
        public static int GLFW_SAMPLES
        {
            get
            {
                return 0x0002100D;
            }
        }
        public static int GLFW_SRGB_CAPABLE
        {
            get
            {
                return 0x0002100E;
            }
        }
        public static int GLFW_REFRESH_RATE
        {
            get
            {
                return 0x0002100F;
            }
        }
        public static int GLFW_DOUBLEBUFFER
        {
            get
            {
                return 0x00021010;
            }
        }
        public static int GLFW_CLIENT_API
        {
            get
            {
                return 0x00022001;
            }
        }
        public static int GLFW_CONTEXT_VERSION_MAJOR
        {
            get
            {
                return 0x00022002;
            }
        }
        public static int GLFW_CONTEXT_VERSION_MINOR
        {
            get
            {
                return 0x00022003;
            }
        }
        public static int GLFW_CONTEXT_REVISION
        {
            get
            {
                return 0x00022004;
            }
        }
        public static int GLFW_CONTEXT_ROBUSTNESS
        {
            get
            {
                return 0x00022005;
            }
        }
        public static int GLFW_OPENGL_FORWARD_COMPAT
        {
            get
            {
                return 0x00022006;
            }
        }
        public static int GLFW_OPENGL_DEBUG_CONTEXT
        {
            get
            {
                return 0x00022007;
            }
        }
        public static int GLFW_OPENGL_PROFILE
        {
            get
            {
                return 0x00022008;
            }
        }
        public static int GLFW_CONTEXT_RELEASE_BEHAVIOR
        {
            get
            {
                return 0x00022009;
            }
        }
        public static int GLFW_CONTEXT_NO_ERROR
        {
            get
            {
                return 0x0002200A;
            }
        }
        public static int GLFW_CONTEXT_CREATION_API
        {
            get
            {
                return 0x0002200B;
            }
        }
        public static int GLFW_NO_API
        {
            get
            {
                return 0;
            }
        }
        public static int GLFW_OPENGL_API
        {
            get
            {
                return 0x00030001;
            }
        }
        public static int GLFW_OPENGL_ES_API
        {
            get
            {
                return 0x00030002;
            }
        }
        public static int GLFW_NO_ROBUSTNESS
        {
            get
            {
                return 0;
            }
        }
        public static int GLFW_NO_RESET_NOTIFICATION
        {
            get
            {
                return 0x00031001;
            }
        }
        public static int GLFW_LOSE_CONTEXT_ON_RESET
        {
            get
            {
                return 0x00031002;
            }
        }
        public static int GLFW_OPENGL_ANY_PROFILE
        {
            get
            {
                return 0;
            }
        }
        public static int GLFW_OPENGL_CORE_PROFILE
        {
            get
            {
                return 0x00032001;
            }
        }
        public static int GLFW_OPENGL_COMPAT_PROFILE
        {
            get
            {
                return 0x00032002;
            }
        }
        public static int GLFW_CURSOR
        {
            get
            {
                return 0x00033001;
            }
        }
        public static int GLFW_STICKY_KEYS
        {
            get
            {
                return 0x00033002;
            }
        }
        public static int GLFW_STICKY_MOUSE_BUTTONS
        {
            get
            {
                return 0x00033003;
            }
        }
        public static int GLFW_CURSOR_NORMAL
        {
            get
            {
                return 0x00034001;
            }
        }
        public static int GLFW_CURSOR_HIDDEN
        {
            get
            {
                return 0x00034002;
            }
        }
        public static int GLFW_CURSOR_DISABLED
        {
            get
            {
                return 0x00034003;
            }
        }
        public static int GLFW_ANY_RELEASE_BEHAVIOR
        {
            get
            {
                return 0;
            }
        }
        public static int GLFW_RELEASE_BEHAVIOR_FLUSH
        {
            get
            {
                return 0x00035001;
            }
        }
        public static int GLFW_RELEASE_BEHAVIOR_NONE
        {
            get
            {
                return 0x00035002;
            }
        }
        public static int GLFW_NATIVE_CONTEXT_API
        {
            get
            {
                return 0x00036001;
            }
        }
        public static int GLFW_EGL_CONTEXT_API
        {
            get
            {
                return 0x00036002;
            }
        }
        public static int GLFW_CONNECTED
        {
            get
            {
                return 0x00040001;
            }
        }
        public static int GLFW_DISCONNECTED
        {
            get
            {
                return 0x00040002;
            }
        }
        public static int GLFW_DONT_CARE
        {
            get
            {
                return -1;
            }
        }
        public static int GLFW_TRUE
        {
            get
            {
                return 1;
            }
        }
        public static int GLFW_FALSE
        {
            get
            {
                return 0;
            }
        }
        public static int GLFW_RELEASE
        {
            get
            {
                return 0;
            }
        }
        public static int GLFW_PRESS
        {
            get
            {
                return 1;
            }
        }
        public static int GLFW_REPEAT
        {
            get
            {
                return 2;
            }
        }
    }

    public class KeyMacros
    {
        public static int GLFW_KEY_UNKNOWN
        {
            get
            {
                return -1;
            }
        }
        /* Printable keys */
        public static int GLFW_KEY_SPACE
        {
            get
            {
                return 32;
            }
        }
        public static int GLFW_KEY_APOSTROPHE
        {
            get
            {
                return 39;  /* ' */
            }
        }
        public static int GLFW_KEY_COMMA
        {
            get
            {
                return 44; /* , */
            }
        }
        public static int GLFW_KEY_MINUS
        {
            get
            {
                return 45;  /* - */
            }
        }
        public static int GLFW_KEY_PERIOD
        {
            get
            {
                return 46;  /* . */
            }
        }
        public static int GLFW_KEY_SLASH
        {
            get
            {
                return 47;  /* / */
            }
        }
        public static int GLFW_KEY_0
        {
            get
            {
                return 48;
            }
        }
        public static int GLFW_KEY_1
        {
            get
            {
                return 49;
            }
        }
        public static int GLFW_KEY_2
        {
            get
            {
                return 50;
            }
        }
        public static int GLFW_KEY_3
        {
            get
            {
                return 51;
            }
        }
        public static int GLFW_KEY_4
        {
            get
            {
                return 52;
            }
        }
        public static int GLFW_KEY_5
        {
            get
            {
                return 53;
            }
        }
        public static int GLFW_KEY_6
        {
            get
            {
                return 54;
            }
        }
        public static int GLFW_KEY_7
        {
            get
            {
                return 55;
            }
        }
        public static int GLFW_KEY_8
        {
            get
            {
                return 56;
            }
        }
        public static int GLFW_KEY_9
        {
            get
            {
                return 57;
            }
        }
        public static int GLFW_KEY_SEMICOLON
        {
            get
            {
                return 59;
            }
        }  /* ; */
        public static int GLFW_KEY_EQUAL
        {
            get
            {
                return 61;
            }
        }  /* = */
        public static int GLFW_KEY_A
        {
            get
            {
                return 65;
            }
        }
        public static int GLFW_KEY_B
        {
            get
            {
                return 66;
            }
        }
        public static int GLFW_KEY_C
        {
            get
            {
                return 67;
            }
        }
        public static int GLFW_KEY_D
        {
            get
            {
                return 68;
            }
        }
        public static int GLFW_KEY_E
        {
            get
            {
                return 69;
            }
        }
        public static int GLFW_KEY_F
        {
            get
            {
                return 70;
            }
        }
        public static int GLFW_KEY_G
        {
            get
            {
                return 71;
            }
        }
        public static int GLFW_KEY_H
        {
            get
            {
                return 72;
            }
        }
        public static int GLFW_KEY_I
        {
            get
            {
                return 73;
            }
        }
        public static int GLFW_KEY_J
        {
            get
            {
                return 74;
            }
        }
        public static int GLFW_KEY_K
        {
            get
            {
                return 75;
            }
        }
        public static int GLFW_KEY_L
        {
            get
            {
                return 76;
            }
        }
        public static int GLFW_KEY_M
        {
            get
            {
                return 77;
            }
        }
        public static int GLFW_KEY_N
        {
            get
            {
                return 78;
            }
        }
        public static int GLFW_KEY_O
        {
            get
            {
                return 79;
            }
        }
        public static int GLFW_KEY_P
        {
            get
            {
                return 80;
            }
        }
        public static int GLFW_KEY_Q
        {
            get
            {
                return 81;
            }
        }
        public static int GLFW_KEY_R
        {
            get
            {
                return 82;
            }
        }
        public static int GLFW_KEY_S
        {
            get
            {
                return 83;
            }
        }
        public static int GLFW_KEY_T
        {
            get
            {
                return 84;
            }
        }
        public static int GLFW_KEY_U
        {
            get
            {
                return 85;
            }
        }
        public static int GLFW_KEY_V
        {
            get
            {
                return 86;
            }
        }
        public static int GLFW_KEY_W
        {
            get
            {
                return 87;
            }
        }
        public static int GLFW_KEY_X
        {
            get
            {
                return 88;
            }
        }
        public static int GLFW_KEY_Y
        {
            get
            {
                return 89;
            }
        }
        public static int GLFW_KEY_Z
        {
            get
            {
                return 90;
            }
        }
        public static int GLFW_KEY_LEFT_BRACKET
        {
            get
            {
                return 91;
            }
        }  /* [ */
        public static int GLFW_KEY_BACKSLASH
        {
            get
            {
                return 92;
            }
        }  /* \ */
        public static int GLFW_KEY_RIGHT_BRACKET
        {
            get
            {
                return 93;
            }
        }  /* ] */
        public static int GLFW_KEY_GRAVE_ACCENT
        {
            get
            {
                return 96;
            }
        }  /* ` */
        public static int GLFW_KEY_WORLD_1
        {
            get
            {
                return 161;
            }
        } /* non-US #1 */
        public static int GLFW_KEY_WORLD_2
        {
            get
            {
                return 162;
            }
        } /* non-US #2 */

        /* Function keys */
        public static int GLFW_KEY_ESCAPE
        {
            get
            {
                return 256;
            }
        }
        public static int GLFW_KEY_ENTER
        {
            get
            {
                return 257;
            }
        }
        public static int GLFW_KEY_TAB
        {
            get
            {
                return 258;
            }
        }
        public static int GLFW_KEY_BACKSPACE
        {
            get
            {
                return 259;
            }
        }
        public static int GLFW_KEY_INSERT
        {
            get
            {
                return 260;
            }
        }
        public static int GLFW_KEY_DELETE
        {
            get
            {
                return 261;
            }
        }
        public static int GLFW_KEY_RIGHT
        {
            get
            {
                return 262;
            }
        }
        public static int GLFW_KEY_LEFT
        {
            get
            {
                return 263;
            }
        }
        public static int GLFW_KEY_DOWN
        {
            get
            {
                return 264;
            }
        }
        public static int GLFW_KEY_UP
        {
            get
            {
                return 265;
            }
        }
        public static int GLFW_KEY_PAGE_UP
        {
            get
            {
                return 266;
            }
        }
        public static int GLFW_KEY_PAGE_DOWN
        {
            get
            {
                return 267;
            }
        }
        public static int GLFW_KEY_HOME
        {
            get
            {
                return 268;
            }
        }
        public static int GLFW_KEY_END
        {
            get
            {
                return 269;
            }
        }
        public static int GLFW_KEY_CAPS_LOCK
        {
            get
            {
                return 280;
            }
        }
        public static int GLFW_KEY_SCROLL_LOCK
        {
            get
            {
                return 281;
            }
        }
        public static int GLFW_KEY_NUM_LOCK
        {
            get
            {
                return 282;
            }
        }
        public static int GLFW_KEY_PRINT_SCREEN
        {
            get
            {
                return 283;
            }
        }
        public static int GLFW_KEY_PAUSE
        {
            get
            {
                return 284;
            }
        }
        public static int GLFW_KEY_F1
        {
            get
            {
                return 290;
            }
        }
        public static int GLFW_KEY_F2
        {
            get
            {
                return 291;
            }
        }
        public static int GLFW_KEY_F3
        {
            get
            {
                return 292;
            }
        }
        public static int GLFW_KEY_F4
        {
            get
            {
                return 293;
            }
        }
        public static int GLFW_KEY_F5
        {
            get
            {
                return 294;
            }
        }
        public static int GLFW_KEY_F6
        {
            get
            {
                return 295;
            }
        }
        public static int GLFW_KEY_F7
        {
            get
            {
                return 296;
            }
        }
        public static int GLFW_KEY_F8
        {
            get
            {
                return 297;
            }
        }
        public static int GLFW_KEY_F9
        {
            get
            {
                return 298;
            }
        }
        public static int GLFW_KEY_F10
        {
            get
            {
                return 299;
            }
        }
        public static int GLFW_KEY_F11
        {
            get
            {
                return 300;
            }
        }
        public static int GLFW_KEY_F12
        {
            get
            {
                return 301;
            }
        }
        public static int GLFW_KEY_F13
        {
            get
            {
                return 302;
            }
        }
        public static int GLFW_KEY_F14
        {
            get
            {
                return 303;
            }
        }
        public static int GLFW_KEY_F15
        {
            get
            {
                return 304;
            }
        }
        public static int GLFW_KEY_F16
        {
            get
            {
                return 305;
            }
        }
        public static int GLFW_KEY_F17
        {
            get
            {
                return 306;
            }
        }
        public static int GLFW_KEY_F18
        {
            get
            {
                return 307;
            }
        }
        public static int GLFW_KEY_F19
        {
            get
            {
                return 308;
            }
        }
        public static int GLFW_KEY_F20
        {
            get
            {
                return 309;
            }
        }
        public static int GLFW_KEY_F21
        {
            get
            {
                return 310;
            }
        }
        public static int GLFW_KEY_F22
        {
            get
            {
                return 311;
            }
        }
        public static int GLFW_KEY_F23
        {
            get
            {
                return 312;
            }
        }
        public static int GLFW_KEY_F24
        {
            get
            {
                return 313;
            }
        }
        public static int GLFW_KEY_F25
        {
            get
            {
                return 314;
            }
        }
        public static int GLFW_KEY_KP_0
        {
            get
            {
                return 320;
            }
        }
        public static int GLFW_KEY_KP_1
        {
            get
            {
                return 321;
            }
        }
        public static int GLFW_KEY_KP_2
        {
            get
            {
                return 322;
            }
        }
        public static int GLFW_KEY_KP_3
        {
            get
            {
                return 323;
            }
        }
        public static int GLFW_KEY_KP_4
        {
            get
            {
                return 324;
            }
        }
        public static int GLFW_KEY_KP_5
        {
            get
            {
                return 325;
            }
        }
        public static int GLFW_KEY_KP_6
        {
            get
            {
                return 326;
            }
        }
        public static int GLFW_KEY_KP_7
        {
            get
            {
                return 327;
            }
        }
        public static int GLFW_KEY_KP_8
        {
            get
            {
                return 328;
            }
        }
        public static int GLFW_KEY_KP_9
        {
            get
            {
                return 329;
            }
        }
        public static int GLFW_KEY_KP_DECIMAL
        {
            get
            {
                return 330;
            }
        }
        public static int GLFW_KEY_KP_DIVIDE
        {
            get
            {
                return 331;
            }
        }
        public static int GLFW_KEY_KP_MULTIPLY
        {
            get
            {
                return 332;
            }
        }
        public static int GLFW_KEY_KP_SUBTRACT
        {
            get
            {
                return 333;
            }
        }
        public static int GLFW_KEY_KP_ADD
        {
            get
            {
                return 334;
            }
        }
        public static int GLFW_KEY_KP_ENTER
        {
            get
            {
                return 335;
            }
        }
        public static int GLFW_KEY_KP_EQUAL
        {
            get
            {
                return 336;
            }
        }
        public static int GLFW_KEY_LEFT_SHIFT
        {
            get
            {
                return 340;
            }
        }
        public static int GLFW_KEY_LEFT_CONTROL
        {
            get
            {
                return 341;
            }
        }
        public static int GLFW_KEY_LEFT_ALT
        {
            get
            {
                return 342;
            }
        }
        public static int GLFW_KEY_LEFT_SUPER
        {
            get
            {
                return 343;
            }
        }
        public static int GLFW_KEY_RIGHT_SHIFT
        {
            get
            {
                return 344;
            }
        }
        public static int GLFW_KEY_RIGHT_CONTROL
        {
            get
            {
                return 345;
            }
        }
        public static int GLFW_KEY_RIGHT_ALT
        {
            get
            {
                return 346;
            }
        }
        public static int GLFW_KEY_RIGHT_SUPER
        {
            get
            {
                return 347;
            }
        }
        public static int GLFW_KEY_MENU
        {
            get
            {
                return 348;
            }
        }
    }

    public class Version
    {
        public static int GLFW_VERSION_MAJOR
        {
            get
            {
                return 3; 
            }
        }
        /*! @brief The minor version number of the GLFW library.
         *
         *  This is incremented when features are added to the API but it remains
         *  backward-compatible.
         *  @ingroup init
         */
        public static int GLFW_VERSION_MINOR
        {
            get
            {
                return 2;
            }
        }
        /*! @brief The revision number of the GLFW library.
         *
         *  This is incremented when a bug fix release is made that does not contain any
         *  API changes.
         *  @ingroup init
         */
        public static int GLFW_VERSION_REVISION
        {
            get
            {
                return 1;
            }
        }
    }

    public class MouseMacros
    {
        public static int GLFW_MOUSE_BUTTON_1
        {
            get
            {
                return 0;
            }
        }
        public static int GLFW_MOUSE_BUTTON_2
        {
            get
            {
                return 1;
            }
        }
        public static int GLFW_MOUSE_BUTTON_3
        {
            get
            {
                return 2;
            }
        }
        public static int GLFW_MOUSE_BUTTON_4
        {
            get
            {
                return 3;
            }
        }
        public static int GLFW_MOUSE_BUTTON_5
        {
            get
            {
                return 4;
            }
        }
        public static int GLFW_MOUSE_BUTTON_6
        {
            get
            {
                return 5;
            }
        }
        public static int GLFW_MOUSE_BUTTON_7
        {
            get
            {
                return 6;
            }
        }
        public static int GLFW_MOUSE_BUTTON_8
        {
            get
            {
                return 7;
            }
        }
        public static int GLFW_MOUSE_BUTTON_LAST
        {
            get
            {
                return GLFW_MOUSE_BUTTON_8;
            }
        }
        public static int GLFW_MOUSE_BUTTON_LEFT
        {
            get
            {
                return GLFW_MOUSE_BUTTON_1;
            }
        }
        public static int GLFW_MOUSE_BUTTON_RIGHT
        {
            get
            {
                return GLFW_MOUSE_BUTTON_2;
            }
        }
        public static int GLFW_MOUSE_BUTTON_MIDDLE
        {
            get
            {
                return GLFW_MOUSE_BUTTON_3;
            }
        }
    }

    public class JoystickMacros
    {
        public static int GLFW_JOYSTICK_1
        {
            get
            {
                return 0;
            }
        }
        public static int GLFW_JOYSTICK_2
        {
            get
            {
                return 1;
            }
        }
        public static int GLFW_JOYSTICK_3
        {
            get
            {
                return 2;
            }
        }
        public static int GLFW_JOYSTICK_4
        {
            get
            {
                return 3;
            }
        }
        public static int GLFW_JOYSTICK_5
        {
            get
            {
                return 4;
            }
        }
        public static int GLFW_JOYSTICK_6
        {
            get
            {
                return 5;
            }
        }
        public static int GLFW_JOYSTICK_7
        {
            get
            {
                return 6;
            }
        }
        public static int GLFW_JOYSTICK_8
        {
            get
            {
                return 7;
            }
        }
        public static int GLFW_JOYSTICK_9
        {
            get
            {
                return 8;
            }
        }
        public static int GLFW_JOYSTICK_10
        {
            get
            {
                return 9;
            }
        }
        public static int GLFW_JOYSTICK_11
        {
            get
            {
                return 10;
            }
        }
        public static int GLFW_JOYSTICK_12
        {
            get
            {
                return 11;
            }
        }
        public static int GLFW_JOYSTICK_13
        {
            get
            {
                return 12;
            }
        }
        public static int GLFW_JOYSTICK_14
        {
            get
            {
                return 13;
            }
        }
        public static int GLFW_JOYSTICK_15
        {
            get
            {
                return 14;
            }
        }
        public static int GLFW_JOYSTICK_16
        {
            get
            {
                return 15;
            }
        }
        public static int GLFW_JOYSTICK_LAST
        {
            get
            {
                return GLFW_JOYSTICK_16;
            }
        }
    }
}
