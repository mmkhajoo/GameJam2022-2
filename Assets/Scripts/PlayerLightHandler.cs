using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerLightHandler : MonoBehaviour
    {
        [SerializeField] public GameObject maskGameObject;

        private void Awake()
        {
            if (PlayerPrefs.GetInt("Light") == 1)
            {
                ActivateMask();
            }
        }

        public void ActivateMask()
        {
            PlayerPrefs.SetInt("Light",1);
            maskGameObject.SetActive(true);
        }
    }
}