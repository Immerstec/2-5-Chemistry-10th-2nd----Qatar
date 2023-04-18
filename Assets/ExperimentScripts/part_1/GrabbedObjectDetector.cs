using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.HandGrab;
namespace Oculus.Interaction
{
    public class GrabbedObjectDetector : MonoBehaviour
    {
        [Interface(typeof(IInteractableView))]
        private MonoBehaviour _interactableView;
        private IInteractableView InteractableView;
        [System.NonSerialized] public bool Isgrabbed;

        void Start()
        {
            _interactableView = GetComponent<HandGrabInteractable>();
            InteractableView = _interactableView as IInteractableView;

        }

        void Update()
        {
            if (InteractableView.State == InteractableState.Select)
            {
                //Debug.Log("Object is currently grabbed.");
                Isgrabbed = true;
            }
            else
            {
                //Debug.Log("Object is not currently grabbed.");
                Isgrabbed = false;

            }
        }
    }
}