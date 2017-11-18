using System;
using System.IO;
using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;
using CppSharp.Passes;
using CppAbi = CppSharp.Parser.AST.CppAbi;

namespace InterfaceGenerator
{
    public class SampleLibrary : ILibrary
    {
        private string GetRootFolderPath()
        {
            var fi = new FileInfo(AppDomain.CurrentDomain.BaseDirectory);
            //root of cpp and c# projects
            return fi.Directory.Parent.Parent.Parent.Parent.Parent.FullName;
        }

        /// <inheritdoc />
        public void Preprocess(Driver driver, ASTContext ctx)
        {
        }

        /// <inheritdoc />
        public void Postprocess(Driver driver, ASTContext ctx)
        {
        }

        /// <inheritdoc />
        public void Setup(Driver driver)
        {
            var root = GetRootFolderPath();
            var cppRoot = Path.Combine(root, @"Cpp\Lib");

            var module = driver.Options.AddModule("SampleLibrary");
            var includeFolder = Path.Combine(cppRoot, @"include");
            module.IncludeDirs.Add(includeFolder);
            module.Headers.Add(@"library.hpp");

            var libFolder = Path.Combine(cppRoot, @"build");
            module.LibraryDirs.Add(libFolder);
            module.Libraries.Add(@"libSampleLibrary.dll");
            module.OutputNamespace = "CppSharpGenerated";
            driver.Options.OutputDir = "CppSharpGenerated";

            driver.ParserOptions.Verbose = true;

            driver.ParserOptions.MicrosoftMode = false;
            driver.ParserOptions.Abi = CppAbi.Itanium;
            driver.Options.CheckSymbols = true;
            //should it be used?
            driver.ParserOptions.TargetTriple = "i686-w64-mingw32";

            driver.ParserOptions.NoBuiltinIncludes = true;
            driver.Options.GeneratorKind = GeneratorKind.CSharp;
            driver.Options.GenerateDefaultValuesForArguments = true;
        }

        /// <inheritdoc />
        public void SetupPasses(Driver driver)
        {
            driver.Context.TranslationUnitPasses.RenameDeclsUpperCase(RenameTargets.Any);
            driver.Context.TranslationUnitPasses.AddPass(new FunctionToInstanceMethodPass());
            driver.Context.TranslationUnitPasses.AddPass(new CheckAbiParameters());
        }
    }
}