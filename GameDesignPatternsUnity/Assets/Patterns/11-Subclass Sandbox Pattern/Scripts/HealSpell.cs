using SubclassSandboxPattern;

[System.Serializable]
public class HealSpell : SpellBase
{
    
    public HealSpell (string target, int spellValue) : base(target, spellValue)
    {
    }

    public override void Cast()
    {
        base.Heal(target, spellValue);
        base.PlayFX("Heal FX");
        base.PlaySoundEffect("Heal Sound");
    }
}