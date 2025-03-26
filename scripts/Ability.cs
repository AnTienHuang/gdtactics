using Godot;
using System;
using System.Collections.Generic;

public enum AbilityType
{
    Damage,
    Heal,
    Buff,
    Debuff,
    Utility
}

public enum TargetType
{
    Self,
    SingleTarget,
    Area,
    AllAllies,
    AllEnemies
}

public class StatusEffect
{
    public string Name { get; set; }
    public float Duration { get; set; }
    public ValueModifier { get; set; }
    public AbilityType { get; set; }

    public virtual void Apply(BaseCharacter target)
    {
        //TODO
    }

    public virtual void Remove(BaseCharacter target)
    {
        // TODO
    }
}

public class Ability
{
    // Basic properties
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public AbilityType AbilityType { get; set; }
    public TargetType TargetType { get; set; }

    // Numeric properties
    public int Value { get; set; }
    public int ManaCost { get; set; }
    public int CoolDown { get; set; }
    public int Radius { get; set; }

    public List<StatusEffect> AppliedEffects { get; set; } = new List<StatusEffect>();

    public string IconPath { get; set; }
    public bool IsChanneled { get; set; }
    public int ChannelDuration { get; set; }

    public bool CanCast(BaseCharacter user)
    {
        // TODO
        // Check cd
        return user.CurrentMana >= ManaCost;
    }

    public void Execute(BaseCharacter user, Node target = null)
    {
        // TODO
        GD.Print($"{user.Name} used {Name} on {target}");
    }

}
