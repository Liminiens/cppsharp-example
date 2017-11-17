#include <library.hpp>

extern "C" { void CppSharpGenerated_symbols1(void* instance) { new (instance) HelloClass(); } }
extern "C" { void CppSharpGenerated_symbols2(void* instance, const HelloClass& _0) { new (instance) HelloClass(_0); } }
HelloClass& (HelloClass::*CppSharpGenerated_symbols3)(const HelloClass&) = &HelloClass::operator=;
HelloClass& (HelloClass::*CppSharpGenerated_symbols4)(HelloClass&&) = &HelloClass::operator=;
extern "C" { void CppSharpGenerated_symbols5(HelloClass* instance) { instance->~HelloClass(); } }
extern "C" { void CppSharpGenerated_symbols6(void* instance, const Foo& _0) { new (instance) Foo(_0); } }
Foo& (Foo::*CppSharpGenerated_symbols7)(const Foo&) = &Foo::operator=;
Foo& (Foo::*CppSharpGenerated_symbols8)(Foo&&) = &Foo::operator=;
extern "C" { void CppSharpGenerated_symbols9(Foo* instance) { instance->~Foo(); } }
