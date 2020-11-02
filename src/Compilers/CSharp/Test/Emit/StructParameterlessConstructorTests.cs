// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CodeAnalysis.CSharp.Test.Utilities;
using Xunit;

namespace Microsoft.CodeAnalysis.CSharp.UnitTests
{
    public class StructParameterlessConstructorTests : CSharpTestBase
    {
        public static readonly CSharpParseOptions ParseOptions = TestOptions.Regular.WithExperimental(MessageID.IDS_FeatureStructParameterlessConstructors);

        [Fact]
        public void ParameterlessConstructorStruct001()
        {
            var source = @"
class C
{
    struct S1
    {
        public readonly int x;
        public S1()
        {
            x = 42;
        }
    }
    static void Main()
    {
        var s = new S1();
        System.Console.WriteLine(s.x);
    }
}
";
            CompileAndVerify(source, expectedOutput: "42", parseOptions: ParseOptions).
                VerifyIL("C.S1..ctor", @"
{
  // Code size        9 (0x9)
  .maxstack  2
  IL_0000:  ldarg.0
  IL_0001:  ldc.i4.s   42
  IL_0003:  stfld      ""int C.S1.x""
  IL_0008:  ret
}
");
        }

        [Fact]
        public void ParameterlessConstructorStruct002()
        {
            var source = @"
class C
{
    struct S1
    {
        public readonly int x;
        public S1()
        {
            x = 42;
        }
        public S1(int a):this()
        {
        }
    }
    static void Main()
    {
        var s = new S1(123);
        System.Console.WriteLine(s.x);
    }
}
";
            CompileAndVerify(source, expectedOutput: "42", parseOptions: ParseOptions).
                VerifyIL("C.S1..ctor(int)", @"
{
  // Code size        7 (0x7)
  .maxstack  1
  IL_0000:  ldarg.0
  IL_0001:  call       ""C.S1..ctor()""
  IL_0006:  ret
}
");
        }

        [Fact]
        public void ParameterlessConstructorStruct003()
        {
            var source = @"
class C
{
    struct S1
    {
        public readonly int x;
        public S1(): this(42)
        {
        }
        public S1(int a)
        {
            x = a;
        }
    }
    static void Main()
    {
        var s = new S1();
        System.Console.WriteLine(s.x);
    }
}
";
            CompileAndVerify(source, expectedOutput: "42", parseOptions: ParseOptions).
                VerifyIL("C.S1..ctor(int)", @"
{
  // Code size        8 (0x8)
  .maxstack  2
  IL_0000:  ldarg.0
  IL_0001:  ldarg.1
  IL_0002:  stfld      ""int C.S1.x""
  IL_0007:  ret
}
").
VerifyIL("C.S1..ctor()", @"
{
  // Code size        9 (0x9)
  .maxstack  2
  IL_0000:  ldarg.0
  IL_0001:  ldc.i4.s   42
  IL_0003:  call       ""C.S1..ctor(int)""
  IL_0008:  ret
}
");
        }

        [Fact]
        public void ParameterlessInstCtorInStructExprTree()
        {
            var source = @"
using System;
using System.Linq.Expressions;
class C
{
    struct S1
    {
        public int x;
        public S1()
        {
            x = 42;
        }
    }
    static void Main()
    {
        Expression<Func<S1>> testExpr = () => new S1();
        System.Console.Write(testExpr.Compile()().x);
    }
}
";
            CompileAndVerify(source, expectedOutput: "42", parseOptions: ParseOptions);
        }

        [Fact]
        public void CS32260001ERR_ParameterlessConstructorMustBePublic_FeatureEnabled()
        {
            var text = @"namespace x
{
    public struct S1
    {
        private S1() {}
    }
}
";
            var comp = CreateCompilation(text, parseOptions: ParseOptions);
            comp.VerifyDiagnostics(
                    // (5,17): error CS32260001: Parameterless instance constructors in structs must be public
                    //         private S1() {}
                    Diagnostic(ErrorCode.ERR_ParameterlessStructCtorsMustBePublic, "S1").WithLocation(5, 17)
            );
        }

        [Fact]
        public void CS32260001ERR_ParameterlessConstructorMustBePublic_FeatureDisabled()
        {
            var text = @"namespace x
{
    public struct S1
    {
        private S1() {}
    }
}
";
            var comp = CreateCompilation(text);
            comp.VerifyDiagnostics(
                    // (5,17): error CS32260001: Parameterless instance constructors in structs must be public
                    //         private S1() {}
                    Diagnostic(ErrorCode.ERR_ParameterlessStructCtorsMustBePublic, "S1").WithLocation(5, 17)
            );
        }

        [Fact]
        public void CS8058ERR_ParameterlessConstructorsAreExperimental()
        {
            var text = @"namespace x
{
    public struct S1
    {
        public S1() {}
    }
}
";
            var comp = CreateCompilation(text);
            comp.VerifyDiagnostics(
                    // (5,16): error CS8058: Feature 'struct instance parameterless constructors' is experimental and unsupported; use '/features:StructParameterlessConstructors' to enable.
                    //         public S1() {}
                    Diagnostic(ErrorCode.ERR_FeatureIsExperimental, "S1").WithArguments("struct instance parameterless constructors", "StructParameterlessConstructors").WithLocation(5, 16)
            );
        }
    }
}
