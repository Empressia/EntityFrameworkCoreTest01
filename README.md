# 概要

このプロジェクトは、Entity Framework Coreでの動作の確認用に作っています。  

ソリューションをVisual Studioで開いて、Developer PowerShellから、以下のコマンドを実行すると、プリコンパイル済みのQueryを作ろうとしてUnreachableExceptionが発生します。  

```powershell
dotnet tool install dotnet-ef --local
dotnet build
dotnet dotnet-ef dbcontext optimize --no-scaffold --precompile-queries --nativeaot --no-build
```

> Query precompilation is an experimental feature and should be used with caution.
> NativeAOT support is experimental and can change in the future.
> System.InvalidOperationException: Query precompilation failed with errors:
> QueryPrecompilationError { SyntaxNode = context.Users.OrderBy(u => u.ID).Select(u => u.ID).ToListAsync(cancellationToken), Exception = System.Diagnostics.UnreachableException: IdentifierName of type ParameterSymbol: cancellationToken
>    at Microsoft.EntityFrameworkCore.Query.Internal.CSharpToLinqTranslator.VisitIdentifierName(IdentifierNameSyntax identifierName)
>    at Microsoft.CodeAnalysis.CSharp.Syntax.IdentifierNameSyntax.Accept[TResult](CSharpSyntaxVisitor`1 visitor)
>    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
>    at Microsoft.EntityFrameworkCore.Query.Internal.CSharpToLinqTranslator.Visit(SyntaxNode node)
>    at Microsoft.EntityFrameworkCore.Query.Internal.CSharpToLinqTranslator.Visit(SyntaxNode node, Type expectedType)
>    at Microsoft.EntityFrameworkCore.Query.Internal.CSharpToLinqTranslator.VisitArgument(ArgumentSyntax argument, Type expectedType)
>    at Microsoft.EntityFrameworkCore.Query.Internal.CSharpToLinqTranslator.Visit(SyntaxNode node, Type expectedType)
>    at Microsoft.EntityFrameworkCore.Query.Internal.CSharpToLinqTranslator.VisitInvocationExpression(InvocationExpressionSyntax invocation)
>    at Microsoft.CodeAnalysis.CSharp.Syntax.InvocationExpressionSyntax.Accept[TResult](CSharpSyntaxVisitor`1 visitor)
>    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
>    at Microsoft.EntityFrameworkCore.Query.Internal.CSharpToLinqTranslator.Visit(SyntaxNode node)
>    at Microsoft.EntityFrameworkCore.Query.Internal.CSharpToLinqTranslator.Translate(SyntaxNode node, SemanticModel semanticModel)
>    at Microsoft.EntityFrameworkCore.Query.Internal.PrecompiledQueryCodeGenerator.ProcessSyntaxTree(SyntaxTree syntaxTree, SemanticModel semanticModel, IReadOnlyList`1 locatedQueries, List`1 precompilationErrors, String suffix, ISet`1 generatedFileNames, CancellationToken cancellationToken) }
> 
>    at Microsoft.EntityFrameworkCore.Design.Internal.DbContextOperations.PrecompileQueries(String outputDir, DbContext context, String suffix, IServiceProvider services, IReadOnlyDictionary`2 memberAccessReplacements, ISet`1 generatedFileNames)
>    at Microsoft.EntityFrameworkCore.Design.Internal.DbContextOperations.Optimize(String outputDir, String modelNamespace, String suffix, Boolean scaffoldModel, Boolean precompileQueries, DbContext context, Boolean optimizeAllInAssembly, Boolean nativeAot, List`1 generatedFiles, HashSet`1 generatedFileNames)
>    at Microsoft.EntityFrameworkCore.Design.Internal.DbContextOperations.Optimize(String outputDir, String modelNamespace, String contextTypeName, String suffix, Boolean scaffoldModel, Boolean precompileQueries, Boolean nativeAot)
>    at Microsoft.EntityFrameworkCore.Design.OperationExecutor.OptimizeContextImpl(String outputDir, String modelNamespace, String contextType, String suffix, Boolean scaffoldModel, Boolean precompileQueries, Boolean nativeAot)
>    at Microsoft.EntityFrameworkCore.Design.OperationExecutor.OptimizeContext.<>c__DisplayClass0_0.<.ctor>b__0()
>    at Microsoft.EntityFrameworkCore.Design.OperationExecutor.OperationBase.<>c__DisplayClass3_0`1.<Execute>b__0()
>    at Microsoft.EntityFrameworkCore.Design.OperationExecutor.OperationBase.Execute(Action action)
