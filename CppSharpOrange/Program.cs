using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;
using System;

namespace CppSharpOrange
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generating MonoOrange C# Bindings...");
            ConsoleDriver.Run(new CppSharp());
            Console.WriteLine("Finished Generating C# Bindings! \nPress any key to continue...");
            Console.ReadKey();
        }
    }

    class CppSharp : ILibrary
    {
        public void Setup(Driver driver)
        {
            var popt = driver.ParserOptions;
            popt.SetupMSVC(VisualStudioVersion.VS2015);
            var options = driver.Options;
            options.Verbose = true;
            options.GeneratorKind = GeneratorKind.CSharp;
            options.OutputDir = "../../Generated";
            //options.CompileCode = true;
            var module = options.AddModule("SharpOrange");
            // Issued: https://github.com/mono/CppSharp/issues/865
            module.IncludeDirs.Add("C:/Program Files (x86)/Windows Kits/10/Include/10.0.10586.0/ucrt");
            module.IncludeDirs.Add("../../../MonoOrange/");
            module.Headers.Add("stdafx.h");
            module.Headers.Add("CVector3.h");
            module.Headers.Add("Enums.h");
            module.Headers.Add("API.h");
        }

        public void SetupPasses(Driver driver)
        {
        }

        public void Preprocess(Driver driver, ASTContext ctx)
        {
        }

        public void Postprocess(Driver driver, ASTContext ctx)
        {
        }
    }
}
