public interface IUnit {
    int MaxLife { get; set; }
    int CurrentLife { get; set; }
    float MoveSpeed { get; set; }
    int Armour { get; set; }
    bool IsAlive { get; }
}