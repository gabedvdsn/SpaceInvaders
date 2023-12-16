


public enum EnemyInstructionType
{
    GoAt,  // With some "" Entity reference
    StandbyAt,  // With "" Entity reference
    AttackAt,  // With some "Ally" Entity reference
    ProtectAt,  // With some "Enemy" Entity reference
    PrioritizeAt,  // With some secondary EnemyInstruction
    IgnoreAt,  // With some secondary EnemyInstruction
    LevelStatus, // With some secondary EnemyInstruction
    None
}

/*
StandByAt: Enemies effected will
PrioritizeAt: Enemies effected will ignore other instructions and prioritize the secondary instruction type
IgnoreAt: Enemies effected will ignore instructions of the secondary instruction type
LevelStats: Does not effect enemies; instead, will de-prioritize or de-ignore the secondary instruction type
*/

public class EnemyInstruction
{
    private EnemyInstructionType secondaryInstruction;
    private Entity target;

    public EnemyInstruction(Entity target, EnemyInstructionType secondaryInstruction = EnemyInstructionType.None)
    {
        this.target = target;
        this.secondaryInstruction = secondaryInstruction;
    }

    public Entity Get() => target;

    public EnemyInstructionType Secondary() => secondaryInstruction;
}