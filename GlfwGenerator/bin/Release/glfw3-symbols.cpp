#include <glfw3.h>

extern "C" { void glfw3_symbols1(void* instance) { new (instance) GLFWvidmode(); } }
extern "C" { void glfw3_symbols2(void* instance, const GLFWvidmode& _0) { new (instance) GLFWvidmode(_0); } }
GLFWvidmode& (GLFWvidmode::*glfw3_symbols3)(const GLFWvidmode&) = &GLFWvidmode::operator=;
GLFWvidmode& (GLFWvidmode::*glfw3_symbols4)(GLFWvidmode&&) = &GLFWvidmode::operator=;
extern "C" { void glfw3_symbols5(GLFWvidmode* instance) { instance->~GLFWvidmode(); } }
extern "C" { void glfw3_symbols6(void* instance) { new (instance) GLFWgammaramp(); } }
extern "C" { void glfw3_symbols7(void* instance, const GLFWgammaramp& _0) { new (instance) GLFWgammaramp(_0); } }
GLFWgammaramp& (GLFWgammaramp::*glfw3_symbols8)(const GLFWgammaramp&) = &GLFWgammaramp::operator=;
GLFWgammaramp& (GLFWgammaramp::*glfw3_symbols9)(GLFWgammaramp&&) = &GLFWgammaramp::operator=;
extern "C" { void glfw3_symbols10(GLFWgammaramp* instance) { instance->~GLFWgammaramp(); } }
extern "C" { void glfw3_symbols11(void* instance) { new (instance) GLFWimage(); } }
extern "C" { void glfw3_symbols12(void* instance, const GLFWimage& _0) { new (instance) GLFWimage(_0); } }
GLFWimage& (GLFWimage::*glfw3_symbols13)(const GLFWimage&) = &GLFWimage::operator=;
GLFWimage& (GLFWimage::*glfw3_symbols14)(GLFWimage&&) = &GLFWimage::operator=;
extern "C" { void glfw3_symbols15(GLFWimage* instance) { instance->~GLFWimage(); } }
extern "C" { void glfw3_symbols16(void* instance) { new (instance) GLFWgamepadstate(); } }
extern "C" { void glfw3_symbols17(void* instance, const GLFWgamepadstate& _0) { new (instance) GLFWgamepadstate(_0); } }
GLFWgamepadstate& (GLFWgamepadstate::*glfw3_symbols18)(const GLFWgamepadstate&) = &GLFWgamepadstate::operator=;
GLFWgamepadstate& (GLFWgamepadstate::*glfw3_symbols19)(GLFWgamepadstate&&) = &GLFWgamepadstate::operator=;
extern "C" { void glfw3_symbols20(GLFWgamepadstate* instance) { instance->~GLFWgamepadstate(); } }
