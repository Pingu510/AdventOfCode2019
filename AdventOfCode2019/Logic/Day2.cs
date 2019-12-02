namespace AdventOfCode2019.Logic
{
    public static class Day2
    {

        public static int[] ResetComputer(int noun, int verb)
        {
            int[] input = Helper.FileHandler.GetInput("input_02");
            input[1] = noun;
            input[2] = verb;

            return input;
        }

        public static int[] CalculateStartValues(int output)
        {
            for (int noun = 0; noun <= 99; noun++)
            {
                for (int verb = 0; verb <= 99; verb++)
                {
                    if (RunComupter(ResetComputer(noun, verb)) == output)
                    {
                        return new int[] { noun, verb };
                    }
                }
            }
            return null;
        }

        public static int RunComupter(int[] input)
        {
            for (int i = 0; i < input.Length;)
            {
                switch (input[i])
                {
                    case 1:
                        input[input[i + 3]] = input[input[i + 1]] + input[input[i + 2]];
                        break;
                    case 2:
                        input[input[i + 3]] = input[input[i + 1]] * input[input[i + 2]];
                        break;
                    case 99:
                        return input[0];
                    default:
                        return -1;
                }
                i += 4;
            }
            return -1;
        }
    }
}
