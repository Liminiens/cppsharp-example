cmake_minimum_required(VERSION 3.9)
project(Lib)

set(CMAKE_CXX_STANDARD 14)

set(SOURCE_FILES library.cpp include/library.hpp)
add_library(Lib SHARED ${SOURCE_FILES})