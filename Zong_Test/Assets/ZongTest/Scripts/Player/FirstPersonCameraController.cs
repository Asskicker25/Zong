using UnityEngine;
using NaughtyAttributes;

namespace Scripts.Player
{
    public class FirstPersonCameraController : MonoBehaviour
    {
        [Foldout("Components")]
        [SerializeField] private Camera mCamera;
        [Foldout("Components")]
        [SerializeField] private Transform mCameraTransform;
        [Foldout("Components")]
        [SerializeField] private Transform mParentTransform;

        [Foldout("RotateVariables")]
        [SerializeField] private Vector2 mMouseDelta = Vector2.zero;
        [Foldout("RotateVariables")]
        [SerializeField] private Vector2 mSenstivity = Vector2.one;

        public Vector3 LookDir { get => GetCameraForwardAxis(); }


        private float mMouseClampValue = 0.75f;

        private Vector2 mLastMousePos = Vector2.zero;
        private Vector2 mCurrentMousePos = Vector2.zero;
        private Vector3 mParentRotation = Vector3.zero;

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
            mCamera = GetComponentInChildren<Camera>();
            mCameraTransform = mCamera.transform;
            mParentTransform = transform.parent.transform;
        }

        private void Initialize()
        {
            mParentRotation = mParentTransform.rotation.eulerAngles;
            mLastMousePos = Input.mousePosition;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
        }

        private void SetInput()
        {
            /*    mCurrentMousePos = Input.mousePosition;
                mMouseDelta = mCurrentMousePos - mLastMousePos;
                mLastMousePos = mCurrentMousePos;*/

            mMouseDelta.x = Input.GetAxisRaw("Mouse X");
            mMouseDelta.y = Input.GetAxisRaw("Mouse Y");

            mMouseDelta.x = Mathf.Clamp(mMouseDelta.x, -mMouseClampValue, mMouseClampValue);
            mMouseDelta.y = Mathf.Clamp(mMouseDelta.y, -mMouseClampValue, mMouseClampValue);
        }

        private void HandleRotation()
        {
            //mNewCamRotation.y += mMouseDelta.x * mSenstivity.x * Time.deltaTime;
            Vector3 mNewCamRotation = mCameraTransform.rotation.eulerAngles;

            mNewCamRotation.x -= mMouseDelta.y * mSenstivity.y * Time.deltaTime;
            mParentRotation.y += mMouseDelta.x * mSenstivity.x * Time.deltaTime;

            mCameraTransform.rotation = Quaternion.Euler(mNewCamRotation);
            mParentTransform.rotation = Quaternion.Euler(mParentRotation);
        }

        public Vector3 GetCameraForwardAxis()
        {
            Vector3 forward = mCameraTransform.forward;
            forward.y = 0;
            forward.Normalize();

            return forward;
        }

    }
}

