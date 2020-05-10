using System;
using UnityEngine;

namespace the6th.EasyVRStudio
{
    public enum CameraParent
    {
        HEAD,
        HAND_R,
        HAND_L
    }

    [Serializable]
    public class DisplayCamera
    {
        public string Name { private set; get; }
        public CameraParent Parent { private set; get; }
        public Vector3 Position { private set; get; }
        public Vector3 EulerAngles { private set; get; }
        public KeyCode Keycode { private set; get; }
        public Transform Transform { private set; get; }

        public DisplayCamera(string name, CameraParent parent, Vector3 position, Vector3 eulerAngles, KeyCode keyCode)
        {
            Name = name;
            Position = position;
            EulerAngles = eulerAngles;
            Keycode = keyCode;
            Parent = parent;
        }

        public void SetTransform(Transform t)
        {
            Transform = t;
        }

    }
}
