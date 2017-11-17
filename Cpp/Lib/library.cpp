#include "include/library.hpp"

#include <iostream>

void HelloClass::hello() {
    std::cout << "Hello World!" << std::endl;
}

Foo::Foo(int a, float b) : a(a), b(b) {}

void Foo::print() {
    std::cout << this->a + this->b << std::endl;
}

int FooAdd(Foo *foo) {
    return static_cast<int>(foo->b * 2);
}