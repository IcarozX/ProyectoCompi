parser grammar ParserProyecto;

@header {
using System;
}

options {
language = CSharp;
tokenVocab = LexerProyecto;
}
/*
* Parser Rules
*/

program	: Class Ident ( constDecl | varDecl | classDecl )* CorIZQ ( methodDecl )* CorDER     #progAST//falta ciclo
; 

constDecl	: Const Type Ident ASIGN ( Num | ConsChar ) PyCOMA									 #costDeAST;

varDecl	: type Ident ( COMA Ident )* PyCOMA															#varDeclAST	;//*

classDecl	: Class Ident CorIZQ ( VarDecl )* CorDER											#classDeclAst;//ya

methodDecl	: ( type | Void ) Ident ParIZQ ( formPars )* ParDER CorIZQ ( VarDecl )* Block CorDER  #methoAST;
formPars : Type Ident ( PyComa type Ident )*													 #formPAST ;
type	: Ident ( ParCuIZQ ParCuDER | )															 #typeAST;

statement: 
			Designator ( ASIG expr | PIZQ ( actPars ) PDER  | MASMAS | Menos2 ) PyComa			 #statementAST
		 |  If PIZQ condition PDER statement (Else statement | )								 #ifStateAst
		 |  For PIZQ expr PyComa (condition |) PyComa (Statement |) PDER CorIZQ statement CorDER  #forSteAST
		 |  While PIZQ condition PDER statement													#whileSteAST
		 | Foreach																				#foreachSteAST
		 |  Breack PyCOMA																		#breakSteAST
		 |  Return ( expr | ) PyComa															#returSteAST	
		 |  Read PIZQ designator PDER PyCOMA													#readSteAST
		 |  Write PIZQ expr ( COMA NUM | ) PDER PyCOMA											#writeSteAST
		 |  block																				#blockSteAST
		 |  PyCOMA																			    #comaAST 
		 ;

block	:
	 CorIZQ ( statement | ) CorDER														#blockAST
	 ;
actPars	: expr ( COMA expr | )																#actpaAST;
condition	: condTerm ( OR condTerm |)														  #condicionAST;
condTerm	: condFact ( Y condFact | )														 #condicionTerAST;
condFact	: expr relop expr																#condFAcAST;
expr		: ( Resta )* term ( addop term | )											 #exprAST;
term		: factor ( mulop factor | )														#termAST;
factor		:  designator ( PIZQ ( actPars )* PDER )*								#factorAST
		 |  NUM																		#numFactorAST
		 |  ConsChar																#consFactASt
		 |  (True | False)															#boolSteAST
		 |  New Ident ( ParCuIZQ expr ParCuDER )*									#newFactAST
		 |  PIZQ expr PDER															#expFactAST;
designator	: Ident ( Py Ident | ParCuIZQ expr ParCuDER )*							#designatorAST;
relop		: IgualIgual | Diferente | MayorQ | MayorIgual | MenorQ | MenorIgual	#relopAST;
addop		: SUMA | RESTA															#aDDAST;
mulop		:  MUL| Slash | Porce													#mulopAST;