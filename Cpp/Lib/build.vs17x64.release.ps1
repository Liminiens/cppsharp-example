mkdir build_msvc;
cd build_msvc;
cmake -G "Visual Studio 15 2017 Win64" ..;
cmake --build . --config Release;
[void](Read-Host 'Press Enter to continue')