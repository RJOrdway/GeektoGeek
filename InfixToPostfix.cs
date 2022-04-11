using System;
using System.Collections.Generic;
			
/*
 * 	Currently fails due to me not understanding Indian people instructions
 */
			
public class Program
{
	static void Main()
	{
		string input = "a+b*(c^d-e)^(f+g*h)-i";
		
		char[] final = new char[infixToPostfix(input)];
		
		Stack<char> operators = new Stack<char>();
		Stack<char> temp = new Stack<char>();
		
		Dictionary<char, int> pemdas = new Dictionary<char, int>();
		pemdas['+'] = 0;
		pemdas['-'] = 0;
		pemdas['*'] = 1;
		pemdas['/'] = 1;
		pemdas['^'] = 2;
		
		//1st operator to stack
		int i = 0;
		for (i = 0; !pemdas.ContainsKey(input[i]); i++)
		{
			Console.WriteLine(input[i]);
			final[i] = input[i];
		}

		int j = i; // keeps track of result string index
		
		for (i = i; i < input.Length; i++)
		{
			if (input[i] == '(')
			{
				operators.Push(input[i]);
			}
			else if (input[i] == ')')
			{
				while (operators.Peek() != '(')
				{
					temp.Push(operators.Pop());
				}
				operators.Pop(); // delete '('
				while (temp.Count > 0)
				{
					operators.Push(temp.Pop());
				}
			}
			else if ( pemdas.ContainsKey(input[i]) )
			{
				bool breakout = false; // replacement for long while condition
				while (breakout == false)
				{
					if (operators.Count == 0)
					{
						breakout = true;
					}
					else if (operators.Peek() == '(') // pop (
					{
						temp.Push(operators.Pop());
					}
					else if (pemdas[input[i]] <= pemdas[operators.Peek()]) // pop greater than or = preced.
					{
						temp.Push(operators.Pop());
					}
					else
					{
						breakout = true;
					}
				}
				// Close out pemdas swap
				operators.Push(input[i]);
				while (temp.Count > 0)
				{
					operators.Push(temp.Pop());
				}
			} // end of pemdas swap
			else // must be operand
			{
			final[j] = input[i];
			j++;
			}
		}
		// unload operator stack
		Console.WriteLine("After operators built");
		while (operators.Count > 0)
		{
			final[j] = operators.Pop();
			j++;
		}
		Console.WriteLine(final);
		

		static int infixToPostfix(string original)
		{
			int postfixLength = 0;
			foreach (char element in original) 
				if (element != '(' && element != ')')
				{
					postfixLength++;
				}
			return postfixLength;
		}
	}
}