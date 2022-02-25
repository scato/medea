/*
 * WARNING: this file has been generated by
 * Hime Parser Generator 3.5.1.0
 */
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Hime.Redist;
using Hime.Redist.Parsers;

namespace Medea.Core.Parser
{
	/// <summary>
	/// Represents a parser
	/// </summary>
	[GeneratedCodeAttribute("Hime.SDK", "3.5.1.0")]
	public class MedeaParser : LRkParser
	{
		/// <summary>
		/// The automaton for this parser
		/// </summary>
		private static readonly LRkAutomaton commonAutomaton = LRkAutomaton.Find(typeof(MedeaParser), "MedeaParser.bin");
		/// <summary>
		/// Contains the constant IDs for the variables and virtuals in this parser
		/// </summary>
		[GeneratedCodeAttribute("Hime.SDK", "3.5.1.0")]
		public class ID
		{
			/// <summary>
			/// The unique identifier for variable Script
			/// </summary>
			public const int VariableScript = 0x000A;
			/// <summary>
			/// The unique identifier for variable Statement
			/// </summary>
			public const int VariableStatement = 0x000B;
			/// <summary>
			/// The unique identifier for variable Query
			/// </summary>
			public const int VariableQuery = 0x000C;
			/// <summary>
			/// The unique identifier for variable ReadingClause
			/// </summary>
			public const int VariableReadingClause = 0x000D;
			/// <summary>
			/// The unique identifier for variable Load
			/// </summary>
			public const int VariableLoad = 0x000E;
			/// <summary>
			/// The unique identifier for variable Match
			/// </summary>
			public const int VariableMatch = 0x000F;
			/// <summary>
			/// The unique identifier for variable UpdatingClause
			/// </summary>
			public const int VariableUpdatingClause = 0x0010;
			/// <summary>
			/// The unique identifier for variable Return
			/// </summary>
			public const int VariableReturn = 0x0011;
			/// <summary>
			/// The unique identifier for variable Pattern
			/// </summary>
			public const int VariablePattern = 0x0012;
			/// <summary>
			/// The unique identifier for variable PrimaryPattern
			/// </summary>
			public const int VariablePrimaryPattern = 0x0013;
			/// <summary>
			/// The unique identifier for variable StringPattern
			/// </summary>
			public const int VariableStringPattern = 0x0014;
			/// <summary>
			/// The unique identifier for variable Expression
			/// </summary>
			public const int VariableExpression = 0x0015;
			/// <summary>
			/// The unique identifier for variable CallExpression
			/// </summary>
			public const int VariableCallExpression = 0x0016;
			/// <summary>
			/// The unique identifier for variable Arguments
			/// </summary>
			public const int VariableArguments = 0x0017;
			/// <summary>
			/// The unique identifier for variable Argument
			/// </summary>
			public const int VariableArgument = 0x0018;
			/// <summary>
			/// The unique identifier for variable SpreadArgument
			/// </summary>
			public const int VariableSpreadArgument = 0x0019;
			/// <summary>
			/// The unique identifier for variable PrimaryExpression
			/// </summary>
			public const int VariablePrimaryExpression = 0x001A;
			/// <summary>
			/// The unique identifier for variable IdentifierReference
			/// </summary>
			public const int VariableIdentifierReference = 0x001B;
			/// <summary>
			/// The unique identifier for variable Literal
			/// </summary>
			public const int VariableLiteral = 0x001C;
			/// <summary>
			/// The unique identifier for variable NumericLiteral
			/// </summary>
			public const int VariableNumericLiteral = 0x001D;
			/// <summary>
			/// The unique identifier for variable StringLiteral
			/// </summary>
			public const int VariableStringLiteral = 0x001E;
			/// <summary>
			/// The unique identifier for variable RegularExpressionLiteral
			/// </summary>
			public const int VariableRegularExpressionLiteral = 0x001F;
		}
		/// <summary>
		/// The collection of variables matched by this parser
		/// </summary>
		/// <remarks>
		/// The variables are in an order consistent with the automaton,
		/// so that variable indices in the automaton can be used to retrieve the variables in this table
		/// </remarks>
		private static readonly Symbol[] variables = {
			new Symbol(0x000A, "Script"), 
			new Symbol(0x000B, "Statement"), 
			new Symbol(0x000C, "Query"), 
			new Symbol(0x000D, "ReadingClause"), 
			new Symbol(0x000E, "Load"), 
			new Symbol(0x000F, "Match"), 
			new Symbol(0x0010, "UpdatingClause"), 
			new Symbol(0x0011, "Return"), 
			new Symbol(0x0012, "Pattern"), 
			new Symbol(0x0013, "PrimaryPattern"), 
			new Symbol(0x0014, "StringPattern"), 
			new Symbol(0x0015, "Expression"), 
			new Symbol(0x0016, "CallExpression"), 
			new Symbol(0x0017, "Arguments"), 
			new Symbol(0x0018, "Argument"), 
			new Symbol(0x0019, "SpreadArgument"), 
			new Symbol(0x001A, "PrimaryExpression"), 
			new Symbol(0x001B, "IdentifierReference"), 
			new Symbol(0x001C, "Literal"), 
			new Symbol(0x001D, "NumericLiteral"), 
			new Symbol(0x001E, "StringLiteral"), 
			new Symbol(0x001F, "RegularExpressionLiteral"), 
			new Symbol(0x0021, "__V33"), 
			new Symbol(0x0029, "__V41"), 
			new Symbol(0x002D, "__V45"), 
			new Symbol(0x002F, "__VAxiom") };
		/// <summary>
		/// The collection of virtuals matched by this parser
		/// </summary>
		/// <remarks>
		/// The virtuals are in an order consistent with the automaton,
		/// so that virtual indices in the automaton can be used to retrieve the virtuals in this table
		/// </remarks>
		private static readonly Symbol[] virtuals = {
 };
		/// <summary>
		/// Initializes a new instance of the parser
		/// </summary>
		/// <param name="lexer">The input lexer</param>
		public MedeaParser(MedeaLexer lexer) : base (commonAutomaton, variables, virtuals, null, lexer) { }

		/// <summary>
		/// Visitor interface
		/// </summary>
		[GeneratedCodeAttribute("Hime.SDK", "3.5.1.0")]
		public class Visitor
		{
			public virtual void OnTerminalWhiteSpace(ASTNode node) {}
			public virtual void OnTerminalLineTerminator(ASTNode node) {}
			public virtual void OnTerminalSeparator(ASTNode node) {}
			public virtual void OnTerminalNumber(ASTNode node) {}
			public virtual void OnTerminalString(ASTNode node) {}
			public virtual void OnTerminalRegexp(ASTNode node) {}
			public virtual void OnTerminalIdentifier(ASTNode node) {}
			public virtual void OnVariableScript(ASTNode node) {}
			public virtual void OnVariableStatement(ASTNode node) {}
			public virtual void OnVariableQuery(ASTNode node) {}
			public virtual void OnVariableReadingClause(ASTNode node) {}
			public virtual void OnVariableLoad(ASTNode node) {}
			public virtual void OnVariableMatch(ASTNode node) {}
			public virtual void OnVariableUpdatingClause(ASTNode node) {}
			public virtual void OnVariableReturn(ASTNode node) {}
			public virtual void OnVariablePattern(ASTNode node) {}
			public virtual void OnVariablePrimaryPattern(ASTNode node) {}
			public virtual void OnVariableStringPattern(ASTNode node) {}
			public virtual void OnVariableExpression(ASTNode node) {}
			public virtual void OnVariableCallExpression(ASTNode node) {}
			public virtual void OnVariableArguments(ASTNode node) {}
			public virtual void OnVariableArgument(ASTNode node) {}
			public virtual void OnVariableSpreadArgument(ASTNode node) {}
			public virtual void OnVariablePrimaryExpression(ASTNode node) {}
			public virtual void OnVariableIdentifierReference(ASTNode node) {}
			public virtual void OnVariableLiteral(ASTNode node) {}
			public virtual void OnVariableNumericLiteral(ASTNode node) {}
			public virtual void OnVariableStringLiteral(ASTNode node) {}
			public virtual void OnVariableRegularExpressionLiteral(ASTNode node) {}
		}

		/// <summary>
		/// Walk the AST of a result using a visitor
		/// <param name="result">The parse result</param>
		/// <param name="visitor">The visitor to use</param>
		/// </summary>
		public static void Visit(ParseResult result, Visitor visitor)
		{
			VisitASTNode(result.Root, visitor);
		}

		/// <summary>
		/// Walk the sub-AST from the specified node using a visitor
		/// </summary>
		/// <param name="node">The AST node to start from</param>
		/// <param name="visitor">The visitor to use</param>
		public static void VisitASTNode(ASTNode node, Visitor visitor)
		{
			for (int i = 0; i < node.Children.Count; i++)
				VisitASTNode(node.Children[i], visitor);
			switch(node.Symbol.ID)
			{
				case 0x0003: visitor.OnTerminalWhiteSpace(node); break;
				case 0x0004: visitor.OnTerminalLineTerminator(node); break;
				case 0x0005: visitor.OnTerminalSeparator(node); break;
				case 0x0006: visitor.OnTerminalNumber(node); break;
				case 0x0007: visitor.OnTerminalString(node); break;
				case 0x0008: visitor.OnTerminalRegexp(node); break;
				case 0x0009: visitor.OnTerminalIdentifier(node); break;
				case 0x000A: visitor.OnVariableScript(node); break;
				case 0x000B: visitor.OnVariableStatement(node); break;
				case 0x000C: visitor.OnVariableQuery(node); break;
				case 0x000D: visitor.OnVariableReadingClause(node); break;
				case 0x000E: visitor.OnVariableLoad(node); break;
				case 0x000F: visitor.OnVariableMatch(node); break;
				case 0x0010: visitor.OnVariableUpdatingClause(node); break;
				case 0x0011: visitor.OnVariableReturn(node); break;
				case 0x0012: visitor.OnVariablePattern(node); break;
				case 0x0013: visitor.OnVariablePrimaryPattern(node); break;
				case 0x0014: visitor.OnVariableStringPattern(node); break;
				case 0x0015: visitor.OnVariableExpression(node); break;
				case 0x0016: visitor.OnVariableCallExpression(node); break;
				case 0x0017: visitor.OnVariableArguments(node); break;
				case 0x0018: visitor.OnVariableArgument(node); break;
				case 0x0019: visitor.OnVariableSpreadArgument(node); break;
				case 0x001A: visitor.OnVariablePrimaryExpression(node); break;
				case 0x001B: visitor.OnVariableIdentifierReference(node); break;
				case 0x001C: visitor.OnVariableLiteral(node); break;
				case 0x001D: visitor.OnVariableNumericLiteral(node); break;
				case 0x001E: visitor.OnVariableStringLiteral(node); break;
				case 0x001F: visitor.OnVariableRegularExpressionLiteral(node); break;
			}
		}
	}
}
