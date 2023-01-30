//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Input/Player Input.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Input"",
    ""maps"": [
        {
            ""name"": ""Moving"",
            ""id"": ""292beedc-8e74-4e35-94aa-d0a7e4b59b4f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d2879192-fcc0-47d1-87ff-879507ab9ea5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""13364884-9c75-4dd6-a267-9ba5b3d02a77"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""c23d6657-5da0-4744-ba52-9dcf5f12d270"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ChangeGravityY"",
                    ""type"": ""Button"",
                    ""id"": ""e20ffecd-3deb-44d3-b46b-fc471f8177fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Equip"",
                    ""type"": ""Button"",
                    ""id"": ""566a2ff0-0214-4a80-992c-055261427ddd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""b6a5496d-c468-43ec-96cc-00a11d4a90b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c020ec33-a8ab-4a39-8301-80bbd720718d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56144ebb-0e71-4bed-b427-f287dc8aa6cd"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""43f8ea40-368a-46c0-ac4b-18283b96ab4a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""dc4d97ab-0b63-44cb-bb5e-a7dfd7884540"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""64b98850-0947-40ef-b82f-f0b944fde7fe"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""0ea946de-54a0-47a9-b501-6fcfe3b9c512"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""53d74555-669b-416d-87a1-1e6de64b176e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftStick"",
                    ""id"": ""2cf2616a-8f19-41c5-a01c-cb5ffa762d81"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""01aa9e60-2518-473d-9416-9feefbcbdf3e"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""98249f9d-2a5d-46df-aab6-bb42dc35faa7"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""244359bb-2bc6-40ea-b883-d5f2b66fd187"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""185990b4-14a4-4cb8-8816-93dc42c0240d"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""79288083-7a10-43bb-8445-8e2c0afbaf56"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93982d96-0ecd-4c29-9aed-31e122edc87a"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23273e48-8a6c-4978-b5a4-19e79945c108"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeGravityY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1100c5c3-342f-4461-b4d4-7e35e37d2120"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeGravityY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7601c114-a3c6-4eb9-87e0-1fbf743873aa"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Equip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3571680-466d-40fa-9b8d-31bebd799296"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Equip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66f44b26-0bf6-44f8-91a5-724b7ad4b19b"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1db1b9f-83ea-4464-b2d7-4f043b990c5f"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GravityGun"",
            ""id"": ""afce615f-4b71-450a-8408-a6736a71ef5d"",
            ""actions"": [
                {
                    ""name"": ""GravityUp"",
                    ""type"": ""Button"",
                    ""id"": ""c45d892d-5abe-43c9-b526-95f59c27f72d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GravityDown"",
                    ""type"": ""Button"",
                    ""id"": ""9d960480-ba36-4e12-8ea8-1517368cade3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ChangeGravityDirection"",
                    ""type"": ""Button"",
                    ""id"": ""b5c03b7e-7a89-4e62-ae60-c898319242ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""3ad18adc-f066-4e3c-ad39-1b29ab57c445"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""26d243bb-7d19-4224-b3fb-797697708385"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GravityUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7510f9ac-e097-451a-9268-7d9bf9c28a2e"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GravityUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb1fabc1-c3ba-4011-bb7a-019ff2ce2c35"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GravityDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a24a123-b87b-42d6-aa17-010c1299ac9a"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GravityDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""197129d4-4658-4b65-b57b-f0326eb601d3"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeGravityDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""458075e7-3683-4f42-860b-79fa5a387135"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeGravityDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0261596e-2e53-45ff-981c-5957bda6c85f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a5bf370-addb-4145-91fb-e400ef631651"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""870443cf-9d19-49b2-ba2e-aac73261e032"",
            ""actions"": [
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""e0bf3788-bbd9-4433-9ae9-24b81eb0e095"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5a70c91b-6bcc-4218-9e0d-b31ba0b14f8c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""145ffb2f-cd5a-4c1b-a5f0-040900eddfd3"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Moving
        m_Moving = asset.FindActionMap("Moving", throwIfNotFound: true);
        m_Moving_Move = m_Moving.FindAction("Move", throwIfNotFound: true);
        m_Moving_Jump = m_Moving.FindAction("Jump", throwIfNotFound: true);
        m_Moving_Look = m_Moving.FindAction("Look", throwIfNotFound: true);
        m_Moving_ChangeGravityY = m_Moving.FindAction("ChangeGravityY", throwIfNotFound: true);
        m_Moving_Equip = m_Moving.FindAction("Equip", throwIfNotFound: true);
        m_Moving_Drop = m_Moving.FindAction("Drop", throwIfNotFound: true);
        // GravityGun
        m_GravityGun = asset.FindActionMap("GravityGun", throwIfNotFound: true);
        m_GravityGun_GravityUp = m_GravityGun.FindAction("GravityUp", throwIfNotFound: true);
        m_GravityGun_GravityDown = m_GravityGun.FindAction("GravityDown", throwIfNotFound: true);
        m_GravityGun_ChangeGravityDirection = m_GravityGun.FindAction("ChangeGravityDirection", throwIfNotFound: true);
        m_GravityGun_Fire = m_GravityGun.FindAction("Fire", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Escape = m_UI.FindAction("Escape", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Moving
    private readonly InputActionMap m_Moving;
    private IMovingActions m_MovingActionsCallbackInterface;
    private readonly InputAction m_Moving_Move;
    private readonly InputAction m_Moving_Jump;
    private readonly InputAction m_Moving_Look;
    private readonly InputAction m_Moving_ChangeGravityY;
    private readonly InputAction m_Moving_Equip;
    private readonly InputAction m_Moving_Drop;
    public struct MovingActions
    {
        private @PlayerInput m_Wrapper;
        public MovingActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Moving_Move;
        public InputAction @Jump => m_Wrapper.m_Moving_Jump;
        public InputAction @Look => m_Wrapper.m_Moving_Look;
        public InputAction @ChangeGravityY => m_Wrapper.m_Moving_ChangeGravityY;
        public InputAction @Equip => m_Wrapper.m_Moving_Equip;
        public InputAction @Drop => m_Wrapper.m_Moving_Drop;
        public InputActionMap Get() { return m_Wrapper.m_Moving; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovingActions set) { return set.Get(); }
        public void SetCallbacks(IMovingActions instance)
        {
            if (m_Wrapper.m_MovingActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MovingActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MovingActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MovingActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_MovingActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MovingActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MovingActionsCallbackInterface.OnJump;
                @Look.started -= m_Wrapper.m_MovingActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_MovingActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_MovingActionsCallbackInterface.OnLook;
                @ChangeGravityY.started -= m_Wrapper.m_MovingActionsCallbackInterface.OnChangeGravityY;
                @ChangeGravityY.performed -= m_Wrapper.m_MovingActionsCallbackInterface.OnChangeGravityY;
                @ChangeGravityY.canceled -= m_Wrapper.m_MovingActionsCallbackInterface.OnChangeGravityY;
                @Equip.started -= m_Wrapper.m_MovingActionsCallbackInterface.OnEquip;
                @Equip.performed -= m_Wrapper.m_MovingActionsCallbackInterface.OnEquip;
                @Equip.canceled -= m_Wrapper.m_MovingActionsCallbackInterface.OnEquip;
                @Drop.started -= m_Wrapper.m_MovingActionsCallbackInterface.OnDrop;
                @Drop.performed -= m_Wrapper.m_MovingActionsCallbackInterface.OnDrop;
                @Drop.canceled -= m_Wrapper.m_MovingActionsCallbackInterface.OnDrop;
            }
            m_Wrapper.m_MovingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @ChangeGravityY.started += instance.OnChangeGravityY;
                @ChangeGravityY.performed += instance.OnChangeGravityY;
                @ChangeGravityY.canceled += instance.OnChangeGravityY;
                @Equip.started += instance.OnEquip;
                @Equip.performed += instance.OnEquip;
                @Equip.canceled += instance.OnEquip;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
            }
        }
    }
    public MovingActions @Moving => new MovingActions(this);

    // GravityGun
    private readonly InputActionMap m_GravityGun;
    private IGravityGunActions m_GravityGunActionsCallbackInterface;
    private readonly InputAction m_GravityGun_GravityUp;
    private readonly InputAction m_GravityGun_GravityDown;
    private readonly InputAction m_GravityGun_ChangeGravityDirection;
    private readonly InputAction m_GravityGun_Fire;
    public struct GravityGunActions
    {
        private @PlayerInput m_Wrapper;
        public GravityGunActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @GravityUp => m_Wrapper.m_GravityGun_GravityUp;
        public InputAction @GravityDown => m_Wrapper.m_GravityGun_GravityDown;
        public InputAction @ChangeGravityDirection => m_Wrapper.m_GravityGun_ChangeGravityDirection;
        public InputAction @Fire => m_Wrapper.m_GravityGun_Fire;
        public InputActionMap Get() { return m_Wrapper.m_GravityGun; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GravityGunActions set) { return set.Get(); }
        public void SetCallbacks(IGravityGunActions instance)
        {
            if (m_Wrapper.m_GravityGunActionsCallbackInterface != null)
            {
                @GravityUp.started -= m_Wrapper.m_GravityGunActionsCallbackInterface.OnGravityUp;
                @GravityUp.performed -= m_Wrapper.m_GravityGunActionsCallbackInterface.OnGravityUp;
                @GravityUp.canceled -= m_Wrapper.m_GravityGunActionsCallbackInterface.OnGravityUp;
                @GravityDown.started -= m_Wrapper.m_GravityGunActionsCallbackInterface.OnGravityDown;
                @GravityDown.performed -= m_Wrapper.m_GravityGunActionsCallbackInterface.OnGravityDown;
                @GravityDown.canceled -= m_Wrapper.m_GravityGunActionsCallbackInterface.OnGravityDown;
                @ChangeGravityDirection.started -= m_Wrapper.m_GravityGunActionsCallbackInterface.OnChangeGravityDirection;
                @ChangeGravityDirection.performed -= m_Wrapper.m_GravityGunActionsCallbackInterface.OnChangeGravityDirection;
                @ChangeGravityDirection.canceled -= m_Wrapper.m_GravityGunActionsCallbackInterface.OnChangeGravityDirection;
                @Fire.started -= m_Wrapper.m_GravityGunActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_GravityGunActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_GravityGunActionsCallbackInterface.OnFire;
            }
            m_Wrapper.m_GravityGunActionsCallbackInterface = instance;
            if (instance != null)
            {
                @GravityUp.started += instance.OnGravityUp;
                @GravityUp.performed += instance.OnGravityUp;
                @GravityUp.canceled += instance.OnGravityUp;
                @GravityDown.started += instance.OnGravityDown;
                @GravityDown.performed += instance.OnGravityDown;
                @GravityDown.canceled += instance.OnGravityDown;
                @ChangeGravityDirection.started += instance.OnChangeGravityDirection;
                @ChangeGravityDirection.performed += instance.OnChangeGravityDirection;
                @ChangeGravityDirection.canceled += instance.OnChangeGravityDirection;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }
        }
    }
    public GravityGunActions @GravityGun => new GravityGunActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Escape;
    public struct UIActions
    {
        private @PlayerInput m_Wrapper;
        public UIActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Escape => m_Wrapper.m_UI_Escape;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Escape.started -= m_Wrapper.m_UIActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnEscape;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IMovingActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnChangeGravityY(InputAction.CallbackContext context);
        void OnEquip(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
    }
    public interface IGravityGunActions
    {
        void OnGravityUp(InputAction.CallbackContext context);
        void OnGravityDown(InputAction.CallbackContext context);
        void OnChangeGravityDirection(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnEscape(InputAction.CallbackContext context);
    }
}
