using UnityEngine;
using UnityStandardAssets.Cameras;

namespace the6th.EasyVRStudio
{
    [RequireComponent(typeof(Camera))]
    [RequireComponent(typeof(AutoCam))]
    public class CameraForDisplay : MonoBehaviour
    {
        [SerializeField]
        MeshRenderer cameraRenderer;
        [SerializeField]
        GameObject headModelPrefab;

        [Header("VR Controlls")]
        [SerializeField]
        Transform Head;
        [SerializeField]
        Transform Hand_R;
        [SerializeField]
        Transform Hand_L;


        private GameObject headModel = null;
        private AutoCam autoCam = null;
        private Camera vCamera = null;
        private Camera hmdCamera = null;
        private DisplayCamera[] displayCameras = null;

        private void Awake()
        {
            //Windows以外は無効にする
#if !UNITY_STANDALONE_WIN
            Destroy(gameObject);
#endif
            displayCameras = Config.displayCameras;

            vCamera = GetComponent<Camera>();
            autoCam = GetComponent<AutoCam>();
        }

        private void Start()
        {
            hmdCamera = Camera.main;

            if (Head == null) Head = hmdCamera.transform;
            if (Hand_R == null) Hand_R = hmdCamera.transform;
            if (Hand_L == null) Hand_L = hmdCamera.transform;

            foreach (var c in displayCameras)
            {
                if (c.Parent == CameraParent.HEAD && c.Position == Vector3.zero && c.EulerAngles == Vector3.zero)
                {
                    c.SetTransform(hmdCamera.transform);
                }
                else
                {
                    var campos = new GameObject(c.Name).transform;
                    campos.SetParent(GetParent(c.Parent));
                    campos.localPosition = c.Position;
                    campos.localEulerAngles = c.EulerAngles;
                    c.SetTransform(campos);
                }
            }

            ChangeCameraPosition(displayCameras[displayCameras.Length - 1]);
        }

        private void OnEnable()
        {
            UnityEngine.XR.XRSettings.showDeviceView = false;
        }
        private void OnDisable()
        {
            UnityEngine.XR.XRSettings.showDeviceView = true;
        }

        private void Update()
        {
            foreach (var c in displayCameras)
            {
                if (Input.GetKeyDown(c.Keycode))
                {
                    ChangeCameraPosition(c);
                }
            }
        }

        private Transform GetParent(CameraParent parent)
        {
            Debug.Log($"GetParent:{parent.ToString()}");
            switch (parent)
            {
                case CameraParent.HAND_R:
                    return Hand_R;

                case CameraParent.HAND_L:
                    return Hand_L;

                default:
                    return Head;
            }
        }

        private void ChangeCameraPosition(DisplayCamera dCamera)
        {
            if (dCamera.Transform != hmdCamera.transform)
            {
                if (headModel == null && headModelPrefab !=null)
                {
                    headModel = GameObject.Instantiate(headModelPrefab, hmdCamera.transform);
                }

                UnityEngine.XR.XRSettings.showDeviceView = false;
                vCamera.enabled = true;
                autoCam.SetTarget(dCamera.Transform);
                cameraRenderer.enabled = true;
            }
            else
            {
                UnityEngine.XR.XRSettings.showDeviceView = true;
                vCamera.enabled = false;
                cameraRenderer.enabled = false;
            }
        }
    }
}
