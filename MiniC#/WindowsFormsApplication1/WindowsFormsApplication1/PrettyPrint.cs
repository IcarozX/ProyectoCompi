using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using WindowsFormsApplication1;
//using System.Windows.Forms;

class PrettyPrint : ParserProyectoBaseVisitor<Object>
{

    //private TextBoxBase contenedor;
    private Object contenedor;
    private int cont;

    public PrettyPrint(Object container)
    {
        //contenedor = (TextBoxBase)container;
        contenedor = null;
        cont = 0;
    }

    public void print(Object where, String what, bool nl)
    {
        if (where != null)
        {
        /*    if (where is TextBoxBase)
            {
                if (nl)
                    ((TextBoxBase) where).AppendText(what+"\n");
                else
                    ((TextBoxBase) where).AppendText(what);
            }
            else
                Console.WriteLine("Error al imprimir!!!");*/
        }
        else
        {
            if (nl)
                Console.WriteLine(what);
            else
                Console.Write(what);
        }

    }
  
    public void printtab(int n)
    {
        for(int num=n; num != 0; num--)
            print(contenedor,"+++",false);
        print(contenedor,">",false);
    }

    public override Object VisitCostDeAST([NotNull] ParserProyecto.CostDeASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>condFAcAST</c>
	/// labeled alternative in <see cref="ParserProyecto.condFact"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitCondFAcAST([NotNull] ParserProyecto.CondFAcASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>formPAST</c>
	/// labeled alternative in <see cref="ParserProyecto.formPars"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitFormPAST([NotNull] ParserProyecto.FormPASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>condicionAST</c>
	/// labeled alternative in <see cref="ParserProyecto.condition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitCondicionAST([NotNull] ParserProyecto.CondicionASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>varDeclAST</c>
	/// labeled alternative in <see cref="ParserProyecto.varDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
    public override Object VisitVarDeclAST([NotNull] ParserProyecto.VarDeclASTContext context) {
        printtab(cont);
        print(contenedor, context.GetType().Name, true);

        cont++;
        Visit(context.type());
        print(contenedor, context.Ident(0).GetText(), true);
        for (int i = 1; i <= context.Ident().Length; i++) {
            print(contenedor, context.COMA(i-1).GetText(), true);
            print(contenedor, context.Ident(i).GetText(), true);
        }
        cont--;

            return null;

    }

	/// <summary>
	/// Visit a parse tree produced by the <c>blockAST</c>
	/// labeled alternative in <see cref="ParserProyecto.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitBlockAST([NotNull] ParserProyecto.BlockASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>exprAST</c>
	/// labeled alternative in <see cref="ParserProyecto.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitExprAST([NotNull] ParserProyecto.ExprASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>newFactAST</c>
	/// labeled alternative in <see cref="ParserProyecto.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitNewFactAST([NotNull] ParserProyecto.NewFactASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>boolSteAST</c>
	/// labeled alternative in <see cref="ParserProyecto.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitBoolSteAST([NotNull] ParserProyecto.BoolSteASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>expFactAST</c>
	/// labeled alternative in <see cref="ParserProyecto.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitExpFactAST([NotNull] ParserProyecto.ExpFactASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>factorAST</c>
	/// labeled alternative in <see cref="ParserProyecto.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitFactorAST([NotNull] ParserProyecto.FactorASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>numFactorAST</c>
	/// labeled alternative in <see cref="ParserProyecto.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitNumFactorAST([NotNull] ParserProyecto.NumFactorASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>consFactASt</c>
	/// labeled alternative in <see cref="ParserProyecto.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitConsFactASt([NotNull] ParserProyecto.ConsFactAStContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>designatorAST</c>
	/// labeled alternative in <see cref="ParserProyecto.designator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitDesignatorAST([NotNull] ParserProyecto.DesignatorASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>typeAST</c>
	/// labeled alternative in <see cref="ParserProyecto.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitTypeAST([NotNull] ParserProyecto.TypeASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>classDeclAst</c>
	/// labeled alternative in <see cref="ParserProyecto.classDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
    public override Object VisitClassDeclAst([NotNull] ParserProyecto.ClassDeclAstContext context) {
        printtab(cont);
        print(contenedor, context.GetType().Name, true);
        
        cont++;
        print(contenedor, context.Class().GetText(), true);
        print(contenedor, context.Ident().GetText(), true);
        print(contenedor, context.CorIZQ().GetText(), true);
        for (int i = 0; i <= context.VarDecl().Length; i++) {
            Visit(context.VarDecl(0));
        }
        print(contenedor, context.CorDER().GetText(), true);
            return null;
    }

	/// <summary>
	/// Visit a parse tree produced by the <c>statementAST</c>
	/// labeled alternative in <see cref="ParserProyecto.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitStatementAST([NotNull] ParserProyecto.StatementASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>forSteAST</c>
	/// labeled alternative in <see cref="ParserProyecto.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitForSteAST([NotNull] ParserProyecto.ForSteASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>ifStateAst</c>
	/// labeled alternative in <see cref="ParserProyecto.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitIfStateAst([NotNull] ParserProyecto.IfStateAstContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>breakSteAST</c>
	/// labeled alternative in <see cref="ParserProyecto.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitBreakSteAST([NotNull] ParserProyecto.BreakSteASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>whileSteAST</c>
	/// labeled alternative in <see cref="ParserProyecto.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitWhileSteAST([NotNull] ParserProyecto.WhileSteASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>blockSteAST</c>
	/// labeled alternative in <see cref="ParserProyecto.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitBlockSteAST([NotNull] ParserProyecto.BlockSteASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>returSteAST</c>
	/// labeled alternative in <see cref="ParserProyecto.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitReturSteAST([NotNull] ParserProyecto.ReturSteASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>comaAST</c>
	/// labeled alternative in <see cref="ParserProyecto.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitComaAST([NotNull] ParserProyecto.ComaASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>writeSteAST</c>
	/// labeled alternative in <see cref="ParserProyecto.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitWriteSteAST([NotNull] ParserProyecto.WriteSteASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>readSteAST</c>
	/// labeled alternative in <see cref="ParserProyecto.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitReadSteAST([NotNull] ParserProyecto.ReadSteASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>foreachSteAST</c>
	/// labeled alternative in <see cref="ParserProyecto.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitForeachSteAST([NotNull] ParserProyecto.ForeachSteASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>termAST</c>
	/// labeled alternative in <see cref="ParserProyecto.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitTermAST([NotNull] ParserProyecto.TermASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>condicionTerAST</c>
	/// labeled alternative in <see cref="ParserProyecto.condTerm"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitCondicionTerAST([NotNull] ParserProyecto.CondicionTerASTContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>progAST</c>
	/// labeled alternative in <see cref="ParserProyecto.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	
    
    public override Object VisitProgAST([NotNull] ParserProyecto.ProgASTContext context) {
        printtab(cont);
        print(contenedor, context.GetType().Name, true);
        
        cont++;
        print(contenedor, context.Class().GetText(), true);
        print(contenedor, context.Ident().GetText(), true);

        if(context.constDecl()!=null){
        Visit(context.constDecl());
        }
        else if (context.varDecl()!=null){
        Visit(context.varDecl());
        }
        else if(context.classDecl()!=null){
        Visit(context.classDecl());
        }
        print(contenedor,context.CorIZQ().GetText(),true);
         for (int i = 0; i <= context.methodDecl().Length - 1; i++)
        {
            Visit(context.methodDecl(0));
        }
        print(contenedor,context.CorDER().GetText(),true);
     
        
        cont--;
        return null;
    
    }


    public override Object VisitMethoAST([NotNull] ParserProyecto.MethoASTContext context) {
        printtab(cont);
        print(contenedor, context.GetType().Name, true);
        cont++;
        if (context.type() != null)
        {
            Visit(context.type());
        }
        else {
            print(contenedor, context.Void().GetText(), true);
        }
        print(contenedor, context.Ident().GetText(), true);
        print(contenedor, context.ParIZQ().GetText(), true);
        for (int i = 0; i <= context.formPars().Length; i++) {
            Visit(context.formPars(0));
        }
        print(contenedor, context.ParDER().GetText(), true);
        print(contenedor, context.CorIZQ().GetText(), true);

        for (int x = 0; x <= context.VarDecl().Length; x++)
        {
            print(contenedor, context.VarDecl(0).GetText(), true);
        }
        print(contenedor, context.Block().GetText(), true);
        print(contenedor, context.CorDER().GetText(), true);
        cont--;

            return null;
    }

	/// <summary>
	/// Visit a parse tree produced by the <c>actpaAST</c>
	/// labeled alternative in <see cref="ParserProyecto.actPars"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitActpaAST([NotNull] ParserProyecto.ActpaASTContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="ParserProyecto.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitProgram([NotNull] ParserProyecto.ProgramContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="ParserProyecto.constDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitConstDecl([NotNull] ParserProyecto.ConstDeclContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="ParserProyecto.varDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitVarDecl([NotNull] ParserProyecto.VarDeclContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="ParserProyecto.classDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitClassDecl([NotNull] ParserProyecto.ClassDeclContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="ParserProyecto.methodDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitMethodDecl([NotNull] ParserProyecto.MethodDeclContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="ParserProyecto.formPars"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitFormPars([NotNull] ParserProyecto.FormParsContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="ParserProyecto.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitType([NotNull] ParserProyecto.TypeContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="ParserProyecto.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitStatement([NotNull] ParserProyecto.StatementContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="ParserProyecto.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitBlock([NotNull] ParserProyecto.BlockContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="ParserProyecto.actPars"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitActPars([NotNull] ParserProyecto.ActParsContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="ParserProyecto.condition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitCondition([NotNull] ParserProyecto.ConditionContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="ParserProyecto.condTerm"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitCondTerm([NotNull] ParserProyecto.CondTermContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="ParserProyecto.condFact"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitCondFact([NotNull] ParserProyecto.CondFactContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="ParserProyecto.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitExpr([NotNull] ParserProyecto.ExprContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="ParserProyecto.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitTerm([NotNull] ParserProyecto.TermContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="ParserProyecto.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitFactor([NotNull] ParserProyecto.FactorContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="ParserProyecto.designator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitDesignator([NotNull] ParserProyecto.DesignatorContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="ParserProyecto.relop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitRelop([NotNull] ParserProyecto.RelopContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="ParserProyecto.addop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitAddop([NotNull] ParserProyecto.AddopContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="ParserProyecto.mulop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public override Object VisitMulop([NotNull] ParserProyecto.MulopContext context);
}
    


