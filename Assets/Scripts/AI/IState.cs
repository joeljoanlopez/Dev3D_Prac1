public interface IState
{
    void OnEnter(FSM fsm);
    void OnStay(FSM fsm);
    void OnExit(FSM fsm);
}