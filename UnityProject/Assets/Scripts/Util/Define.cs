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
        Attack = 2,
        Max
    }

    /// <summary>
    /// 맵 타입
    /// </summary>
    [Serializable]
    public enum ENUM_MAP_TYPE
    {
        FileIsland = 0,
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
        OVERFLOW
    }

    /// <summary>
    /// 캐릭터 종류
    /// </summary>

    [System.Serializable]
    public enum ENUM_CHARACTER
    {
        AGUMON = 0,
        None,
    }

    [System.Serializable]
    public enum CameraDepth
    {
        Player = 0,
        UI = 1,
    }


}
