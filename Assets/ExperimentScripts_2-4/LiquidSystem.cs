using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidSystem : MonoBehaviour
{
    public MeshRenderer liquidMesh;
    private Material liquidMat;

    [Header("Capacity Settings (ML)")]
    [Tooltip("The capacity of this object, how much ML can it hold.")]
    public float capacity = 500;
    [Tooltip("The fill of this object in ML, it shouldn't exceed its capacity.")]
    public float available = 500;
    //[Tooltip("How much ML should fill/lose every second.")]
    [Tooltip("How much ML should a single particle fill/lose.")]
    public float pourPerSecond = 1;

    [Header("Pouring Settings")]
    [Tooltip("The pouring particle system")]
    public ParticleSystem pouringParticleSystem;
    [Tooltip("Set when 'Current_Angle' should pour when the fill is 100%")]
    public float full_angle = -0.796419f; // 100%
    [Tooltip("Set when 'Current_Angle' should pour when the fill is 50%")]
    public float half_angle = -0.5462257f; // 50%
    [Tooltip("Set when 'Current_Angle' should pour when the fill is 25% or less")]
    public float quarter_angle = -0.1965031f; // 25%

    [Header("Debugging Info")]
    [Tooltip("(Debugging Only) A cruve generated from the pouring angles (full, half, quarter) to interpolate between these values.")]
    public AnimationCurve pouringAngleCurve;
    [Tooltip("Use this value to update the pouring angles (full, half, quarter)")]
    public float current_angle = 0;
    [Tooltip("This value is taking from the shader's fill (0 - 1)")]
    public float percentageFill;
    [Tooltip("If current_angle is matching the pouring_angle, this should be true. Otherwise, it'll remain false.")]
    public bool isPouring = false;
    [Tooltip("This value is auto calculated from the pouringAngleCurve based on the current fill/percentageFill")]
    public float pouring_angle = 0;

    [Header("Rate Over Time Settings")]
    [Tooltip("Set the amount of particles per second when the object is looking up (0deg)")]
    public float angle_0deg_rate = 20; // 180deg
    [Tooltip("Set the amount of particles per second when the object is looking to the side (90deg)")]
    public float angle_90deg_rate = 70; // 90deg
    [Tooltip("Set the amount of particles per second when the object is looking down (180deg)")]
    public float angle_180deg_rate = 100; // 0deg
    ParticleSystem.EmissionModule emission;

    [Header("Debugging Info")]
    [Tooltip("(Debugging Only) A cruve generated from the pouring angles (full, half, quarter) to interpolate between these rate over time values.")]
    public AnimationCurve rateOverTimeCurve;
    [Tooltip("The current rate over time based on the current fill.")]
    public float current_rateOverTime;
    public float normalizedRateOverTime;

    [Header("Collider Position Shift (Optional)")]
    public Transform fillCollider;
    public Transform colFullPos;
    public Transform colEmptyPos;

    [Header("floatSurface")]

    public float _molar;
    [SerializeField] Transform TopSurface;
    [SerializeField] Transform bottomSurface;

    private float TopSurfaceHeight;
    private float bottomSurfaceHeight;
    [SerializeField] GameObject floatSurface;
    // Start is called before the first frame update
    void Start()
    {
        TopSurfaceHeight = TopSurface.position.y;
        bottomSurfaceHeight = bottomSurface.position.y;

        liquidMat = liquidMesh.material;
        // Setting the pouring angle curve
        pouringAngleCurve.AddKey(0.25f, quarter_angle);
        pouringAngleCurve.AddKey(0.5f, half_angle);
        pouringAngleCurve.AddKey(1f, full_angle);

        // Setting the rate over time curve
        rateOverTimeCurve.AddKey(0.25f, angle_0deg_rate);
        rateOverTimeCurve.AddKey(0.5f, angle_90deg_rate);
        rateOverTimeCurve.AddKey(1f, angle_180deg_rate);
        emission = pouringParticleSystem.emission;

        UpdateShader();
    }

    // Update is called once per frame
    void Update()
    {
        setfloatSurface();
        liquidMat = liquidMesh.material;
        percentageFill = liquidMat.GetFloat("_Fill");
        current_angle = Vector3.Dot(transform.up, Vector3.down);
        pouring_angle = pouringAngleCurve.Evaluate(percentageFill);
        // Current rate over time (particles per second)
        normalizedRateOverTime = (current_angle + 1) / 2.0f;
        current_rateOverTime = rateOverTimeCurve.Evaluate(normalizedRateOverTime);
        emission.rateOverTime = current_rateOverTime;
        if (current_angle > pouring_angle)
        {
            isPouring = true;
            if (!pouringParticleSystem.isPlaying && available > 0)
                pouringParticleSystem.Play();
            if (percentageFill > 0.0f)
            {
                available -= Time.deltaTime * pourPerSecond * current_rateOverTime;
                UpdateShader();
            }
        }
        else
        {
            isPouring = false;
            if (pouringParticleSystem.isPlaying)
                pouringParticleSystem.Stop();
        }

        if (available < 0)
        {
            available = 0.0f;
            if (pouringParticleSystem.isPlaying)
                pouringParticleSystem.Stop();
        }

        if (fillCollider && colFullPos && colEmptyPos)
        {
            fillCollider.position = Vector3.Lerp(colEmptyPos.position, colFullPos.position, percentageFill);
        }

        //if (_molar > 0.5f)
        //{
        //    setfloatSurface();
        //}
        //else {
        //    DeactivatetfloatSurface();
        //}
    }

    public void Fill(float ml)
    {
        if (available + ml < capacity)
            available += ml;
        else
            available = capacity;
        UpdateShader();
        
       // print("Filling: " + ml);
    }

    void UpdateShader()
    {
        liquidMat.SetFloat("_Fill", available / capacity);
    }
    void calculateMolar(float molar) {
        if (_molar == 0)
        {
            _molar = molar;
        }
        else
        {
            _molar = (_molar + molar) / 2;
        }
    }
    float CalculatesurfacePoint() {


       return ( liquidMat.GetFloat("_Fill")*(TopSurfaceHeight - bottomSurfaceHeight) ) + bottomSurfaceHeight ;
            
    }
    public void setfloatSurface() {
        Vector3 floatSurfacePos = new Vector3(floatSurface.transform.position.x, CalculatesurfacePoint(), floatSurface.transform.position.z);
        floatSurface.transform.position = floatSurfacePos;
    }

}
