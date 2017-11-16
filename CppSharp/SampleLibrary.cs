using System;
using System.IO;
using CppSharp.AST;
using CppSharp.Generators;

namespace CppSharp
{
    public class SampleLibrary : ILibrary
    {
        private string GetRootFolderPath()
        {
            var fi = new FileInfo(AppDomain.CurrentDomain.BaseDirectory);
            //root of cpp and c# projects
            return fi.Directory.Parent.Parent.Parent.Parent.FullName;
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
            var options = driver.Options;
            options.GeneratorKind = GeneratorKind.CSharp;
            var module = options.AddModule("Sample");
            module.IncludeDirs.Add(@"C:\Sample\include");
            module.Headers.Add(@"Sample.h");
            module.LibraryDirs.Add(@"C:\Sample\lib");
            module.Libraries.Add(@"Sample.lib");
        }

        /// <inheritdoc />
        public void SetupPasses(Driver driver)
        {
        }
    }
}