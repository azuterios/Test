using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Braces
{
    class Program
    {
        static void Main(string[] args)
        {
            //        string[] values = { //HAPPY {
            //		"{}", "{{{}}}","{}{{}}{}",
            //		//FAIL
            //		"}","{", "{{}", "}}{}",

            //		//HAPPY (
            //		"()", "()()", "(())", "()(())()",

            //		//FAIL
            //		"(()",")","(","())",

            //		//HAPPY
            //	"[]","[[]]","[][[]][]","[[[[]]]]",

            //		//FAIL
            //		"[","]","[[","[]]",

            //		//HAPPY
            //		"{}[]()","({})","[[(({{}}))]]",

            //		//FAIL
            //		"{{}[[)","(){[}]","))}{[]"

            //};
            int testCasesCount = Convert.ToInt32(Console.ReadLine());
            var inputTestCases = new List<string>();

            for(int i=0; i < testCasesCount; i++)
            {
                var value = Console.ReadLine();
                inputTestCases.Add(value);

            }

            string[] values = inputTestCases.ToArray();
            var inputValidator = new InputValidator();
            bool isValidInput = inputValidator.IsValidInput(values);


            if (isValidInput == false)
            {
                Console.WriteLine("Invalid data detected");
                Console.ReadLine();
                return;
            }


            //validate inputcheck test cases count
            //bool isValidValuesCount = values.Length>=1 && values.Length <=15;

            //bool isValidInput &= CheckEachTestCAse
            //	foreach(string value in values)
            //	{
            //		if(isValidInput.CheckValueCharacters(value) == false)
            //		{
            //			Console.WriteLine("Invalid characted detected.");
            //			return;
            //		}
            //		
            //		if(isValidInput.CheckValueLength(value) == false)
            //		{
            //			Console.WriteLine("Invalid value length.");
            //			return;
            //		}
            //		
            //	}
            //	
            //	if(isValidInput.CheckValuesCount(values) == false)
            //	{
            //		Console.WriteLine("Invalid length for array of values");
            //		return;
            //	}

            //ready for procesing
            var testCases = new List<string>(values);

            var bracesBalanceValidator = new BracesBalanceValidator();
            var results = new List<string>();

            foreach (string testCase in testCases)
            {
                string result = null;
                if (bracesBalanceValidator.CheckBraces(testCase))
                {
                    result = "YES";
                }
                else
                {
                    result = "NO";
                }

                results.Add(result);
            }

            foreach(string result in results)
            {
                Console.WriteLine(result);
            }
            Console.ReadLine();

        }
    }
    public static class StackExtensions
    {
        public static bool IsEmpty(this Stack stack)
        {
            return (stack.Count == 0);
        }
    }

    public class BracesBalanceValidator
    {

        public bool CheckBraces(string value)
        {
            bool isBalanced = true;


            System.Collections.Stack stack = new Stack();


            for (int i = 0; i < value.Length; i++)
            {

                char brace = (char)value[i];

                if (brace == '{' || brace == '(' || brace == '[')
                {
                    stack.Push(brace);
                }
                else if (brace == '}')
                {
                    if (stack.IsEmpty())
                    {
                        isBalanced = false;
                    }
                    else if ((char)stack.Peek() == '{')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        isBalanced = false;
                    }
                }
                else if (brace == ')')
                {
                    if (stack.IsEmpty())
                    {
                        isBalanced = false;
                    }
                    else if ((char)stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        isBalanced = false;
                    }
                }
                else if (brace == ']')
                {
                    if (stack.IsEmpty())
                    {
                        isBalanced = false;
                    }
                    else if ((char)stack.Peek() == '[')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        isBalanced = false;
                    }
                }

            }



            if (!(stack.IsEmpty()) || isBalanced == false)
            {
                isBalanced = false;
            }


            return isBalanced;

        }
    }

    public class InputValidator
    {

        public bool IsValidInput(string[] values)
        {
            //check test cases count
            if (CheckValuesCount(values) == false)
            {
                return false;
            }

            //check each test case value
            bool result = true;
            foreach (string value in values)
            {
                //result &= CheckForValidCharacters(value);
                if (CheckForValidCharacters(value) == false)
                {
                
                    result = false;
                };
            }

            return result;
        }

        private bool CheckValueLength(string value)
        {
            bool isValid = false;

            if (value.Length >= 1 && value.Length <= 100)
            {
                isValid = true;
            }
            return isValid;
        }

        private bool CheckForValidCharacters(string value)
        {
            //			bool isValid = true;

            foreach (char testChar in value.ToCharArray())
            {

                if ((testChar == '{' || testChar == '(' || testChar == '[' || testChar == '}' || testChar == ')' || testChar == ']') == false)
                {
                    return false;
                }
            }

            return true;

            //			for(int i=0; i < value.Length; i++)
            //			{
            //				char testChar = (char)value[i];
            //
            //				if((testChar == '{' || testChar == '(' || testChar == '[' || testChar == '}' || testChar == ')' || testChar == ']') == false)
            //				{	
            //					isValid = false;
            //					break;
            //				}
            //			}
            //		
            //			return isValid;
        }

        public bool CheckValuesCount(string[] values)
        {
            bool isValid = false;

            if (values.Length >= 1 && values.Length <= 230)
            {

                isValid = true;
            }

            return isValid;

        }
    }
}
