using UnityEngine;


namespace UnitySampleAssets.CrossPlatformInput
{
#if UNITY_EDITOR
    using UnityEditor;
    [ExecuteInEditMode]
#endif
    public class MobileControlRig : MonoBehaviour
    {
        // this script enables or disables the child objects of a control rig
        // depending on whether the USE_MOBILE_INPUT define is declared.

        // This define is set or unset by a menu item that is included with
        // the Cross Platform Input package.

#if !UNITY_EDITOR
	void OnEnable()
	{
		CheckEnableControlRig();
	}
	#endif

#if UNITY_EDITOR

        private void OnEnable()
        {
            EditorApplication.update += Update;
        }

        private void OnDisable()
        {
            EditorApplication.update -= Update;
        }

        private void Update()
        {
            CheckEnableControlRig();

        }
#endif

        private void CheckEnableControlRig()
        {
#if MOBILE_INPUT
		EnableControlRig(true);
		#else
            EnableControlRig(false);
#endif

        }

        private void EnableControlRig(bool enabled)
        {
            foreach (Transform t in transform)
            {
                t.gameObject.SetActive(enabled);
            }
        }
    }
}

