public class UnitFSM: FSM{
    public int ID;

    public UnitFSM( IState state, int unit_ID ) : base(state) {
        this.ID = unit_ID;
    }
}
