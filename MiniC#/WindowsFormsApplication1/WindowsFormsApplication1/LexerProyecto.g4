lexer grammar LexerProyecto;

WS
	:	' ' -> channel(HIDDEN)
	;

	NEWLINE 
: ('\n'| '\r'| '\t') -> channel(HIDDEN)
;

Break
	:'break';

Class
	: 'class';
	
Const
	 :'const';

Else
	:'else';

If
	:'if';

New
	: 'new';

True :'true';

False: 'false';
	
Read
	:'read';
	
Return
	:'return';
	
Void
	:'void';
While
	:'while';
For: 'for';
Write
	:'write';
Foreach:
	'foreach';


NUM
	: '0' | '1'..'9' ('0'..'9')*;

Letter
	: 'A'..'Z' | 'a'..'z';

Ident
:CharInicial CharContenido*;

LQUOTE : '"' -> more, mode(STRI) ;

fragment
CharContenido
: CharInicial
| '0'..'9'
| '_'
;
fragment
CharInicial
	: 'A'..'Z' | 'a'..'z';

ConsChar
	:'\u0027' ( PrintableChar | '\n' | '\r' ) '\u0027';

Ex: '!';
ComillaS: '\u0027';
PyCOMA : ';' ;
COMA : ',' ;
ASIGN : '=' ;
PIZQ : '(' ;
PDER : ')' ;
SUMA : '+' ;
RESTA:'-';
MUL : '*' ;
Comillas: '"';
Numeral: '#';
Dolar:'$';
Porce: '%';
Anpe:'&';
Py:'.';
Slash: '/';
TwoPy:':';
MenorQ:'<';
MayorQ:'>';

Pregunta: '?';

Arroba:'@';
IgualIgual:'==';
Diferete:'!=';
MayorIgual:'>=';
MenorIgual:'<=';

Y:'&&';
OR:'||';
MASMAS:'++';
Menos2:'--';
CorIZQ:'{';
CorDER:'}';
ParCuIZQ:'[';
ParCuDER:']';


PrintableChar
	:(Ex | PyCOMA | COMA | ASIGN|PIZQ|PDER|SUMA|RESTA|MUL|Comillas
	|Numeral|Dolar|Porce|Anpe|Py|Slash|TwoPy|MenorQ|MayorQ|Arroba|Letter|NUM);


mode STRI;
	STR : '"' -> mode(DEFAULT_MODE) ; 
	TEXT : . -> more ;