using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

[Serializable]
public class CharacterStats
{
    //Stats
    private int _hp;
    public int Hp
    {
        get { return _hp; }
        set { _hp = value; }
    }
    private int _mp;
    public int Mp
    {
        get { return _mp; }
        set { _mp = value; }
    }
    private int _maxHp;
    public int MaxHp
    {
        get { return _maxHp; }
        set { _maxHp = value; }
    }
    private int _maxMp;
    public int MaxMp
    {
        get { return _maxMp; }
        set { _maxMp = value; }
    }
    private int _str;
    public int Str
    {
        get { return _str; }
        set { _str = value; }
    }
    private int _originalStr;
    public int OriginalStr
    {
        get { return _originalStr; }
        set { _originalStr = value; }
    }
    private int _def;
    public int Def
    {
        get { return _def; }
        set { _def = value; }
    }
    private int _originalDef;
    public int OriginalDef
    {
        get { return _originalDef; }
        set { _originalDef = value; }
    }
    private int _acc;
    public int Acc
    {
        get { return _acc; }
        set { _acc = value; }
    }
    private int _originalAcc;
    public int OriginalAcc
    {
        get { return _originalAcc; }
        set { _originalAcc = value; }
    }
    private int _eva;
    public int Eva
    {
        get { return _eva; }
        set { _eva = value; }
    }
    private int _originalEva;
    public int OriginalEva
    {
        get { return _originalEva; }
        set { _originalEva = value; }
    }
    private int _res;
    public int Res
    {
        get { return _res; }
        set { _res = value; }
    }
    private int _originalRes;
    public int OriginalRes
    {
        get { return _originalRes; }
        set { _originalRes = value; }
    }
    private int _mnd;
    public int Mnd
    {
        get { return _mnd; }
        set { _mnd = value; }
    }
    private int _originalMnd;
    public int OriginalMnd
    {
        get { return _originalMnd; }
        set { _originalMnd = value; }
    }
    private int _int;
    public int Int
    {
        get { return _int; }
        set { _int = value; }
    }
    private int _originalInt;
    public int OriginalInt
    {
        get { return _originalInt; }
        set { _originalInt = value; }
    }
    private int _jump;
    public int Jump
    {
        get { return _jump; }
        set { _jump = value; }
    }
    private int _originalJump;
    public int OriginalJump
    {
        get { return _originalJump; }
        set { _originalJump = value; }
    }
    private int _moveDistance;
    public int MoveDistance
    {
        get { return _moveDistance; }
        set { _moveDistance = value; }
    }
    private int _originalMoveDistance;
    public int OriginalMoveDistance
    {
        get { return _originalMoveDistance; }
        set { _originalMoveDistance = value; }
    }

    //Permanent Info
    private bool _playerSide;
    public bool PlayerSide
    {
        get { return _playerSide; }
        set { _playerSide = value; }
    }

    private string _spriteName;
    public string SpriteName
    {
        get { return _spriteName; }
        set { _spriteName = value; }
    }

    private string _characterName;
    public string CharacterName
    {
        get { return _characterName; }
        set { _characterName = value; }
    }

    private bool _playerControlled;
    public bool PlayerControlled
    {
        get { return _playerControlled; }
        set { _playerControlled = value; }
    }

    //Field coordinates
    private int _x;
    public int X
    {
        get { return _x; }
        set { _x = value; }
    }
    private int _z;
    public int Z
    {
        get { return _z; }
        set { _z = value; }
    }

    //Equipped items
    public Weapons EquippedMH;
    public Weapons EquippedOH;
    public Equipment EquippedHelmet;
    public Equipment EquippedChest;
    public Equipment EquippedFootwear;
    public MiscItems[] EquippedMiscItems = new MiscItems[4];
    public ActionTome[] EquippedActionTomes = new ActionTome[4];
    public SkillInfo[] EquippedSkills = new SkillInfo[4];

    //All actions/items/skills owned by character
    public List<BattleAction> ActionsList = new List<BattleAction>();
    public List<SkillInfo> SkillsList = new List<SkillInfo>();
    public List<MiscItems> ItemsList = new List<MiscItems>();
    public List<SkillInfo> AllSkills = new List<SkillInfo>();

    //AI priorities
    public List<uint> MovesPriority = new List<uint>();
    public List<uint> ClassAttackPriority = new List<uint>();

    public CharacterStats(
        int hp,
        int maxHp,
        int mp,
        int maxMp,
        int str,
        int mnd,
        int def,
        int res,
        int acc,
        int eva,
        int inte,
        int jump,
        int moveDistance,
        bool playerSide,
        string spriteName,
        string characterName,
        bool playerControlled
    )
    {
        _hp = hp;
        _maxHp = maxHp;
        _mp = mp;
        _maxMp = maxMp;
        _str = str;
        _originalStr = str;
        _mnd = mnd;
        _originalMnd = mnd;
        _def = def;
        _originalDef = def;
        _acc = acc;
        _originalAcc = acc;
        _eva = eva;
        _originalEva = eva;
        _int = inte;
        _originalInt = inte;
        _res = res;
        _originalRes = res;
        _jump = jump;
        _originalJump = jump;
        _moveDistance = moveDistance;
        _originalMoveDistance = moveDistance;
        _spriteName = spriteName;
        _characterName = characterName;
        _playerControlled = playerControlled;
        _playerSide = playerSide;
        _x = 0;
        _z = 0;
    }
}