using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerLightHandler : MonoBehaviour
    {
        [SerializeField] public GameObject maskGameObject;

        public void ActivateMask()
        {
            maskGameObject.SetActive(true);
        }
    }
}