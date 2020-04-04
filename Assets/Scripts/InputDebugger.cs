using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // À rajouter

public class InputDebugger : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Controls controls;
    private Vector3 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        controls = new Controls(); //Instancie une nouvelle class de type controls
        controls.Enable();// Active l'actionMap
        //controls.Player.MoveLR.performed += OnMoveLRPerformed;// Ajoute la fonction OnMovePerformed aux actions de l'input
        //controls.Player.MoveUD.performed += OnMoveUDPerformed;
        controls.Player.Move.performed += OnMovePerformed;
        controls.Player.Move.canceled += OnMoveCanceled;
    }

    private void OnMoveCanceled(InputAction.CallbackContext obj)
    {
        direction = Vector3.zero;
    }

    private void OnMovePerformed(InputAction.CallbackContext obj)
    {
        direction = obj.ReadValue<Vector2>();
    }

    private void OnMoveUDPerformed(InputAction.CallbackContext obj)
    {
        var inputValue = obj.ReadValue<float>();
        var direction = new Vector3(0, inputValue, 0);
        transform.position += direction;
    }

    private void OnMoveLRPerformed(InputAction.CallbackContext obj) // À rajouter
    {
        //Debug.Log(obj.ReadValue<float>());
        var inputValue = obj.ReadValue<float>();
        var direction = new Vector3(inputValue, 0, 0);
        transform.position += direction;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
