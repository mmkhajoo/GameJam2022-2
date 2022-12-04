using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class TriggerEventHandler : MonoBehaviour
    {
        public UnityEvent OnTriggerActivate;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.tag.Equals("Player"))
            {
                OnTriggerActivate?.Invoke();
            }
        }
    }
}