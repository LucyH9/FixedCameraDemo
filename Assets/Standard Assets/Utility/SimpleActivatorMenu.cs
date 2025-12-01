using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Utility
{
    public class SimpleActivatorMenu : MonoBehaviour
    {
        // A simple menu which cycles through an array of GameObjects
        [SerializeField] private Text camSwitchButton;
        public GameObject[] objects;

        private int m_CurrentActiveObject;

        public Text CamSwitchButton
        {
            get => camSwitchButton;
            set => camSwitchButton = value;
        }

        private void OnEnable()
        {
            m_CurrentActiveObject = 0;

            if (CamSwitchButton != null)
                CamSwitchButton.text = objects[m_CurrentActiveObject].name;
        }

        public void NextCamera()
        {
            int nextactiveobject =
                (m_CurrentActiveObject + 1 >= objects.Length)
                ? 0
                : m_CurrentActiveObject + 1;

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(i == nextactiveobject);
            }

            m_CurrentActiveObject = nextactiveobject;

            if (CamSwitchButton != null)
                CamSwitchButton.text = objects[m_CurrentActiveObject].name;
        }
    }
}
