using UnityEngine;
using NaughtyAttributes;

namespace Scripts.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {

        [Foldout("Move Variables")]
        [SerializeField] private float mMoveSpeed = 10;
        [Foldout("Move Variables")]
        [SerializeField] private Vector2 mInput = Vector2.zero;
        [Foldout("Move Variables")]
        [SerializeField] private Vector3 mLookDir = Vector3.zero;

        [Foldout("Componenets")]
        [SerializeField] private Rigidbody mRigidbody;
        [Foldout("Componenets")]
        [SerializeField] private FirstPersonCameraController mCamController;



        private bool mCanMove = false;

        private Vector3 mMoveDir = Vector3.zero;

        private void Update()
        {
            if (!(mCanMove = SetInput() != 0)) { return; }
        }

        private void FixedUpdate()
        {
            HandleMovement();
            HandleRotation();
        }

        //This avoids having the drag-drop to refer.
        //And since we can call it in editor time, when creating an asset, no issues with performance.
        private void Reset()
        {
            mCamController = GetComponentInChildren<FirstPersonCameraController>();
            mRigidbody = GetComponentInChildren<Rigidbody>();
        }

        private float SetInput()
        {
            mInput.x = Input.GetAxisRaw("Horizontal");
            mInput.y = Input.GetAxisRaw("Vertical");

            mInput.Normalize();

            return mInput.magnitude;
        }

        private void HandleMovement()
        {
            // Calling in fixed update. So can avoid deltaTime multiplication.

            mMoveDir = transform.forward * mInput.y;
            mMoveDir += transform.right * mInput.x;

            mRigidbody.velocity = mMoveDir;
        }

        private void HandleRotation()
        {
            mLookDir = mCamController.LookDir;
            //mSkinTransform.rotation = Quaternion.LookRotation(mLookDir);
        }
    }

}
