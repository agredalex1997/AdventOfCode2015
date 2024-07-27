using System.Diagnostics.Tracing;
using System.Text.Json;

namespace AdventOfCode
{
    internal class Instruction
    {
        public string variableName { get; set; }
        public string[] assignmentTokens { get; set; }
        public ushort? solution { get; set; } = null;

        public Instruction(string varName, string[] tokens)
        {
            variableName = varName;
            assignmentTokens = tokens;
        }
    }

    internal class Program
    {
        private static List<Instruction> instructions = new();
        private static void Main(string[] args)
        {
            try
            {
                using (StreamReader reader = new("Inputs/Day7.txt"))
                {
                    while (reader.Peek() >= 0)
                    {
                        string? line = reader.ReadLine();
                        string[] parts = line.Split(" -> ");
                        string assignment = parts[0];
                        string variableName = parts[1];

                        instructions.Add(new Instruction(variableName, assignment.Split(' ')));
                    }

                    Solve("a");

                    // Console.Write(JsonSerializer.Serialize(instructions.Where(x => x.solution != null), new JsonSerializerOptions() { WriteIndented = true }));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static ushort Solve(string variable)
        {

            List<string> operators = new() { "AND", "OR", "NOT", "LSHIFT", "RSHIFT" };

            Instruction instructionToSolve = instructions.Find(x => x.variableName == variable);

            Console.WriteLine($"Solving {variable} = {string.Join(' ', instructionToSolve.assignmentTokens)}");

            if (instructionToSolve.solution != null)
            {
                return (ushort)instructionToSolve.solution;
            }
            else
            {
                if (instructionToSolve.assignmentTokens.Length == 1)
                {
                    // 123 -> x
                    if (ushort.TryParse(instructionToSolve.assignmentTokens[0], out ushort value))
                    {
                        instructionToSolve.solution = value;
                    }
                    // y -> x
                    else
                    {
                        instructionToSolve.solution = Solve(instructionToSolve.assignmentTokens[0]);
                    }
                }
                else if (instructionToSolve.assignmentTokens.Length == 2)
                {
                    // NOT 123 -> x
                    if (ushort.TryParse(instructionToSolve.assignmentTokens[1], out ushort value))
                    {
                        instructionToSolve.solution = (ushort?)~value;
                    }
                    // NOT y -> x
                    else
                    {
                        instructionToSolve.solution = (ushort?)~Solve(instructionToSolve.assignmentTokens[1]);
                    }
                }
                else
                {
                    if (!ushort.TryParse(instructionToSolve.assignmentTokens[0], out ushort firstValue))
                    {
                        firstValue = Solve(instructionToSolve.assignmentTokens[0]);
                    }

                    if (!ushort.TryParse(instructionToSolve.assignmentTokens[2], out ushort secondValue))
                    {
                        secondValue = Solve(instructionToSolve.assignmentTokens[2]);
                    }

                    switch (instructionToSolve.assignmentTokens[1])
                    {
                        case "AND":
                            instructionToSolve.solution = (ushort?)(firstValue & secondValue);
                            break;
                        case "OR":
                            instructionToSolve.solution = (ushort?)(firstValue | secondValue);
                            break;
                        case "LSHIFT":
                            instructionToSolve.solution = (ushort?)(firstValue << secondValue);
                            break;
                        case "RSHIFT":
                            instructionToSolve.solution = (ushort?)(firstValue >> secondValue);
                            break;
                    }
                }
            }

            Console.WriteLine($"{variable} = {instructionToSolve.solution}");

            return (ushort)instructionToSolve.solution;
        }
    }
}