using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMagicSystem : MonoBehaviour
{
    [SerializeField] private Spell SpellToCast;

    [SerializeField] public float maxMana = 100f;
    [SerializeField] public float currentMana;
    [SerializeField] public float manaRegenRate = 2f;
    [SerializeField] private float timeBetweenCast = 0.25f;
    private float currentCastTimer;

    [SerializeField] private Transform castPoint;
    private bool castMagic = false;
    private PlayerInput playerinput;

    //---------------ability indicator---------
    [Header("Ability 1")]
    public Image abilityImage1;
    public Text abilityText1;
    public KeyCode ability1Key;
    public float ability1Cooldown = 5;

    public Canvas ability1Canvas;
    public Image ability1SkillShot;

    private Vector3 IndicatorPosition;
    private RaycastHit hit;
    private Ray ray;

    private void Awake()
    {
        playerinput = new PlayerInput();
        currentMana = maxMana;
        //playerinput.CharacterControll.SpellCast2.started += spellCastButton;
        //playerinput.CharacterControll.SpellCast2.canceled += spellCastButton;
        playerinput.CharacterControll.SpellCast2.performed += spellCastButton;
    }
    // Start is called before the first frame update
    void Start()
    {
        ability1SkillShot.enabled = false;
        ability1Canvas.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        Ability1Input();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ability1Canvas_handle();
        //Debug.DrawRay(ray.origin, ray.direction * 100);


        //bool isSpellCastHeldDown = playerinput.CharacterControll.SpellCast.ReadValue<float>() > 0.1;
        //bool hasEnougnMana = currentMana - SpellToCast.spellToCast.ManaCost >= 0f;
        //if (!castMagic && isSpellCastHeldDown && hasEnougnMana)
        //{
        //    currentCastTimer = 0;
        //    castMagic = true;
        //    currentMana -= SpellToCast.spellToCast.ManaCost;
        //    CastSpell();
        //}
        //if (castMagic)
        //{
        //    currentCastTimer += Time.deltaTime;
        //    if (currentCastTimer > timeBetweenCast) { castMagic = false; }
        //}
        //if (currentMana < maxMana && !castMagic && isSpellCastHeldDown)
        //{
        //    currentMana += manaRegenRate * Time.deltaTime;
        //    if (currentMana > maxMana) { currentMana = maxMana; }
        //}
    }

    void spellCastButton(InputAction.CallbackContext context)
    {
        CastSpell();
    }
    void CastSpell()
    {
        Instantiate(SpellToCast, castPoint.position, castPoint.rotation);
    }
    private void OnEnable()
    {
        playerinput.Enable();
    }
    private void OnDisable()
    {
        playerinput.Disable();
    }
    //--------------------------ability-----------------------------
    void Ability1Canvas_handle()
    {
        if (ability1SkillShot.enabled)
        {
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                IndicatorPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
            Quaternion ab1canvas = Quaternion.LookRotation(IndicatorPosition - transform.position);
            ab1canvas.eulerAngles = new Vector3(0, ab1canvas.eulerAngles.y, ab1canvas.eulerAngles.z);
            ability1Canvas.transform.rotation = Quaternion.Lerp(ab1canvas, ability1Canvas.transform.rotation, 0);

        }
    }
    private void Ability1Input()
    {
        //if (Input.GetKeyDown(ability1Key) && !isAbility1Cooldown)
        if (Input.GetKeyDown(ability1Key))
        {
            ability1Canvas.enabled = true;
            ability1SkillShot.enabled = true;

        }
        if (ability1SkillShot.enabled && Input.GetMouseButton(0))
        {
            //isAbility1Cooldown = true;
            //currentAbility1Cooldown = ability1Cooldown;
            Instantiate(SpellToCast, castPoint.position, ability1Canvas.transform.rotation);
            ability1Canvas.enabled = false;
            ability1SkillShot.enabled = false;
        }

    }
    //private void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage, Text skillText)
    //{
    //    if (isCooldown)
    //    {
    //        currentCooldown -= Time.deltaTime;

    //        if (currentCooldown <= 0f)
    //        {
    //            isCooldown = false;
    //            currentCooldown = 0f;

    //            if (skillImage != null)
    //            {
    //                skillImage.fillAmount = 0f;
    //            }
    //            if (skillText != null)
    //            {
    //                skillText.text = "";
    //            }
    //        }
    //        else
    //        {
    //            if (skillImage != null)
    //            {
    //                skillImage.fillAmount = currentCooldown / maxCooldown;
    //            }
    //            if (skillText != null)
    //            {
    //                skillText.text = Mathf.Ceil(currentCooldown).ToString();
    //            }
    //        }
    //    }
    //}
}
