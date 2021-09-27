public class BeanEnemy : EnemyCombat
{
    public override void OnEnemyTurn()
    {
        Swing(); 
    }

    protected override void OnDefeat()
    {
        //Drops Exp, Items, Money, Consiquences, etc
    }
}