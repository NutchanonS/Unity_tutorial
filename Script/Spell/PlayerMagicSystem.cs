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


    [Header("Ability 2")]
    public Image abilityImage2;
    public Text abilityText2;
    public KeyCode ability2Key;
    public float ability2Cooldown = 5;

    public Canvas ability2Canvas;
    public Image ability2RangeIndicator;
    public float maxAbility2Distance = 7;


    [Header("Ability 3")]
    public Image abilityImage3;
    public Text abilityText3;
    public KeyCode ability3Key;
    public float ability3Cooldown = 5;

    public Canvas ability3Canvas;
    public Image ability3Cone;

    private bool isAbility1Cooldown = false;
    private bool isAbility2Cooldown = false;
    private bool isAbility3Cooldown = false;

    private float currentAbility1Cooldown;
    private float currentAbility2Cooldown;
    private float currentAbility3Cooldown;

    //------------------------------------------------------------

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
        ability2RangeIndicator.enabled = false;
        ability3Cone.enabled = false;

        ability1Canvas.enabled = false;
        ability2Canvas.enabled = false;
        ability3Canvas.enabled = false;

        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;

        abilityText1.text = "";
        abilityText2.text = "";
        abilityText3.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ability1Input();
        Ability2Input();
        Ability3Input();
        //Debug.DrawRay(ray.origin, ray.direction * 100);

        Ability1Canvas_handle();
        Ability2Canvas_handle();
        Ability3Canvas_handle();

        AbilityCooldown(ref currentAbility1Cooldown, ability1Cooldown, ref isAbility1Cooldown, abilityImage1, abilityText1);
        AbilityCooldown(ref currentAbility2Cooldown, ability2Cooldown, ref isAbility2Cooldown, abilityImage2, abilityText2);
        AbilityCooldown(ref currentAbility3Cooldown, ability3Cooldown, ref isAbility3Cooldown, abilityImage3, abilityText3);


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
    void Ability2Canvas_handle()
    {
        int layerMask = ~LayerMask.GetMask("Player");
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if(hit.collider.gameObject != this.gameObject)
            {
                IndicatorPosition = hit.point;
            }
        }
        var hitPosDir = (hit.point - transform.position).normalized;   
        float distance = Vector3.Distance(hitPosDir, transform.position);
        distance = Mathf.Min(distance, maxAbility2Distance);

        var newHitPos = transform.position + hitPosDir * distance;
        ability2Canvas.transform.position = (newHitPos);
    }

    void Ability3Canvas_handle()
    {
        if (ability3Cone.enabled)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                IndicatorPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
            Quaternion ab3canvas = Quaternion.LookRotation(IndicatorPosition - transform.position);
            ab3canvas.eulerAngles = new Vector3(0, ab3canvas.eulerAngles.y, ab3canvas.eulerAngles.z);
            ability3Canvas.transform.rotation = Quaternion.Lerp(ab3canvas, ability3Canvas.transform.rotation, 0);

        }
    }
    private void Ability1Input()
    {
        //if (Input.GetKeyDown(ability1Key) && !isAbility1Cooldown)
        if (Input.GetKeyDown(ability1Key) && !isAbility1Cooldown)
        {
            ability1Canvas.enabled = true;
            ability1SkillShot.enabled = true;

            ability2Canvas.enabled = false;
            ability2RangeIndicator.enabled = false;
            ability3Canvas.enabled = false;
            ability3Cone.enabled = false;
            Cursor.visible = false;

        }
        if (ability1SkillShot.enabled && Input.GetMouseButton(0))
        {
            isAbility1Cooldown = true;
            currentAbility1Cooldown = ability1Cooldown;

            Instantiate(SpellToCast, castPoint.position, ability1Canvas.transform.rotation);
            ability1Canvas.enabled = false;
            ability1SkillShot.enabled = false;
            Cursor.visible = true;
        }

    }
    private void Ability2Input()
    {
        //if (Input.GetKeyDown(ability1Key) && !isAbility1Cooldown)
        if (Input.GetKeyDown(ability2Key) && !isAbility2Cooldown)
        {
            ability2Canvas.enabled = true;
            ability2RangeIndicator.enabled = true;

            ability1Canvas.enabled = false;
            ability1SkillShot.enabled = false;
            ability3Canvas.enabled = false;
            ability3Cone.enabled = false;
            Cursor.visible = false;
        }
        if (ability2RangeIndicator.enabled && Input.GetMouseButton(0))
        {
            isAbility2Cooldown = true;
            currentAbility2Cooldown = ability2Cooldown;

            Instantiate(SpellToCast, castPoint.position, ability2RangeIndicator.transform.rotation);
            ability2Canvas.enabled = false;
            ability2RangeIndicator.enabled = false;
            Cursor.visible = true;
        }

    }
    private void Ability3Input()
    {
        //if (Input.GetKeyDown(ability1Key) && !isAbility1Cooldown)
        if (Input.GetKeyDown(ability3Key) && !isAbility3Cooldown)
        {
            ability3Canvas.enabled = true;
            ability3Cone.enabled = true;

            ability2Canvas.enabled = false;
            ability2RangeIndicator.enabled = false;
            ability1Canvas.enabled = false;
            ability1SkillShot.enabled = false;
            Cursor.visible = false;
        }
        if (ability3Cone.enabled && Input.GetMouseButton(0))
        {
            isAbility3Cooldown = true;
            currentAbility3Cooldown = ability3Cooldown;

            Instantiate(SpellToCast, castPoint.position, ability3Cone.transform.rotation);
            ability3Canvas.enabled = false;
            ability3Cone.enabled = false;
            Cursor.visible = true;
        }

    }
    private void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage, Text skillText)
    {
        if (isCooldown)
        {
            currentCooldown -= Time.deltaTime;

            if (currentCooldown <= 0f)
            {
                isCooldown = false;
                currentCooldown = 0f;

                if (skillImage != null)
                {
                    skillImage.fillAmount = 0f;
                }
                if (skillText != null)
                {
                    skillText.text = "";
                }
            }
            else
            {
                if (skillImage != null)
                {
                    skillImage.fillAmount = currentCooldown / maxCooldown;
                }
                if (skillText != null)
                {
                    skillText.text = Mathf.Ceil(currentCooldown).ToString();
                }
            }
        }
    }
}
