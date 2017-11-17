cmake_minimum_required(VERSION 3.9)
project(SampleLibrary)

set(CMAKE_CXX_STANDARD 17)

set(SOURCE_FILES library.cpp include/library.hpp)
add_library(SampleLibrary SHARED ${SOURCE_FILES})