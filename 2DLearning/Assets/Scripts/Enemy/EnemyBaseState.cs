
// NOTE: 抽象类。本质就是个 protocol
public abstract class EnemyBaseState
{
    public abstract void EnterState(Enemy enemy) ;
    public abstract void OnUpdate(Enemy enemy);
}
