using SDDefine;

public partial class CharacterStatTable
{
    public CharacterStat GetStat(int idx)
    {
        if (idx >= CharacterStatList.Count)
            return null;

        return CharacterStatList?[idx];
    }

    public CharacterStat GetStat(ENUM_CHARACTER characterEnum)
    {
        if (characterEnum == ENUM_CHARACTER.None ||
            !CharacterStatDictionary.ContainsKey((int)characterEnum))
            return null;

        return CharacterStatDictionary[(int)characterEnum];
    }
}
