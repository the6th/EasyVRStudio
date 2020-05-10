using UnityEngine;

namespace the6th.EasyVRStudio
{
    public class Config
    {
        public static DisplayCamera[] displayCameras = new DisplayCamera[6]
        {
            new DisplayCamera(
                name: "vCenter",
                parent: CameraParent.HEAD,
                position: Vector3.zero,
                eulerAngles: new Vector3(10f,0,0),
                keyCode: KeyCode.F1
                ),

            new DisplayCamera(
                name: "vFront",
                parent: CameraParent.HEAD,
                position: new Vector3(0f,0f,1.2f),
                eulerAngles: new Vector3(20f,180f,0),
                keyCode: KeyCode.F2
                ),

            new DisplayCamera(
                name: "vTop",
                parent: CameraParent.HEAD,
                position: new Vector3(0f,0.217f,0.504f),
                eulerAngles: new Vector3(92.8f,0,0),
                keyCode: KeyCode.F3
                ),

            new DisplayCamera(
                name: "rHand",
                parent: CameraParent.HAND_R,
                position: new Vector3(-0.03f,-0.05f,0.01f),
                eulerAngles: new Vector3(-10f,-100f,-93f),
                keyCode: KeyCode.F4
                ),

            new DisplayCamera(
                name: "lHand",
                parent: CameraParent.HAND_L,
                position: new Vector3(0.03f,-0.05f,-0.01f),
                eulerAngles: new Vector3(10f,100f,93f),
                keyCode: KeyCode.F5
                ),

            new DisplayCamera(
                name: "vNone",
                parent: CameraParent.HEAD,
                position: Vector3.zero,
                eulerAngles: Vector3.zero,
                keyCode: KeyCode.F6
                ),
        };
    }
}