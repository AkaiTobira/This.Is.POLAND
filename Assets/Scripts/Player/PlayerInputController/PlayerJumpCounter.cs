using UnityEngine;

public interface IJumpCounter {
    void HitGround();
    bool CanJump();
    void Update();
}

public class PlayerJumpCounter : IJumpCounter{
    int framesSincePlayerWasOnGround = 0;
    int MaxJumpDelay = 30;

    public void HitGround(){
        framesSincePlayerWasOnGround = 0;
    }

    public bool CanJump(){
        return framesSincePlayerWasOnGround < MaxJumpDelay;
    }

    public void Update(){
        framesSincePlayerWasOnGround += 1;
    }

}

