
using UnityEngine;

public abstract class APlayerInput{

    private IJumpCounter _jumpCounter;

    public APlayerInput(){
        _jumpCounter = new PlayerJumpCounter();
    }

    public int GetHorizontalAxisSign(){
        if(isLeftHold())  return -1;
        if(isRightHold()) return 1;
        return 0;
    }
    public abstract bool isLeftHold();
    public abstract bool isRightHold();
    public abstract bool isJumpPressed();
    public abstract bool isJumpHold();
    public abstract bool isBlockKeyPressed();

    public void Update(){
        _jumpCounter.Update();
    }

    public void HitGround(){
        _jumpCounter.HitGround();
    }
    public bool CanJump(){
        return _jumpCounter.CanJump();
    }
}

public class Player1Input : APlayerInput {
    public override bool isLeftHold(){
        return Input.GetKey(KeyCode.A);
    }

    public override bool isRightHold(){
        return Input.GetKey(KeyCode.D);
    }

    public override bool isJumpPressed(){
        return Input.GetKeyDown(KeyCode.W) ;
    }

    public override bool isJumpHold(){
        return Input.GetKey(KeyCode.W);
    }

    public override bool isBlockKeyPressed(){
        return Input.GetKey(KeyCode.RightControl);
    }

}

public class Player2Input : APlayerInput {
    public override bool isLeftHold(){
        return Input.GetKey(KeyCode.LeftArrow);
    }

    public override bool isRightHold(){
        return Input.GetKey(KeyCode.RightArrow);
    }

    public override bool isJumpPressed(){
        return Input.GetKeyDown(KeyCode.UpArrow);
    }

    public override bool isJumpHold(){
        return Input.GetKey(KeyCode.UpArrow);
    }

    public override bool isBlockKeyPressed(){
        return Input.GetKey(KeyCode.LeftControl);
    }
}