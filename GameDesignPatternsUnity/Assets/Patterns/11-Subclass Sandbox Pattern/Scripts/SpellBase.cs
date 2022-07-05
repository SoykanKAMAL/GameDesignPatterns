using UnityEngine;

namespace SubclassSandboxPattern
{
    public abstract class SpellBase
    {
        public string target;
        public int spellValue;
        
        public SpellBase(string target, int spellValue)
        {
            this.target = target;
            this.spellValue = spellValue;
        }
        
        public void Heal(string target, int amount)
        {
            Debug.Log($"Healing {target} for {amount}");
        }
        
        public void Damage(string target, int amount)
        {
            Debug.Log($"Damaging {target} for {amount}");
        }
        
        public void PlaySoundEffect(string sound)
        {
            Debug.Log($"Playing sound effect: {sound}");
        }
        
        public void PlayFX(string fx)
        {
            Debug.Log($"Playing FX: {fx}");
        }
        
        public abstract void Cast();
    }
}