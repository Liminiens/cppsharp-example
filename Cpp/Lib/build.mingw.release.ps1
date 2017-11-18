mkdir build;
cd build;
cmake -G  "MinGW Makefiles" ..;
cmake --build . --config Release;
[void](Read-Host 'Press Enter to continue')