using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlmSharp;

namespace RenderExt
{
    public enum Movement
    {
        FORWARD,
        BACKWARD,
        LEFT,
        RIGHT
    }

    

    public class Camera
    {
        static vec3 DefaultFront = new vec3(0.0f, 0.0f, -1.0f);
        // Eular Angle
        float Yaw ;
        float Pitch;
        // Camera options
        float MovementSpeed = 2.5f;
        float MouseSensitivity = 0.1f;
        public float Zoom
        {
            get;
            private set;
        } = 45.0f;

        // Camera Attributes
        vec3 Position;
        vec3 Front;
        vec3 WorldUp = new vec3(0.0f, 1.0f, 0.0f);
        vec3 Right;
        vec3 Up;

       
        // Constructor with vectors
        public Camera(vec3 position, vec3 Front , float yaw= -90.0f, float pitch = 0.0f)
        {
            if (position != null)
            {
                Position = position;
            }
            this.Front = Front;
            Yaw = yaw;
            Pitch = pitch;
            UpdateCameraVectors();
        }
        // Constructor with scalar values
        public Camera(float posX, float posY, float posZ, float upX, float upY, float upZ, float yaw, float pitch)
        {
            Position = new vec3(posX, posY, posZ);
            Up = new vec3(upX, upY, upZ);
            Yaw = yaw;
            Pitch = pitch;
            UpdateCameraVectors();
        }

        // Returns the view matrix calculated using Eular Angles and the LookAt Matrix
        public mat4 GetViewMatrix()
        {
            return mat4.LookAt(Position, Position + Front, Up);
        }

        // Processes input received from any keyboard-like input system. Accepts input parameter in the form of camera defined ENUM (to abstract it from windowing systems)
        public void ProcessKeyboard(Movement direction, float deltaTime)
        {
            float velocity = MovementSpeed * deltaTime;
            if (direction == Movement.FORWARD)
            {
                Position += Front * velocity;
            }
            if (direction == Movement.BACKWARD)
            {
                Position -= Front * velocity;
            }
            if (direction == Movement.LEFT)
            {
                Position -= Right * velocity;
            }
            if (direction == Movement.RIGHT)
            {
                Position += Right * velocity;
            }
        }

        // Processes input received from a mouse input system. Expects the offset value in both the x and y direction.
        public void ProcessMouseMovement(float xoffset, float yoffset, bool constrainPitch = true)
        {
            xoffset *= MouseSensitivity;
            yoffset *= MouseSensitivity;

            Yaw += xoffset;
            Pitch += yoffset;

            // Make sure that when pitch is out of bounds, screen doesn't get flipped
            if (constrainPitch)
            {
                if (Pitch > 89.0f)
                {
                    Pitch = 89.0f;
                }
                   
                if (Pitch < -89.0f)
                {
                    Pitch = -89.0f;
                }
                    
            }

            // Update Front, Right and Up Vectors using the updated Eular angles
            UpdateCameraVectors();
        }

        // Processes input received from a mouse scroll-wheel event. Only requires input on the vertical wheel-axis
        public void ProcessMouseScroll(float yoffset)
        {
            if (Zoom >= 1.0f && Zoom <= 45.0f)
                Zoom -= yoffset;
            if (Zoom <= 1.0f)
                Zoom = 1.0f;
            if (Zoom >= 45.0f)
                Zoom = 45.0f;
        }

        // Calculates the front vector from the Camera's (updated) Eular Angles
        void UpdateCameraVectors()
        {
            // Calculate the new Front vector
            vec3 front;
            front.x = (float) Math.Cos(glm.Radians(Yaw)) * (float) Math.Cos(glm.Radians(Pitch));
            front.y = (float) Math.Sin(glm.Radians(Pitch));
            front.z = (float) Math.Sin(glm.Radians(Yaw)) * (float) Math.Cos(glm.Radians(Pitch));
            Front = front.Normalized;
            // Also re-calculate the Right and Up vector
            Right = (glm.Cross(Front, WorldUp)).Normalized;  // Normalize the vectors, because their length gets closer to 0 the more you look up or down which results in slower movement.
            Up = (glm.Cross(Right, Front)).Normalized;
        }

    }
}
