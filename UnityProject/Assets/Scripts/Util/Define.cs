using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDDefine
{
    /// <summary>
    /// 캐릭터 스테이트는 입력과 관계없이 캐릭터가 지니는 상태
    /// </summary>
    /// 
    [Serializable]
    public enum CharacterState
    {
        Idle = 0,
        Move = 1,
        Run = 2,
        Attack = 3,
        Reload = 4,
        Interact = 5,
        Max
    }

    /// <summary>
    /// 해시 체킹하는 테이블 타입
    /// </summary>
    [Serializable]
    public enum ENUM_INVALID_CHECKING_TABLE_TYPE
    {
        ItemTable = 0,
        CharacterStatTable = 1,
        CharacterAnimationTable = 2,
        Max
    }

    /// <summary>
    /// 아이템 타입
    /// </summary>
    /// 
    [Serializable]
    public enum ENUM_ITEM_TYPE
    {
        Equipment = 0,
        Consumables = 1,
        Weapon = 2,
    }

    /// <summary>
    /// 아이템 장비 - 무기 타입 (PoolType에도 같은 이름이 존재해야 함)
    /// </summary>
    [Serializable]
    public enum ENUM_EQUIPMENT_WEAPON
    {
        Null = 0,
        Rifle = 1,
        Shotgun = 2,
    }

    /// <summary>
    /// 맵 타입
    /// </summary>
    [Serializable]
    public enum ENUM_MAP_TYPE
    {
        DummyMap = 0,
    }

    /// <summary>
    /// 레이어 타입, 에디터 상 레이어 넘버와 ENUM이 동일해야 함
    /// </summary>
    /// 
    [Serializable]
    public enum ENUM_LAYER_TYPE
    {
        /// <summary>
        /// 여기는 Built-In 레이어
        /// </summary>
        /// 
        Default = 0,
        TransparentFX = 1,
        IgnoreRaycast = 2, // 레이캐스트 무시
        Environment = 3, // 맵, 오브젝트 등 환경
        Water = 4, // 물 등 특이 장애물
        UI = 5, 

        /// <summary>
        /// 여기부터 User 커스텀 레이어
        /// </summary>
        ///
        Player = 6, // 유저
    }

    /// <summary>
    /// 태그 타입, Unity의 태그는 사용하지 않을 예정
    /// </summary>
    /// 
    [Serializable]
    public enum ENUM_TAG_TYPE
    {
        Untagged = 0,
        Interactable = 1,
        Spawnable = 2,
        Playable = 3
    }


    /// <summary>
    /// 콜라이더 종류
    /// </summary>

    [Serializable]
    public enum ENUM_COLLIDER_TYPE
    {
        None = -1,
        Box = 0,
        Capsule = 1,
        Mesh = 2,
        Sphere = 3,
        Terrain = 4,
        Wheel = 5,
    }


    /// <summary>
    /// Enter : 초기화 및 번들 로드 시기
    /// Login : 로그인 화면
    /// Lobby : 로비 (혼자 있는)
    /// WaitingRoom : 대기실 (유저와 함께 있는)
    /// Battle : 전투
    /// </summary>
    /// 

    [Serializable]
    public enum GameScene
    {
        Enter = 0,
        Login = 1,
        Lobby = 2,
        WaitingRoom = 3,
        Battle = 4,
        Setting = 5,
    }

    /// <summary>
    /// 캐릭터 애니메이션 클립
    /// </summary>
    [System.Serializable]
    public enum ENUM_CHARACTER_ANIMATION_CLIP
    {
        Idle = 0,
        IdleFire = 1,
        IdleReload = 2,
        IdleMenu = 3,
        RunB = 4,
        RunF = 5,
        RunL = 6,
        RunR = 7,
        WalkB = 8,
        WalkF = 9,
        WalkL = 10,
        WalkR = 11,
        RunFire = 12,
        Sprint = 13,
        Max
    }

    /// <summary>
    /// 캐릭터 스탯
    /// </summary>

    [System.Serializable]
    public enum ENUM_STAT
    {
        STRENGTH = 0, // 힘
        INTELLIGENCE = 1, // 지능
        HEALTH = 2, // 체력
        MENTALITY = 3,  // 정신력
        PHYSICAL_ATTACK = 4, // 물리 공격력
        MAGICAL_ATTACK = 5, // 마법 공격력
        HP_MAX = 6, // HP MAX
        MP_MAX = 7, //  MP MAX
        OVERFLOW
    }

    /// <summary>
    /// 캐릭터 종류
    /// </summary>

    [System.Serializable]
    public enum ENUM_CHARACTER
    {
        Solider = 0,
        None,
    }

    [System.Serializable]
    public enum CameraDepth
    {
        Player = 0,
        UI = 1,
    }


}
