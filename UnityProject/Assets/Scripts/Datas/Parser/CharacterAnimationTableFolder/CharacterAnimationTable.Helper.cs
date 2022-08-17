using SDDefine;
using System.Collections;
using System.Collections.Generic;

public partial class CharacterAnimationTable
{
    public string GetAnimatorPath(ENUM_CHARACTER characterEnum)
    {
        if (characterEnum == ENUM_CHARACTER.None)
            return string.Empty;

        if (CharacterAnimationPathDictionary.ContainsKey((int)characterEnum))
            return CharacterAnimationPathDictionary[(int)characterEnum].animatorController;

        return string.Empty;
    }

    public Dictionary<ENUM_CHARACTER_ANIMATION_CLIP, string> GetAnimationClipPathDictionary(ENUM_CHARACTER characterEnum)
    {
        if (characterEnum == ENUM_CHARACTER.None)
            return null;

        if (!CharacterAnimationPathDictionary.ContainsKey((int)characterEnum))
            return null;

        var animationPaths = CharacterAnimationPathDictionary[(int)characterEnum];

        return new Dictionary<ENUM_CHARACTER_ANIMATION_CLIP, string>
        {
            { ENUM_CHARACTER_ANIMATION_CLIP.Idle, animationPaths.idle },
            { ENUM_CHARACTER_ANIMATION_CLIP.IdleFire, animationPaths.idleFire },
            { ENUM_CHARACTER_ANIMATION_CLIP.IdleReload, animationPaths.idleReload },
            { ENUM_CHARACTER_ANIMATION_CLIP.IdleMenu, animationPaths.idleMenu },
            { ENUM_CHARACTER_ANIMATION_CLIP.RunB, animationPaths.runB },
            { ENUM_CHARACTER_ANIMATION_CLIP.RunF, animationPaths.runF },
            { ENUM_CHARACTER_ANIMATION_CLIP.RunL, animationPaths.runL },
            { ENUM_CHARACTER_ANIMATION_CLIP.RunR, animationPaths.runR },
            { ENUM_CHARACTER_ANIMATION_CLIP.WalkB, animationPaths.walkB },
            { ENUM_CHARACTER_ANIMATION_CLIP.WalkF, animationPaths.walkF },
            { ENUM_CHARACTER_ANIMATION_CLIP.WalkL, animationPaths.walkL },
            { ENUM_CHARACTER_ANIMATION_CLIP.WalkR, animationPaths.walkR },
            { ENUM_CHARACTER_ANIMATION_CLIP.RunFire, animationPaths.runFire },
            { ENUM_CHARACTER_ANIMATION_CLIP.Sprint, animationPaths.sprint }
        };
    }
}