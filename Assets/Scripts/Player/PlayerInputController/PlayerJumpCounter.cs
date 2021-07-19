

using UnityEngine;

public static class  PlayerJumpCounter{

    static int framesSincePlayerWasOnGround = 0;
    static int MaxJumpDelay = 30;

    public static void HitGround(){
        framesSincePlayerWasOnGround = 0;
    }

    public static bool CanJump(){
        Debug.Log(framesSincePlayerWasOnGround);
        return framesSincePlayerWasOnGround < MaxJumpDelay;
    }

    public static void Update(){
        framesSincePlayerWasOnGround += 1;
    }

}

