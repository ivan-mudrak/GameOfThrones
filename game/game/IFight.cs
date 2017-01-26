namespace game
{
    enum BattleResult
    {
        Win = 1,
        Draw = 0,
        Lose = -1
    }

    interface IFight
    {
        BattleResult Attack(Kingdom otherKingdom);
        int Defend(Kingdom otherKingdom);
    }
}
