using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BytecodePattern
{
    public class BytecodeInterpreter : MonoBehaviour
    {
        //Public Fields
        public List<string> validInstructionTypes;
        public List<Instruction> instructions = new List<Instruction>();
		public TextAsset inputFile;

		#region Unity methods

		private void Start()
		{
			validInstructionTypes = Enum.GetValues(typeof(InstructionType)).Cast<InstructionType>().Select(x => x.ToString()).ToList();
			ParseInstructions();
		}

		#endregion

		#region Private methods

		private void ParseInstructions()
		{
			bool startParsing = false;
			string[] lines = inputFile.text.Split('\n');
			foreach (string line in lines)
			{
				var instructionType = "";
				var value = Int32.MinValue;
				if (line.Length <= 0) continue;
				
				if (!line.StartsWith("#")) continue;
				
				var parts = line.Split(' ');
				if (parts.Length < 2)
				{
					instructionType = parts[0].Split(';')[0].Split('#')[1];
				}
				else
				{
					instructionType = parts[0].Split('#')[1];
					value = Int32.Parse(parts[1].Split(';')[0]);
				}

				// Check if instructionType is valid
				if(!validInstructionTypes.Contains(instructionType)) continue;

				var enumType = (InstructionType)System.Enum.Parse(typeof(InstructionType), instructionType);
				
				if(enumType == InstructionType.INSTRUCTIONS_START)
				{
					startParsing = true;
					continue;
				}

				if (enumType == InstructionType.INSTRUCTIONS_STOP) break;
				
				if(!startParsing) continue;
				
				instructions.Add(new Instruction(enumType, value));
			}
		}
		
		#endregion
    }
}