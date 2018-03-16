using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool m_Attack;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

            if (!m_Attack)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Attack = CrossPlatformInputManager.GetButtonDown("Fire1");
            }
            else if (m_Attack)
            {
                m_Attack = false;
            }
            

            if (CrossPlatformInputManager.GetButtonDown("Cancel"))
            {
                SceneManager.LoadScene("Forest");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = false; // Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Character.Attack(m_Attack);
            m_Attack = false;
            m_Jump = false;
        }
    }
}
