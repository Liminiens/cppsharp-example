mkdir build_clang;
cd build_clang;
cmake -G "Visual Studio 15 2017 Win64" -T"LLVM-vs2014" ..;
cmake --build . --config Release;
[void](Read-Host 'Press Enter to continue')