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
		int j = 0;
		
		for (i = 0; i < input.Length; i++)
		{
			if 