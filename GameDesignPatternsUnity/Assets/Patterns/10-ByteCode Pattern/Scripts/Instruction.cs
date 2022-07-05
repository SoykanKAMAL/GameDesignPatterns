using UnityEngine;

namespace BytecodePattern
{
    [System.Serializable]
    public class Instruction
    {
        public InstructionType type;
        public float value;
        public Instruction (InstructionType type, float value)
        {
		    this.type = type;
            this.value = value;
        }
    }

    public enum InstructionType
    {
        INSTRUCTIONS_START,
        CHANGE_SIZE,
        CHANGE_SPEED,
        INSTRUCTIONS_STOP
    }
}