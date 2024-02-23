using UnityEngine;
using NaughtyAttributes;

namespace Scripts.Player
{
    public class FirstPersonCameraController : MonoBehaviour
    {
        [Foldout("Components")]
        [SerializeField] private Camera _camera;
        [Foldout("Components")]
        [SerializeField] private Transform _cameraTransform;

        [Foldout("RotateVariables")]
        [SerializeField] private Vector2 _mouseDelta = Vector2.zero;
        [Foldout("RotateVariables")]
        [SerializeField] private Vector2 _senstivity = Vector2.one;

        private float _mouseClampValue = 0.75f;

        private Vector2 _lastMousePos = Vector2.zero;
        private Vector2 _currentMousePos = Vector2.zero;
        private Vector3 _parentRotation = Vector3.zero;

        private Quaternion _initCameraRotation;

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            SetInput();
            HandleRotation();
        }


        ///This avoids having the drag-drop to refer.
        //And since we can call it in editor time, when creating an asset, no issues with performance.
        private void Reset()
        {
            _camera = GetComponentInChildren<Camera>();
            _cameraTransform = _camera.transform;
        }

        private void Initialize()
        {
            _parentRotation = transform.rotation.eulerAngles;
            _lastMousePos = Input.mousePosition;
            _initCameraRotation = _camera.transform.rotation;
        }

        private void SetInput()
        {
           /* _currentMousePos = Input.mousePosition;
            _mouseDelta = _currentMousePos - _lastMousePos;
            _lastMousePos = _currentMousePos;*/

             _mouseDelta.x = Input.GetAxisRaw("Mouse X");
             _mouseDelta.y = Input.GetAxisRaw("Mouse Y");

            _mouseDelta.x = Mathf.Clamp(_mouseDelta.x, -_mouseClampValue, _mouseClampValue);
            _mouseDelta.y = Mathf.Clamp(_mouseDelta.y, -_mouseClampValue, _mouseClampValue);
        }

        private void HandleRotation()
        {
            //mNewCamRotation.y += mMouseDelta.x * mSenstivity.x * Time.deltaTime;
            Vector3 _newCamRotation = _cameraTransform.rotation.eulerAngles;

            _newCamRotation.x -= _mouseDelta.y * _senstivity.y * Time.deltaTime;
            _parentRotation.y += _mouseDelta.x * _senstivity.x * Time.deltaTime;

            _cameraTransform.rotation = Quaternion.Euler(_newCamRotation);
            transform.rotation = Quaternion.Euler(_parentRotation);
        }

        public void ResetCamera()
        {
            _camera.transform.rotation = _initCameraRotation;

        }
    }
}

