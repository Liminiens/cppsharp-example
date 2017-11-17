using System;
using System.IO;
using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;
using CppSharp.Passes;

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

            driver.ParserOptions.Verbose = true;
            driver.Options.GeneratorKind = GeneratorKind.CSharp;

            var module = driver.Options.AddModule("SampleLibrary");
            var includeFolder = Path.Combine(cppRoot, @"include");
            module.IncludeDirs.Add(includeFolder);
            module.Headers.Add(@"library.hpp");

            var libFolder = Path.Combine(cppRoot, @"build_clang\Release");
            module.LibraryDirs.Add(libFolder);
            module.Libraries.Add(@"SampleLibrary.dll");

            module.OutputNamespace = "CppSharpGenerated";
            driver.Options.OutputDir = "Generated";
        }

        /// <inheritdoc />
        public void SetupPasses(Driver driver)
        {
            driver.Context.TranslationUnitPasses.RenameDeclsUpperCase(RenameTargets.Any);
            driver.Context.TranslationUnitPasses.AddPass(new FunctionToInstanceMethodPass());
        }
    }
}