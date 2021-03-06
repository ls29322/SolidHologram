using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : NetworkBehaviour
    {
        [Tooltip("CAN'T MODIFY THIS KEY WHILE EXECUTING")]
        [SerializeField]
        private KeyCode crouchKey = KeyCode.None;

        [Tooltip("Only useful if crouchKey is set to 'None' or playing on MobileDevice")]
        [Range(0, -1)]
        [SerializeField]
        private float crouchSensibility;

        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
		private bool isColliding;
        private bool crouch = false;

        //Only local player can use it
        private void Start()
        {
            if (!isLocalPlayer)
            {
                GameObject mobileControl = GameObject.FindGameObjectWithTag("MobileController");
                Destroy(mobileControl);
                Destroy(this);
                return;
            }
        }

        private void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
            m_Character = GetComponent<PlatformerCharacter2D>();
        }

        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
            if (Input.GetKey(KeyCode.H))
            {

            }
        }


        private void FixedUpdate()
		{
			// Read the inputs.
			float h = CrossPlatformInputManager.GetAxis ("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");

            crouch = false;

#if MOBILE_INPUT
            crouch = (v < crouchSensibility) ? true : false;
#else
            if (crouchKey == KeyCode.None)
            {
                //There is no sensibility on PC (at least not if you don't plays with joystick)
                crouch = (v < crouchSensibility) ? true : false;
            }
            else
            {
                crouch = Input.GetKey(crouchKey);
            }
#endif
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }

    }
}