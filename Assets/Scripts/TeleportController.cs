using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TeleportController : MonoBehaviour
{
    [SerializeField] GameObject baseControllerGameObject;
    [SerializeField] GameObject teleportationGameObject;
    [SerializeField] InputActionReference teleportActivationReference;

    [Space]
    [SerializeField] UnityEvent onTeleportActivate;
    [SerializeField] UnityEvent onTeleportCancel;

    private void Start() 
    {
        teleportActivationReference.action.performed += TeleportModeActivate;
        teleportActivationReference.action.canceled += TeleportModeCancel;
    }

    private void TeleportModeCancel(InputAction.CallbackContext obj)
    {
        Invoke(nameof(DeactivateTeleporter), .1f);
    }

    void DeactivateTeleporter()
    {
        onTeleportCancel.Invoke();
    }
    private void TeleportModeActivate(InputAction.CallbackContext obj)
    {
        onTeleportActivate.Invoke();
    }
}
