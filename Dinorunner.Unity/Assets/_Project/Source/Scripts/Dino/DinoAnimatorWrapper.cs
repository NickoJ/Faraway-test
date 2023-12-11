using UnityEngine;

namespace NickoJ.DinoRunner.Scripts.Dino
{
    public sealed class DinoAnimatorWrapper : MonoBehaviour
    {
        enum AnimatorState
        {
            NotDefined,
            Idle,
            Move,
            Run,
            Jump,
            Fly
        }

        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int Move = Animator.StringToHash("Move");
        private static readonly int Run = Animator.StringToHash("Run");
        private static readonly int Jump = Animator.StringToHash("Jump");
        private static readonly int Fly = Animator.StringToHash("Fly");

        [SerializeField] private Animator animator;
        [SerializeField] private float maxWalkSpeed = 10;

        private AnimatorState _state;
        
        private void Awake()
        {
            animator = GetComponent<Animator>();
            SetIdle();
        }

        public void UpdateAnimation(float speed, float y, bool flying)
        {
            if (flying)
            {
                SetFly();
            }
            else if (y > 0)
            {
                SetJump();
            }
            else if (speed <= 0f)
            {
                SetIdle();
            }
            else if (speed <= maxWalkSpeed)
            {
                SetMove();
            }
            else
            {
                SetRun();
            }
        }

        private void SetFly() => SetTrigger(Fly, AnimatorState.Fly);
        private void SetJump() => SetTrigger(Jump, AnimatorState.Jump);
        private void SetIdle() => SetTrigger(Idle, AnimatorState.Idle);
        private void SetMove() => SetTrigger(Move, AnimatorState.Move);
        private void SetRun() => SetTrigger(Run, AnimatorState.Run);

        private void SetTrigger(int trigger, AnimatorState state)
        {
            if (_state == state) return;
            
            animator.SetTrigger(trigger);

            _state = state;
            Debug.Log(_state);
        }
    }
}