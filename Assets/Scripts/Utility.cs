using System.Collections;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Assets.Scripts
{
    public static class Utility
    {
        public static float AngleTowardsMouse(Vector3 pos)
        {
            Vector3 mousePos = Input.mousePosition;
            //mousePos.z = 5.23f;

            Vector3 objectPos = Camera.main.WorldToScreenPoint(pos);
            mousePos.x -= objectPos.x;
            mousePos.y -= objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            return angle;
        }

        public static void FacingDirection(UnityEngine.Transform objTransform,float scale)
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 playerPosition = Camera.main.WorldToScreenPoint(objTransform.localPosition);

            if (mousePosition.x < playerPosition.x)
            {
                objTransform.localScale = new Vector3(-scale, scale, scale);
            }
            else
            {
                objTransform.localScale = new Vector3(scale, scale, scale);
            }
        }


        public static bool IsFacingLeft(UnityEngine.Transform objTransform)
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 playerPosition = Camera.main.WorldToScreenPoint(objTransform.localPosition);
            return (mousePosition.x < playerPosition.x);
    
        }

        public static void PlayerState(Vector2 movementInput, Animator playerAnimator)
        {

            if (movementInput != Vector2.zero)
            {
                playerAnimator.SetBool("isRunning", true);
            }
            else
            {
                playerAnimator.SetBool("isRunning", false);
            }

            if (Input.GetMouseButton(0))
            {
                playerAnimator.SetBool("isAttacking", true);
            }
            else
            {
                playerAnimator.SetBool("isAttacking", false);

            }

        }

    }
}