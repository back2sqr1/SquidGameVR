using Oculus.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Oculus.Interaction
{
    public class OnPoke : MonoBehaviour
    {
        string sceneName;
        public string sceneNameTo;
        [SerializeField, Interface(typeof(IInteractableView))]
        private UnityEngine.Object _interactableView;
        private IInteractableView InteractableView { get; set; }

       
        private Coroutine _routine = null;
        private static readonly YieldInstruction _waiter = new WaitForEndOfFrame();

        protected bool _started = false;

        protected virtual void Awake()
        {
            InteractableView = _interactableView as IInteractableView;
        }

        protected virtual void Start()
        {
            this.BeginStart(ref _started);

            this.AssertField(InteractableView, nameof(InteractableView));


            UpdateVisual();
            this.EndStart(ref _started);
        }

        protected virtual void OnEnable()
        {
            if (_started)
            {
                UpdateVisual();
                InteractableView.WhenStateChanged += UpdateVisualState;
            }
        }

        protected virtual void OnDisable()
        {
            if (_started)
            {
                InteractableView.WhenStateChanged -= UpdateVisualState;
            }
        }

        private void UpdateVisualState(InteractableStateChangeArgs args)
        {
            UpdateVisual();
        }

        protected virtual void UpdateVisual()
        {
            if (InteractableView.State == InteractableState.Select)
            {
                // Load the new scene
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNameTo);
                // Unload the old scene
                UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
                // Update the current scene name
                sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            }
        }

       

        private void CancelRoutine()
        {
            if (_routine != null)
            {
                StopCoroutine(_routine);
                _routine = null;
            }
        }



    }
}
