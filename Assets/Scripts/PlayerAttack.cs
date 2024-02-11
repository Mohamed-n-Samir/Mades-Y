using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Transform arrowPoint;
    [SerializeField] Slider bowPowerSlider;
    [SerializeField] Transform bowPowerSliderTransform;
    

    [Range(0, 10)]
    [SerializeField] float bowPower = 10;

    [Range(0, 10)]
    [SerializeField] float maxBowCharge = 4;

    float bowCharge;

    private bool canFire = true;
    private float attackSpeed = 30;

    // Start is called before the first frame update
    void Start()
    {
        bowPowerSlider.value = 0f;
        bowPowerSlider.maxValue = maxBowCharge;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Input.GetMouseButton(0) && canFire)
        {
            ChargeBow();
        }
        else if (Input.GetMouseButtonUp(0) && canFire)
        {
            FireBow();
        }
        else
        {
            if (bowCharge > 0f)
            {
                bowCharge = 0f;
            }
            else
            {
                bowCharge = 0f;
                canFire = true;
            }
            bowPowerSlider.value = bowCharge;
        }
    }

    public void ChargeBow()
    {
        bowCharge += Time.deltaTime * attackSpeed;
        bowPowerSlider.value = bowCharge;

        float angle = Utility.AngleTowardsMouse(bowPowerSliderTransform.position);

        if (Utility.IsFacingLeft(transform))
        {
            bowPowerSliderTransform.localScale = new Vector3(-1, -1, 1);
        }
        else
        {
            bowPowerSliderTransform.localScale = Vector3.one;
        }
        bowPowerSliderTransform.rotation = Quaternion.Euler(0f, 0f, angle);


        if (bowCharge > maxBowCharge)
        {
            bowPowerSlider.value = maxBowCharge;
        }
    }

    public void FireBow()
    {
        if (bowCharge > maxBowCharge)
        {
            bowCharge = maxBowCharge;
        }

        float arrowSpeed = bowCharge + bowPower;

        float angle = Utility.AngleTowardsMouse(arrowPoint.position);
        PlayerArrow arrow = Instantiate(arrowPrefab, arrowPoint.position, Quaternion.Euler(0, 0, angle)).GetComponent<PlayerArrow>();
        arrow.SetDistanceToLive(bowPowerSlider.value);

        canFire = false;


    }
}
