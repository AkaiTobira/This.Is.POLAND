using UnityEngine;

public class Entity : MonoBehaviour {

    [SerializeField] public AnimatorExtended AnimatorExt;
    [SerializeField] public UnitDetector Detector;
    public APlayerInput InputController;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpHoldTime;
    [SerializeField] private float _inAirMovementSpeed;
    [SerializeField] private float _gravity;

    [Header("Hurt")]
    [SerializeField] private float _invincibleTime = 1.0f;
    [SerializeField] private float _timeOfbeingHit = 0.3f;

    public float TimerOfBeeingHit{
        get { return _timeOfbeingHit;}
    }

    public float InvincibleTime{
        get { return _invincibleTime;}
    }

    public int ID = -1;

    public virtual void Start() {
        ID = UnitsManager.RegisterUnit(this);
    }

    public float Gravity{
        get { return _gravity; }
    }

    public float InAirMovementSpeed{
        get { return _inAirMovementSpeed;}
    }

    public float JumpHoldTime{
        get { return _jumpHoldTime;}
    }

    public float JumpForce{
        get { return _jumpForce;}
    }

    public float MovementSpeed{
        get { return _movementSpeed;}
    }

    public virtual void Update() {
        if(Detector == null || InputController == null) return;
        if(Detector.isOnGround()) InputController.HitGround();
    }

}