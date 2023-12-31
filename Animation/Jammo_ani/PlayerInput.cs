//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.1
//     from Assets/Animation/Jammo_ani/PlayerInput.inputactions
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

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""CharacterControll"",
            ""id"": ""96c89def-7232-40e6-9dc3-3bbc83769c1d"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""762280ab-915b-49f7-939d-c66945d61444"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseMove"",
                    ""type"": ""Button"",
                    ""id"": ""15ce8dc7-6a5e-4561-bb82-9f5750094544"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Spell Cast"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ebd257da-0b22-4118-a473-11b404409217"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Spell Cast2"",
                    ""type"": ""Button"",
                    ""id"": ""faadcd80-fbd2-491b-aa8a-28b849c30e53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""1861026b-3a71-4a83-9cf7-2b60e5093217"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9120d49d-6aa2-40c8-ad95-61ac48a62b2a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""288f8170-b385-413c-9d10-864b924dde48"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4ef34387-f911-4b91-837b-fc20aa9b36e7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ed550e03-0681-4e45-be26-87d1cebbbf89"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""689f13e0-0d62-4b3b-b626-3a4bc87faa3c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4abb241f-696b-4468-98a5-52c2669f4246"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spell Cast"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""255688c7-656f-4a3c-b945-6c90b72e79cb"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spell Cast"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""913474dd-8389-4d7e-94f8-0cb6ab70e7db"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spell Cast2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterControll
        m_CharacterControll = asset.FindActionMap("CharacterControll", throwIfNotFound: true);
        m_CharacterControll_Move = m_CharacterControll.FindAction("Move", throwIfNotFound: true);
        m_CharacterControll_MouseMove = m_CharacterControll.FindAction("MouseMove", throwIfNotFound: true);
        m_CharacterControll_SpellCast = m_CharacterControll.FindAction("Spell Cast", throwIfNotFound: true);
        m_CharacterControll_SpellCast2 = m_CharacterControll.FindAction("Spell Cast2", throwIfNotFound: true);
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

    // CharacterControll
    private readonly InputActionMap m_CharacterControll;
    private List<ICharacterControllActions> m_CharacterControllActionsCallbackInterfaces = new List<ICharacterControllActions>();
    private readonly InputAction m_CharacterControll_Move;
    private readonly InputAction m_CharacterControll_MouseMove;
    private readonly InputAction m_CharacterControll_SpellCast;
    private readonly InputAction m_CharacterControll_SpellCast2;
    public struct CharacterControllActions
    {
        private @PlayerInput m_Wrapper;
        public CharacterControllActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_CharacterControll_Move;
        public InputAction @MouseMove => m_Wrapper.m_CharacterControll_MouseMove;
        public InputAction @SpellCast => m_Wrapper.m_CharacterControll_SpellCast;
        public InputAction @SpellCast2 => m_Wrapper.m_CharacterControll_SpellCast2;
        public InputActionMap Get() { return m_Wrapper.m_CharacterControll; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControllActions set) { return set.Get(); }
        public void AddCallbacks(ICharacterControllActions instance)
        {
            if (instance == null || m_Wrapper.m_CharacterControllActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CharacterControllActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @MouseMove.started += instance.OnMouseMove;
            @MouseMove.performed += instance.OnMouseMove;
            @MouseMove.canceled += instance.OnMouseMove;
            @SpellCast.started += instance.OnSpellCast;
            @SpellCast.performed += instance.OnSpellCast;
            @SpellCast.canceled += instance.OnSpellCast;
            @SpellCast2.started += instance.OnSpellCast2;
            @SpellCast2.performed += instance.OnSpellCast2;
            @SpellCast2.canceled += instance.OnSpellCast2;
        }

        private void UnregisterCallbacks(ICharacterControllActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @MouseMove.started -= instance.OnMouseMove;
            @MouseMove.performed -= instance.OnMouseMove;
            @MouseMove.canceled -= instance.OnMouseMove;
            @SpellCast.started -= instance.OnSpellCast;
            @SpellCast.performed -= instance.OnSpellCast;
            @SpellCast.canceled -= instance.OnSpellCast;
            @SpellCast2.started -= instance.OnSpellCast2;
            @SpellCast2.performed -= instance.OnSpellCast2;
            @SpellCast2.canceled -= instance.OnSpellCast2;
        }

        public void RemoveCallbacks(ICharacterControllActions instance)
        {
            if (m_Wrapper.m_CharacterControllActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICharacterControllActions instance)
        {
            foreach (var item in m_Wrapper.m_CharacterControllActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CharacterControllActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CharacterControllActions @CharacterControll => new CharacterControllActions(this);
    public interface ICharacterControllActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMouseMove(InputAction.CallbackContext context);
        void OnSpellCast(InputAction.CallbackContext context);
        void OnSpellCast2(InputAction.CallbackContext context);
    }
}
